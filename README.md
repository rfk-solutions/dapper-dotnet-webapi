# 🚀 RFK Solutions — ASP.NET Core & Dapper Template

[![.NET 9](https://img.shields.io/badge/.NET-8.0-512BD4?logo=dotnet\&logoColor=white)](https://dotnet.microsoft.com/)
[![Dapper](https://img.shields.io/badge/ORM-Dapper-CC2929?logo=csharp\&logoColor=white)](https://github.com/DapperLib/Dapper)
[![SQL Server](https://img.shields.io/badge/Database-SQL%20Server-CC2927?logo=microsoftsqlserver\&logoColor=white)](https://www.microsoft.com/sql-server/)
[![Swagger](https://img.shields.io/badge/API-Swagger-85EA2D?logo=swagger\&logoColor=black)](https://swagger.io/)
[![License](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)

A production-ready **ASP.NET Core Web API template** built with **Dapper, SQL Server, ASP.NET Core Identity, FluentMigrator, JWT authentication**, and a clean separation between presentation, services, and data access.

---

## ✨ Features

* ⚡ ASP.NET Core 9 Web API
* 🗄️ Dapper Micro-ORM
* 🔐 ASP.NET Core Identity with Dapper
* 🔑 JWT Authentication
* 🧩 FluentMigrator
* 🛢️ SQL Server
* 📋 Swagger / OpenAPI
* 🏗️ Clean Architecture
* 📦 Repository & Service patterns
* 🔎 Filtering, searching, sorting & pagination
* 🪵 Centralized logging
* 🔄 Dependency Injection
* 🚀 Ready for enterprise applications

---

## 🛠️ Technology Stack

| Technology            | Purpose                        |
| --------------------- | ------------------------------ |
| .NET 9                | Application framework          |
| ASP.NET Core          | Web API                        |
| Dapper                | Data access                    |
| SQL Server            | Database                       |
| FluentMigrator        | Database migrations            |
| ASP.NET Core Identity | Authentication & authorization |
| JWT                   | API authentication             |
| Swagger               | API documentation              |

---

# 🚀 Getting Started

## 1. Configure JWT Secret

The application requires the `SECRET` environment variable.

### Windows — CMD as Administrator

```cmd
setx SECRET "RFKSolutionsSecretKey2026EswatiniEmployees256BitSecure!" /M
```

Restart your terminal or Visual Studio after running the command.

### Linux / macOS

```bash
export SECRET="RFKSolutionsSecretKey2026EswatiniEmployees256BitSecure!"
```

> For production, use a secure secret-management solution rather than storing secrets directly in source control.

---

## 2. Configure SQL Server

Open:

```text
src/RFK/appsettings.json
```

Configure your database connection:

```json
{
  "ConnectionStrings": {
    "sqlConnection": "Server=.;Database=RFKDb;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

Make sure SQL Server is running and accessible.

---

## 3. Run the Application

From the repository root:

```bash
dotnet restore
dotnet build
dotnet run --project src/RFK
```

FluentMigrator will create the application database and run the available migrations.

---

## 4. Create Identity Tables

If the application reports missing Identity tables such as:

```text
AspNetUsers
AspNetRoles
AspNetUserRoles
AspNetUserClaims
AspNetRoleClaims
```

### Database Update Instructions

> **Important:** Ensure you stop the application before executing these steps to prevent database locks or active connection errors.

1. **Stop the Application**
   * Terminate all running instances of the application in your IDE.

2. **Open SQL Server Management Studio (SSMS)** and connect to your SQL Server instance and Select the Target Database**
   * Choose one of the following methods to load the script:
     * **Method A:** Open the `IdentityTables` file located in the project's **root folder**, copy the entire SQL script, and paste it             into a **New Query** window (`Ctrl + N`) in SSMS.
     * **Method B:** Select **File > Open > File...** in SSMS and select `IdentityTables.sql` directly.

3. **Execute the Script**
   * Click the **Execute** button in the toolbar (or press **F5**) to run the script.
   * Confirm that the output window displays `Commands completed successfully.`

## 5. Run the API

Start the application again:

```bash
dotnet run --project src/RFK
```

Open Swagger using the HTTPS URL shown in the application output:

```text
https://localhost:<port>/swagger
```

---

## 🔐 Default Account

| Property | Value          |
| -------- | -------------- |
| Username | `admin`        |
| Password | `Password123!` |

> Change the default password before using the application in a production environment.

After logging in, copy the JWT token and use **Authorize** in Swagger:

```text
Bearer <your-token>
```

---

# 🏗️ Architecture

```text
RFK.Solutions/
│
├── .github/
│   └── workflows/
│
├── src/
│   ├── AspNetCore.Identity.Dapper/
│   ├── Contracts/
│   ├── Entities/
│   ├── LoggerService/
│   ├── Repository/
│   ├── RFK/
│   ├── RFK.Presentation/
│   ├── Service/
│   ├── Service.Contracts/
│   └── Shared/
│
├── IdentityTables
├── LICENSE
├── README.md
└── RFK.sln
```

## 📁 Project Responsibilities

| Project                      | Responsibility                                          |
| ---------------------------- | ------------------------------------------------------- |
| `AspNetCore.Identity.Dapper` | Dapper-based ASP.NET Core Identity stores               |
| `Contracts`                  | Repository and data-access contracts                    |
| `Entities`                   | Domain models, DTOs and Identity entities               |
| `LoggerService`              | Centralized logging                                     |
| `Repository`                 | Dapper queries, repositories and stored procedures      |
| `RFK`                        | API host, configuration and dependency injection        |
| `RFK.Presentation`           | API controllers and HTTP endpoints                      |
| `Service`                    | Business logic and application services                 |
| `Service.Contracts`          | Service interfaces                                      |
| `Shared`                     | Common models, paging, filtering, searching and sorting |

---

# 📚 API Documentation

Swagger provides interactive API documentation and testing.

```text
https://localhost:<port>/swagger
```

---

# 📄 License

This project is licensed under the [MIT License](LICENSE).
