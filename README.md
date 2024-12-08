# ToDo
 A simple To-Do backend with APIs, using a local SQL database.

Author: Gibah Anthony

Organization: Gibatekpro


***

[Swagger Url](/swagger/index.html)

### Packages
***
Entity Framework CLI tool - The command-line interface (CLI) tools for Entity Framework Core. [Documentation](https://learn.microsoft.com/en-us/ef/core/cli/dotnet)
```bash
dotnet tool install --global dotnet-ef
```

***
Entity Framework - Data access using a model [Documentation](https://learn.microsoft.com/en-us/ef/core/)

```bash
dotnet add package Microsoft.EntityFrameworkCore
```

***
Entity Framework Tools - Tools for Entity Framework [Documentation](https://learn.microsoft.com/en-us/ef/core/)

```bash
dotnet add package Microsoft.EntityFrameworkCore.Tools
```

***
Entity Framework SQLite - Allows Entity Framework Core to be used with SQLite. [Documentation](https://learn.microsoft.com/en-us/ef/core/providers/sqlite/?tabs=dotnet-core-cli)
```bash
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
```

***
Entity Framework SQL Server - Allows Entity Framework Core to be used with Microsoft SQL Server. [Documentation](https://learn.microsoft.com/en-us/ef/core/)
```bash
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
```

***
ASP.NET Scaffolding - Generates boilerplate code for web apps to speed up development. [Documentation](https://learn.microsoft.com/en-us/ef/core/cli/dotnet)
```bash
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design --version 9.0.0
```

***
Entity Framework Design - The Entity Framework Core tools help with design-time development tasks. [Documentation](https://learn.microsoft.com/en-us/dotnet/api/system.device.location.geocoordinate?view=netframework-4.8.1)
```bash
dotnet add package Microsoft.EntityFrameworkCore.Design --version 9.0.0
```


### Build Tools

***
Add Entity Framework Migrations
```bash
dotnet ef migrations add InitialCreate --context ToDoContext
```

***
Update Database
```bash
dotnet ef database update
```

***
Command to scaffold a controller
```bash
dotnet aspnet-codegenerator controller -name ToDosController -async -api -m ToDoItem -dc ToDoContext -outDir Controllers
```