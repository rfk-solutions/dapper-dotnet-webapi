using AspNetCore.Identity.Dapper;
using AspNetCore.Identity.Dapper.Models;
using Contracts;
using FluentMigrator.Runner;
using LoggerService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Repository;
using Service;
using Service.Contracts;
using System.Reflection;
using System.Text;

namespace RFK.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureCors(this IServiceCollection services) =>
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder =>
            builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
        });

    public static void ConfigureIISIntegration(this IServiceCollection services) =>
        services.Configure<IISOptions>(options =>
        {
        });

    public static void ConfigureLoggerService(this IServiceCollection services) =>
        services.AddSingleton<ILoggerManager, LoggerManager>();

    public static void ConfigureFluentMigrator(this IServiceCollection services,
        IConfiguration configuration) => services.AddLogging(c =>
        c.AddFluentMigratorConsole())
            .AddFluentMigratorCore().ConfigureRunner(c =>
                c.AddSqlServer2016().WithGlobalConnectionString(
                        configuration.GetConnectionString("sqlConnection")
                        ?? configuration.GetConnectionString("SqlConnection")
                        ?? string.Empty)
                    .ScanIn(Assembly.GetExecutingAssembly())
                        .For.Migrations());

    public static void ConfigureRepositoryManager(this IServiceCollection services) =>
        services.AddScoped<IRepositoryManager, RepositoryManager>();

    public static void ConfigureServiceManager(this IServiceCollection services) =>
        services.AddScoped<IServiceManager, ServiceManager>();

    public static void ConfigureIdentity(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("sqlConnection")
                            ?? configuration.GetConnectionString("SqlConnection")
                            ?? string.Empty;

        services.AddIdentity<ApplicationUser, ApplicationRole>(o =>
        {
            o.Password.RequireDigit = true;
            o.Password.RequireLowercase = false;
            o.Password.RequireUppercase = false;
            o.Password.RequireNonAlphanumeric = false;
            o.Password.RequiredLength = 10;
            o.User.RequireUniqueEmail = true;
        })
        .AddDapperStores(opt =>
        {
            opt.ConnectionString = connectionString;
        })
        .AddDefaultTokenProviders();
    }

    public static void ConfigureJWT(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtSettings = configuration.GetSection("JwtSettings");

        // Look for secret in Environment Variable OR configuration section (appsettings / Azure App Settings)
        var secretKey = Environment.GetEnvironmentVariable("SECRET")
                        ?? jwtSettings["secret"]
                        ?? configuration["SECRET"]
                        ?? "FallbackSecretKeyForDevelopmentPhaseMustBe32Bytes!";

        services.AddAuthentication(opt =>
        {
            opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,

                ValidIssuer = jwtSettings["validIssuer"] ?? "https://localhost:5001",
                ValidAudience = jwtSettings["validAudience"] ?? "https://localhost:5001",
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
            };
        });
    }

    public static void ConfigureSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(s =>
        {
            s.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "RFK SOLUTIONS API",
                Description = "EswatiniEmployees API by RFK Solutions",
                Contact = new OpenApiContact
                {
                    Name = "Njabulo Mamba",
                    Email = "njabulo@rfksolutions.net",
                    Url = new Uri("https://github.com/njabulo240"),
                },
                License = new OpenApiLicense
                {
                    Name = "EswatiniEmployees API LICX",
                    Url = new Uri("https://github.com/rfk-solutions/dapper-dotnet-webapi?tab=MIT-1-ov-file#"),
                }
            });

            var xmlFile = $"{typeof(Presentation.AssemblyReference).Assembly.GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

            // Safely check if XML exists before adding it to avoid IO/deployment exceptions
            if (File.Exists(xmlPath))
            {
                s.IncludeXmlComments(xmlPath);
            }

            s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Place to add JWT with Bearer",
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
            });

            s.AddSecurityRequirement(new OpenApiSecurityRequirement()
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        },
                        Name = "Bearer",
                    },
                    new List<string>()
                }
            });
        });
    }
}