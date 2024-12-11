# ToDo
 A simple To-Do backend with APIs, using a local SQL database.

Author: Gibah Anthony

Organization: Gibatekpro


***
Using localhost. Change your url accordingly. 
[Swagger Url](http://localhost:5157/swagger/index.html)
<br><br>
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

***
Auto Mapper - Map models and entities. [Documentation](https://docs.automapper.org/en/stable/)
```bash
dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection
```

***
XUnit - For unit tests. [Documentation](https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-dotnet-test)
```bash
dotnet new xunit -n ToDo.Tests
```
```bash
dotnet add ToDo.Tests/ToDo.Tests.csproj reference ToDo/ToDo.csproj
```

***
Entity FrameWork InMemory - Allows Entity Framework Core to be used with an in-memory database. [Documentation](https://learn.microsoft.com/en-us/ef/core/providers/in-memory/?tabs=dotnet-core-cli)
```bash
dotnet add ToDo.Tests package Microsoft.EntityFrameworkCore.InMemory
```

***
Moq - The most popular and friendly mocking library for .NET [Documentation](https://github.com/devlooped/moq)
```bash
dotnet add ToDo.Tests package Moq
```


<br><br>
### Build Tools

***
Add Entity Framework Migrations
```bash
dotnet ef migrations add LocationDecimal --context ToDoContext
```

***
Update Database
```bash
dotnet ef database update
```

***
Command to scaffold a controller
```bash
dotnet aspnet-codegenerator controller -name CategoriesController -async -api -m Category -dc ToDoContext -outDir Controllers
```

<br><br>
### Relevant Data
***
appSettings.json
```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "ConnectionLite": "Data Source=ToDoApiStore.db;"
  },
  "WeatherApi": {
    "BaseUrl": "http://api.weatherapi.com/v1/current.json",
    "ApiKey": "YOUR_API_KEY"
  }
}
```