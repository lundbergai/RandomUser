# RandomUser API

ASP.NET Core API with MSSQL database running in Docker (Azure SQL Edge for Mac M1).

## Quick Start

```bash
# 1. Start database container
docker-compose up -d

# 2. Run the application (auto-creates database & seeds data)
dotnet run --project RandomUser.Api

# 3. Open Swagger
# http://localhost:5194/swagger
```

## Container Management

```bash
# Check container status
docker-compose ps

# View logs
docker logs randomuser-mssql

# Stop container
docker-compose down

# Stop and remove all data
docker-compose down -v
```

## Connection Details

-   **Server**: localhost,1433
-   **Database**: RandomUserDb
-   **User**: sa
-   **Password**: Passw0rd@123

## Database

Database is automatically created on first run using `EnsureCreatedAsync()` and seeded with data from `RandomUser.Infrastructure/Seed/randomUser.json`.

To reset database: stop app, run `docker-compose down -v`, then start again.
