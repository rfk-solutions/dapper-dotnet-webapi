using Contracts;
using FluentMigrator.Runner;
using RFK.Migrations;

namespace RFK.Extensions
{
    public static class MigrationManager
    {
        public static WebApplication MigrateDatabase(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var databaseService = scope.ServiceProvider
                    .GetRequiredService<Database>();
                var migrationService = scope.ServiceProvider
                    .GetRequiredService<IMigrationRunner>();

                try
                {
                    databaseService.CreateDatabase("RFKEmployeesDapper");

                    migrationService.ListMigrations();
                    migrationService.MigrateUp();
                }
                catch (Exception ex)
                {
                    var logger = scope.ServiceProvider.GetRequiredService<ILoggerManager>();
                    logger.LogError($"Exception occurred during database creation or migration: {ex}");
                    throw;
                }
            }

            return app;
        }
    }
}