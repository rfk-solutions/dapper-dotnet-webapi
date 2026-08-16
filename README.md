\# 🚀 RFK Solutions — ASP.NET Core \& Dapper Enterprise Project Template



\[!\[.NET 8](https://img.shields.io/badge/.NET-8.0-512BD4?logo=dotnet\\\&logoColor=white)](https://dotnet.microsoft.com/)

\[!\[ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-8.0-512BD4?logo=dotnet\\\&logoColor=white)](https://learn.microsoft.com/aspnet/core/)

\[!\[Dapper](https://img.shields.io/badge/ORM-Dapper-CC2927?logo=csharp\\\&logoColor=white)](https://github.com/DapperLib/Dapper)

\[!\[SQL Server](https://img.shields.io/badge/Database-SQL%20Server-CC2927?logo=microsoftsqlserver\\\&logoColor=white)](https://www.microsoft.com/sql-server/)

\[!\[Swagger](https://img.shields.io/badge/API%20Docs-Swagger-85EA2D?logo=swagger\\\&logoColor=black)](https://swagger.io/)

\[!\[License](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)



> \*\*A professional, scalable ASP.NET Core Web API template built with Dapper, ASP.NET Core Identity, SQL Server, and Clean Architecture principles.\*\*



RFK Solutions is a reusable \*\*ASP.NET Core 8 Web API project template\*\* designed for building secure, maintainable, and scalable enterprise applications.



The solution separates \*\*API presentation, business logic, data access, domain models, contracts, authentication, logging, and shared infrastructure\*\* into dedicated projects, making it suitable for both small applications and large enterprise systems.



\---



\## 📋 Table of Contents



\* \[Overview](#-overview)

\* \[Key Features](#-key-features)

\* \[Technology Stack](#-technology-stack)

\* \[Architecture](#-architecture)

\* \[Project Structure](#-project-structure)

\* \[Authentication](#-authentication)

\* \[Prerequisites](#-prerequisites)

\* \[Getting Started](#-getting-started)

\* \[Database Configuration](#-database-configuration)

\* \[Running the Application](#-running-the-application)

\* \[API Documentation](#-api-documentation)

\* \[Architecture Principles](#-architecture-principles)

\* \[Development Guidelines](#-development-guidelines)

\* \[Recommended Workflow](#-recommended-workflow)

\* \[Production Considerations](#-production-considerations)

\* \[License](#-license)



\---



\# 📖 Overview



This template provides a structured foundation for developing modern \*\*ASP.NET Core Web APIs\*\* using a clean separation of responsibilities.



It is designed around the following principles:



\* Clean Architecture

\* Separation of concerns

\* Dependency inversion

\* Repository pattern

\* Service-layer business logic

\* Contract-based development

\* Dapper-based data access

\* ASP.NET Core Identity authentication

\* SQL Server database integration

\* Centralized logging

\* Swagger/OpenAPI documentation

\* Reusable shared infrastructure



The goal is to provide developers with a \*\*consistent starting point\*\* for building professional .NET applications without having to recreate the same architectural foundation for every project.



\---



\# ✨ Key Features



\### ⚡ ASP.NET Core 8



Built on \*\*ASP.NET Core 8\*\* for high-performance, cross-platform API development.



\### 🗄️ Dapper



Uses \*\*Dapper\*\* as the primary data-access technology, providing lightweight and high-performance SQL execution with full control over database queries.



\### 🔐 ASP.NET Core Identity



Provides authentication and user-management capabilities through ASP.NET Core Identity with a custom Dapper-based store implementation.



\### 🏛️ Clean Architecture



The solution separates responsibilities between:



\* Presentation

\* Services

\* Contracts

\* Entities

\* Repository/Data Access

\* Identity

\* Logging

\* Shared infrastructure



\### 🛢️ SQL Server



Designed for Microsoft SQL Server and enterprise relational database applications.



\### 📚 Swagger / OpenAPI



Provides interactive API documentation and testing through Swagger.



\### 📝 Centralized Logging



Includes a dedicated logging project for application logging and cross-cutting concerns.



\### 🔄 Repository Pattern



Database operations are isolated from business logic through repository abstractions.



\### 🧩 Dependency Injection



Uses the built-in ASP.NET Core dependency injection system to keep components loosely coupled and testable.



\### 📦 Reusable Architecture



The solution is designed to serve as a foundation for:



\* Enterprise applications

\* Business management systems

\* ERP systems

\* Financial applications

\* E-commerce platforms

\* REST APIs

\* Mobile application backends

\* Angular frontends

\* .NET MAUI applications

\* Third-party integrations



\---



\# 🛠️ Technology Stack



| Technology                | Purpose                                |

| ------------------------- | -------------------------------------- |

| \*\*.NET 8\*\*                | Application platform                   |

| \*\*ASP.NET Core Web API\*\*  | REST API framework                     |

| \*\*C#\*\*                    | Primary programming language           |

| \*\*Dapper\*\*                | Micro-ORM / data access                |

| \*\*ASP.NET Core Identity\*\* | Authentication and identity management |

| \*\*SQL Server\*\*            | Relational database                    |

| \*\*Swagger / OpenAPI\*\*     | API documentation                      |

| \*\*FluentMigrator\*\*        | Database migration management          |

| \*\*Dependency Injection\*\*  | Service composition                    |

| \*\*Git / GitHub\*\*          | Source control                         |

| \*\*Visual Studio\*\*         | Recommended IDE                        |



\---



\# 🏛️ Architecture



The solution follows a layered architecture inspired by \*\*Clean Architecture\*\*.



```text

&#x20;                        ┌──────────────────────────┐

&#x20;                        │        Clients           │

&#x20;                        │                          │

&#x20;                        │ Angular / Mobile / MAUI  │

&#x20;                        │ External Applications    │

&#x20;                        └────────────┬─────────────┘

&#x20;                                     │

&#x20;                                     ▼

&#x20;                        ┌──────────────────────────┐

&#x20;                        │    RFK.Presentation      │

&#x20;                        │                          │

&#x20;                        │ Controllers / Endpoints  │

&#x20;                        └────────────┬─────────────┘

&#x20;                                     │

&#x20;                                     ▼

&#x20;                        ┌──────────────────────────┐

&#x20;                        │          Service         │

&#x20;                        │                          │

&#x20;                        │ Business Logic / Rules   │

&#x20;                        └────────────┬─────────────┘

&#x20;                                     │

&#x20;                                     ▼

&#x20;                        ┌──────────────────────────┐

&#x20;                        │        Repository        │

&#x20;                        │                          │

&#x20;                        │ Dapper / SQL / Database  │

&#x20;                        └────────────┬─────────────┘

&#x20;                                     │

&#x20;                                     ▼

&#x20;                        ┌──────────────────────────┐

&#x20;                        │        SQL Server        │

&#x20;                        └──────────────────────────┘





&#x20;       Supporting Layers

&#x20;       ───────────────────────────────────────────



&#x20;       Contracts

&#x20;       Service.Contracts

&#x20;       Entities

&#x20;       Shared

&#x20;       LoggerService

&#x20;       AspNetCore.Identity.Dapper

```



The architecture ensures that each layer has a clearly defined responsibility.



\---



\# 📁 Project Structure



```text

RFK.sln

│

├── .github/

│   └── workflows/                 # GitHub Actions / CI/CD

│

├── src/

│   │

│   ├── AspNetCore.Identity.Dapper/

│   │   └── Custom ASP.NET Core Identity Dapper implementation

│   │

│   ├── Contracts/

│   │   └── Repository and infrastructure abstractions

│   │

│   ├── Entities/

│   │   └── Domain entities, DTOs and identity models

│   │

│   ├── LoggerService/

│   │   └── Centralized logging implementation

│   │

│   ├── Repository/

│   │   └── Dapper data access, SQL queries and database operations

│   │

│   ├── RFK/

│   │   └── ASP.NET Core application entry point

│   │       ├── Program.cs

│   │       ├── appsettings.json

│   │       └── Dependency Injection configuration

│   │

│   ├── RFK.Presentation/

│   │   └── API controllers and HTTP endpoints

│   │

│   ├── Service/

│   │   └── Business logic and application services

│   │

│   ├── Service.Contracts/

│   │   └── Service interfaces and application contracts

│   │

│   └── Shared/

│       └── Common models, paging, filtering,

│           sorting and shared parameters

│

├── IdentityTables.sql              # ASP.NET Core Identity database schema

├── .gitignore

├── .gitattributes

├── LICENSE

├── README.md

└── RFK.sln

```



\---



\# 🧱 Layer Responsibilities



\## `RFK`



The main ASP.NET Core application and startup project.



Responsible for:



\* Application startup

\* Dependency injection

\* Middleware configuration

\* Authentication configuration

\* Database configuration

\* Application settings

\* Swagger configuration

\* HTTP pipeline configuration



\---



\## `RFK.Presentation`



Contains the API presentation layer.



Responsible for:



\* Controllers

\* HTTP endpoints

\* Request handling

\* Response handling

\* Model binding

\* HTTP status codes



Controllers should remain lightweight and delegate business operations to the service layer.



\---



\## `Service`



Contains the application's business logic.



Responsible for:



\* Business rules

\* Application workflows

\* Validation

\* Coordination between repositories

\* Business operations

\* Transaction orchestration



The service layer should not contain HTTP-specific logic.



\---



\## `Service.Contracts`



Contains interfaces and contracts for application services.



Example:



```csharp

public interface IUserService

{

&#x20;   Task<UserDto?> GetByIdAsync(int id);

&#x20;   Task<IEnumerable<UserDto>> GetAllAsync();

}

```



This keeps the service implementation decoupled from the API layer.



\---



\## `Repository`



Responsible for database access.



Typical responsibilities include:



\* Dapper queries

\* Stored procedures

\* SQL commands

\* Database connections

\* Query execution

\* Mapping database results



Example:



```csharp

public async Task<User?> GetByIdAsync(int id)

{

&#x20;   const string sql = """

&#x20;       SELECT \*

&#x20;       FROM Users

&#x20;       WHERE Id = @Id

&#x20;       """;



&#x20;   return await connection.QuerySingleOrDefaultAsync<User>(

&#x20;       sql,

&#x20;       new { Id = id });

}

```



\---



\## `Contracts`



Contains repository and infrastructure abstractions.



This allows the application to depend on interfaces instead of concrete implementations.



Example:



```csharp

public interface IUserRepository

{

&#x20;   Task<User?> GetByIdAsync(int id);

&#x20;   Task<IEnumerable<User>> GetAllAsync();

}

```



\---



\## `Entities`



Contains the application's core models.



Depending on the project, this may include:



\* Domain entities

\* DTOs

\* Identity models

\* Request models

\* Response models

\* Enumerations



\---



\## `Shared`



Contains reusable cross-project functionality.



Examples include:



\* Paging parameters

\* Search parameters

\* Filtering

\* Sorting

\* Common response models

\* Shared constants

\* Common utilities



\---



\## `LoggerService`



Contains centralized logging functionality.



This layer keeps logging concerns separated from the application's business logic.



\---



\## `AspNetCore.Identity.Dapper`



Provides the Dapper implementation required to integrate \*\*ASP.NET Core Identity\*\* with a Dapper-based data-access architecture.



This allows Identity to work without requiring Entity Framework Core as the application's primary ORM.



\---



\# 🔐 Authentication



The template includes ASP.NET Core Identity support.



For local development, the default administrator credentials are:



| Property             | Value                    |

| -------------------- | ------------------------ |

| \*\*Username / Email\*\* | `admin@rfksolutions.com` |

| \*\*Password\*\*         | `Admin123!`              |



> ⚠️ \*\*Security Notice:\*\* These credentials are intended for local development and initial testing only. Change or disable the default administrator credentials before deploying the application to a production environment.



Authentication and authorization should be configured using secure production secrets and environment-specific configuration.



\---



\# 📋 Prerequisites



Before running the project, install:



\### Required



\* \[.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

\* \[Microsoft SQL Server](https://www.microsoft.com/sql-server/)

\* \[Visual Studio 2022](https://visualstudio.microsoft.com/) or another compatible .NET IDE

\* Git



\### Recommended



\* SQL Server Management Studio (SSMS)

\* Postman

\* Docker

\* GitHub account



\---



\# 🚀 Getting Started



\## 1. Clone the Repository



```bash

git clone https://github.com/YOUR-USERNAME/YOUR-REPOSITORY.git

```



Navigate into the project:



```bash

cd YOUR-REPOSITORY

```



\---



\## 2. Restore Dependencies



Run:



```bash

dotnet restore

```



\---



\## 3. Build the Solution



```bash

dotnet build

```



A successful build confirms that the solution and project dependencies are correctly configured.



\---



\# 🗄️ Database Configuration



The application is designed to use \*\*Microsoft SQL Server\*\*.



Configure the database connection string in the appropriate application configuration file.



Example:



```json

{

&#x20; "ConnectionStrings": {

&#x20;   "DefaultConnection": "Server=localhost;Database=RFKDb;Trusted\_Connection=True;TrustServerCertificate=True;"

&#x20; }

}

```



For production environments, avoid storing sensitive credentials directly in source control.



Use:



\* Environment variables

\* User Secrets

\* Azure Key Vault

\* Docker secrets

\* CI/CD secret management



\---



\# 🧩 Identity Database



The repository includes:



```text

IdentityTables.sql

```



This script contains the database tables required for ASP.NET Core Identity.



Before running the application for the first time:



1\. Create the target SQL Server database.

2\. Execute the Identity database script where required.

3\. Configure the connection string.

4\. Verify database connectivity.

5\. Start the API.

6\. Create or configure the required application users.



\---



\# ▶️ Running the Application



From the solution directory:



```bash

dotnet run --project src/RFK

```



Alternatively, open:



```text

RFK.sln

```



in Visual Studio and run the `RFK` project.



The application will start using the configured ASP.NET Core environment.



\---



\# 📚 API Documentation



The project includes Swagger/OpenAPI support.



Once the application is running, open the Swagger endpoint configured by the application.



Typically:



```text

https://localhost:<port>/swagger

```



Swagger allows developers to:



\* Explore API endpoints

\* View request models

\* View response models

\* Test endpoints

\* Inspect authentication requirements

\* Understand API contracts



\---



\# 🔄 Typical Request Flow



A typical API request follows this architecture:



```text

HTTP Request

&#x20;    │

&#x20;    ▼

Controller

&#x20;    │

&#x20;    ▼

Service Contract

&#x20;    │

&#x20;    ▼

Service

&#x20;    │

&#x20;    ▼

Repository Contract

&#x20;    │

&#x20;    ▼

Repository

&#x20;    │

&#x20;    ▼

Dapper

&#x20;    │

&#x20;    ▼

SQL Server

&#x20;    │

&#x20;    ▼

Repository

&#x20;    │

&#x20;    ▼

Service

&#x20;    │

&#x20;    ▼

Controller

&#x20;    │

&#x20;    ▼

HTTP Response

```



This structure keeps responsibilities separated and makes the application easier to maintain and test.



\---



\# 🧠 Architecture Principles



The template follows several important software engineering principles.



\### Separation of Concerns



Each project has a specific responsibility.



\### Dependency Inversion



Higher-level business logic depends on abstractions rather than concrete implementations.



\### Single Responsibility



Classes should have one clear responsibility.



\### Loose Coupling



Projects communicate through interfaces and contracts wherever appropriate.



\### Testability



Business logic is isolated from infrastructure and HTTP concerns, making it easier to unit test.



\### Maintainability



The architecture is designed to remain manageable as the application grows.



\### Scalability



The separation between presentation, services and data access allows the application to evolve without tightly coupling components.



\---



\# 📐 Development Guidelines



When adding a new feature, follow this general structure:



```text

1\. Define Entity / DTO

&#x20;       ↓

2\. Define Repository Contract

&#x20;       ↓

3\. Implement Repository

&#x20;       ↓

4\. Define Service Contract

&#x20;       ↓

5\. Implement Service

&#x20;       ↓

6\. Create Controller

&#x20;       ↓

7\. Document API

&#x20;       ↓

8\. Test

```



\### Controllers



Keep controllers thin.



Avoid placing complex business logic inside controllers.



\### Services



Business rules and workflows should primarily live in the service layer.



\### Repositories



Repositories should focus on database interaction.



\### SQL



Use parameterized queries when working with Dapper.



```csharp

const string sql = """

&#x20;   SELECT \*

&#x20;   FROM Users

&#x20;   WHERE Id = @Id

&#x20;   """;



var user = await connection.QuerySingleOrDefaultAsync<User>(

&#x20;   sql,

&#x20;   new { Id = id });

```



Never concatenate untrusted user input directly into SQL statements.



\---



\# 🔍 Recommended Feature Development Pattern



For example, when implementing a new `Product` feature:



```text

Entities

└── Product.cs



Contracts

└── IProductRepository.cs



Repository

└── ProductRepository.cs



Service.Contracts

└── IProductService.cs



Service

└── ProductService.cs



RFK.Presentation

└── ProductsController.cs

```



This ensures the feature follows the same architecture as the rest of the application.



\---



\# 🧪 Testing Strategy



The architecture is designed to support multiple levels of testing.



\### Unit Tests



Test business logic independently from the database and HTTP layer.



\### Integration Tests



Test:



\* Database operations

\* Repository implementations

\* Authentication

\* API workflows



\### API Testing



Use Swagger, Postman or automated API tests to validate endpoints.



\---



\# 🔒 Production Considerations



Before deploying an application built from this template to production:



\* \[ ] Change all default credentials

\* \[ ] Configure production connection strings securely

\* \[ ] Disable development-only settings

\* \[ ] Configure HTTPS

\* \[ ] Configure CORS appropriately

\* \[ ] Enable appropriate authentication and authorization policies

\* \[ ] Configure production logging

\* \[ ] Protect sensitive configuration values

\* \[ ] Review database permissions

\* \[ ] Configure backups

\* \[ ] Configure health checks

\* \[ ] Configure monitoring

\* \[ ] Review API rate limiting requirements

\* \[ ] Review error handling

\* \[ ] Remove sensitive information from logs

\* \[ ] Configure CI/CD deployment

\* \[ ] Review container and infrastructure security where applicable



\---



\# 🌐 Designed for Modern Applications



The RFK Solutions backend architecture can serve as the foundation for multiple client applications.



```text

&#x20;                        RFK Solutions API

&#x20;                               │

&#x20;             ┌─────────────────┼─────────────────┐

&#x20;             │                 │                 │

&#x20;             ▼                 ▼                 ▼

&#x20;         Angular Web       .NET MAUI          Mobile

&#x20;         Application       Application        Clients

&#x20;             │                 │                 │

&#x20;             └─────────────────┼─────────────────┘

&#x20;                               │

&#x20;                               ▼

&#x20;                       ASP.NET Core API

&#x20;                               │

&#x20;                   ┌───────────┴───────────┐

&#x20;                   │                       │

&#x20;                   ▼                       ▼

&#x20;                Dapper                 Identity

&#x20;                   │                       │

&#x20;                   └───────────┬───────────┘

&#x20;                               │

&#x20;                               ▼

&#x20;                          SQL Server

```



This makes the backend suitable for applications with multiple client platforms while maintaining a single centralized API and business layer.



\---



\# 📦 Reusable Template



This repository is intended to be used as a starting point for new RFK Solutions applications.



When starting a new project:



```text

RFK Template

&#x20;    │

&#x20;    ├── Rename solution

&#x20;    ├── Configure database

&#x20;    ├── Configure authentication

&#x20;    ├── Add domain entities

&#x20;    ├── Add repositories

&#x20;    ├── Add services

&#x20;    ├── Add API controllers

&#x20;    ├── Configure environment

&#x20;    └── Deploy

```



The architecture should remain consistent while individual projects add their own domain-specific functionality.



\---



\# 🤝 Contributing



Contributions, improvements and architectural suggestions are welcome.



When contributing:



1\. Create a feature branch.

2\. Follow the existing architecture.

3\. Keep controllers lightweight.

4\. Keep business logic inside services.

5\. Keep database operations inside repositories.

6\. Use interfaces for cross-layer dependencies.

7\. Follow consistent naming conventions.

8\. Add appropriate tests.

9\. Update documentation when introducing significant changes.

10\. Submit a pull request for review.



\---



\# 📄 License



This project is licensed under the \*\*MIT License\*\*.



See the \[LICENSE](LICENSE) file for more information.



\---



\# 🏢 RFK Solutions



\*\*RFK Solutions\*\* is focused on building modern software solutions using the Microsoft .NET ecosystem.



\### Core Technology Stack



\* C#

\* ASP.NET Core

\* .NET 8+

\* Angular

\* .NET MAUI

\* SQL Server

\* Dapper

\* Azure

\* Docker

\* Kubernetes

\* REST APIs



\---



<p align="center">

&#x20; <strong>Built with ❤️ using Microsoft .NET</strong>

</p>



<p align="center">

&#x20; <sub>RFK Solutions — Enterprise .NET Application Architecture</sub>

</p>



