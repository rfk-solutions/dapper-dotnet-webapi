# 🚀 RFK Solutions — ASP.NET Core & Dapper Project Template

[![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![Dapper](https://img.shields.io/badge/ORM-Dapper-red?logo=csharp)](https://github.com/DapperLib/Dapper)
[![SQL Server](https://img.shields.io/badge/Database-SQL_Server-CC292B?logo=microsoftsqlserver&logoColor=white)](https://www.microsoft.com/sql-server/)
[![Swagger](https://img.shields.io/badge/Documentation-Swagger-85EA2D?logo=swagger&logoColor=black)](https://swagger.io/)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)

A production-ready **ASP.NET Core Web API** enterprise boilerplate featuring **Dapper ORM**, **ASP.NET Core Identity**, **FluentMigrator**, and **SQL Server**. Built on Clean Architecture principles with decoupled Presentation and Service layers.

---

## 📌 Key Features

* ⚡ **Full RESTful CRUD Operations**: Pre-configured HTTP GET, POST, PUT, and DELETE workflows.
* 🔐 **Dapper & ASP.NET Core Identity**: Custom Dapper-backed Identity store for JWT authentication, user registration, and role management.
* ⚙️ **Dapper Stored Procedures**: Pre-built data access patterns supporting direct execution of SQL Server Stored Procedures.
* 🔍 **Advanced Query Capabilities**:
  * 📄 **Pagination**: Dynamic offset and page-size data queries with metadata headers.
  * 🎯 **Filtering**: Custom field-level filter parameters.
  * 🔎 **Searching**: Global multi-column text search.
  * 📊 **Sorting**: Dynamic multi-column SQL ordering.
* 🔄 **FluentMigrator & Auto-Provisioning**: Automated database creation on startup along with C# schema migrations and seed data.
* 📄 **Swagger / OpenAPI**: Embedded interactive API documentation for testing secured endpoints directly in the browser.
* 🪵 **LoggerService**: Dedicated logging service implementation for structured error and activity tracking.

---

## 🏗️ Solution Architecture

```text
RFK.Solutions/
├── Contracts/            # Low-level data layer interfaces and repository contracts
├── Entities/             # Domain entities, DTOs, and Identity models
├── LoggerService/        # Custom logging provider and middleware implementations
├── Repository/           # Dapper execution context, Stored Procedure calls, and SQL queries
├── RFK/                  # Web API entry point, DI container, appsettings, and Program.cs
├── RFK.Presentation/     # External controller assembly for decoupled REST endpoints
├── Service/              # Core business logic implementations and orchestration
├── Service.Contracts/    # Service layer interfaces for business operations
├── Shared/               # Cross-cutting concerns, Request Parameters (Paging, Filtering, Search, Sorting)
└── README.md