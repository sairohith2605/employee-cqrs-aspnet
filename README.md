# Employee Management Service

An ASP.NET Core 10 Web API orchestrated with .NET Aspire, using SQL Server for persistence and Keycloak for authentication.

## Project Structure

```
EmployeeManagement.sln
├── EmployeeManagement.AppHost          # Aspire orchestrator (entry point)
├── EmployeeManagement.ServiceDefaults  # Shared config: OpenTelemetry, health checks, resilience
└── EmployeeManagementService           # ASP.NET Core Web API
```

## Infrastructure (managed by Aspire)

| Resource    | Details                                                              |
|-------------|----------------------------------------------------------------------|
| SQL Server  | Container-based, database name `Employees`                           |
| Keycloak    | Container on port `8080`, realm auto-imported on startup, data volume persisted |

## Authentication

Keycloak is configured with the `employee-management` realm, imported automatically from `EmployeeManagement.AppHost/KeycloakConfiguration/employee-management-realm.json`.

**Client:** `employee-management-api` (confidential, OpenID Connect)

**Realm roles:** `admin`, `manager`, `employee`

### Development Test Users

| Username   | Password   | Role       |
|------------|------------|------------|
| `admin`    | `admin`    | admin      |
| `manager`  | `manager`  | manager    |
| `employee` | `employee` | employee   |

> These credentials are for local development only.

## Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- [Docker](https://www.docker.com/) (required by Aspire for SQL Server and Keycloak containers)
- [.NET Aspire workload](https://learn.microsoft.com/dotnet/aspire/fundamentals/setup-tooling) &mdash; install with:
  ```bash
  dotnet workload install aspire
  ```

## Getting Started

```bash
# Clone and run
dotnet run --project EmployeeManagement.AppHost
```

Aspire starts the SQL Server and Keycloak containers, waits for them to be healthy, then launches the API. The Aspire dashboard URL is printed to the console on startup — open it to view resource status, logs, traces, and metrics.

## Key Endpoints

| Endpoint        | Description              |
|-----------------|--------------------------|
| `/openapi/v1.json` | OpenAPI spec (dev only) |
| `/health`       | Health check             |
| `/alive`        | Liveness probe           |

## Tech Stack

- **Framework:** ASP.NET Core 10
- **Orchestration:** .NET Aspire 13.1
- **Database:** SQL Server (via `Aspire.Microsoft.EntityFrameworkCore.SqlServer`)
- **Auth:** Keycloak (via `Aspire.Keycloak.Authentication`)
- **Observability:** OpenTelemetry (traces, metrics, logs)
