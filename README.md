\# 🚀 RFK Solutions — ASP.NET Core \& Dapper Project Template



\[!\[.NET](https://img.shields.io/badge/.NET-8.0-512BD4?logo=dotnet\&logoColor=white)](https://dotnet.microsoft.com/)

\[!\[Dapper](https://img.shields.io/badge/ORM-Dapper-red?logo=csharp)](https://github.com/DapperLib/Dapper)

\[!\[SQL Server](https://img.shields.io/badge/Database-SQL\_Server-CC292B?logo=microsoftsqlserver\&logoColor=white)](https://www.microsoft.com/sql-server/)

\[!\[Swagger](https://img.shields.io/badge/Documentation-Swagger-85EA2D?logo=swagger\&logoColor=black)](https://swagger.io/)

\[!\[License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)



A production-ready \*\*ASP.NET Core Web API\*\* enterprise boilerplate featuring \*\*Dapper ORM\*\*, \*\*ASP.NET Core Identity\*\*, \*\*FluentMigrator\*\*, and \*\*SQL Server\*\*. Built on Clean Architecture principles with decoupled Presentation and Service layers.



\---



\## 💡 Overview: ASP.NET Core Web API \& Dapper



\### ASP.NET Core Web API

ASP.NET Core Web API is a cross-platform, high-performance framework designed for building HTTP-based RESTful services. It acts as the backend middleware that exposes secure endpoints and exchanges JSON payloads with modern web frontends, mobile applications, and external integrations.



\### Dapper ORM

\*\*Dapper\*\* is a high-performance micro-ORM (Object-Relational Mapper) for .NET, widely recognized as the \*\*"King of Micro-ORMs"\*\*.



\* \*\*Near-Native Speed\*\*: Dapper extends `IDbConnection` to execute raw SQL and map results directly to C# objects with execution speeds virtually identical to a raw `SqlDataReader`.

\* \*\*Full Query Control\*\*: Unlike heavy full-featured ORMs, Dapper lets developers write precise SQL queries, manage multi-mapping, and execute stored procedures without unpredictable query generation.

\* \*\*Low Memory Footprint\*\*: Keeps system overhead minimal by eliminating entity change-tracking mechanisms.



\---



\## 🔐 Default Authentication Credentials



Use these pre-configured credentials for local testing and initial login access:



| Attribute | Default Value |

| :--- | :--- |

| \*\*Username / Email\*\* | `admin@rfksolutions.com` |

| \*\*Password\*\* | `Admin123!` |



\---



\## 🏗️ Solution Architecture \& Folder Structure



```text

RFK.sln

├── IdentityTables.sql          # SQL script containing ASP.NET Core Identity schema definitions

├── src/

│   ├── AspNetCore.Identity.Dapper / # Dapper store implementation for ASP.NET Core Identity

│   ├── Contracts/              # Repository interfaces and low-level abstractions

│   ├── Entities/               # Domain entities, DTOs, and Identity models

│   ├── LoggerService/          # Custom logging middleware and provider configurations

│   ├── Repository/             # Dapper execution context, SQL queries, and Stored Procedures

│   ├── RFK/                    # Web API entry point, DI container, appsettings, and Program.cs

│   ├── RFK.Presentation/       # Decoupled REST API controllers assembly

│   ├── Service/                # Core business logic implementation and workflow orchestration

│   ├── Service.Contracts/      # Service layer abstractions and contracts

│   └── Shared/                 # Global parameters (Paging, Filtering, Search, Sorting)

└── README.md

