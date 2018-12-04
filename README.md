## Create Initial Projects

Core        - .NET Core Class Library
API         - .NET Core Web Api
Test        - .Net Core MSTest
Database    - Database Project

## Add Swagger for API Documentation

1. Add the NuGet Package

```
dotnet add package Swashbuckle.AspNetCore
```

2. Setup in Startup.cs ConfigureServices

```c#
services.AddMvc();

services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});
```

3. Setup in Startup.cs Configure
```c#
app.UseSwagger();

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
});
```

4. Add Serilog for Console and SQL Logging

```
dotnet add package Serilog.AspNetCore
dotnet add package Serilog.Settings.Configuration
dotnet add package Serilog.Sinks.Console
dotnet add package Serilog.Sinks.MssqlServer
```

5. Delete Logging sections from Appsettings.json and Appsettings.development.json

6. Add Serilog Configuration to Appsettings.json

```json
"Serilog": {
    "MinimumLevel": "Information",
    "WriteTo": [
      {
        "Name": "MSSqlServer",
        "Args": {
          "connectionString": "Server=127.0.0.1;Database=Data;User Id=SERILOG;Password=password123;",
          "tableName": "Logs",
          "autoCreateSqlTable": false
        }
      },
      {
        "Name": "Console",
        "Args": {}
      }
    ]
```
7. Create SQL Table for Serilog (column names are case sensitive)

```sql

CREATE LOGIN [SERILOG] WITH PASSWORD = N'password123*', DEFAULT_LANGUAGE = [us_english];


CREATE TABLE [Logs] (

   [Id] int IDENTITY(1,1) NOT NULL,
   [Message] nvarchar(max) NULL,
   [MessageTemplate] nvarchar(max) NULL,
   [Level] nvarchar(128) NULL,
   [TimeStamp] datetime NOT NULL,
   [Exception] nvarchar(max) NULL,
   [Properties] nvarchar(max) NULL

   CONSTRAINT [PK_Logs] PRIMARY KEY CLUSTERED ([Id] ASC) 
);


CREATE USER [SERILOG] FOR LOGIN [SERILOG];

GO
GRANT INSERT
    ON OBJECT::[dbo].[Logs] TO [SERILOG]
    AS [dbo];


GO
GRANT SELECT
    ON OBJECT::[dbo].[Logs] TO [SERILOG]
    AS [dbo];
    
```

8. Add Serilog to Program.cs
```c#
    public class Program
    {
        // Get the appsettings.json for the current project
        public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
                    .Build();

        public static void Main(string[] args)
        {
            // Create the logger from the appsettings.json
            Log.Logger = new LoggerConfiguration()
                .ReadFrom
                .Configuration(Configuration)
                .CreateLogger();

            try
            {
                Log.Information("Starting host.");

                CreateWebHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Error starting host.");
            }
            finally
            {
                Log.Information("Shutting down host.");

                Log.CloseAndFlush();
            }

            
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .UseSerilog()
            .UseStartup<Startup>();
    }
}
```
9. Configure CORS in Startup.cs Configure

```c#
app.UseCors(c => c.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
```
10. Add Dapper ORM to Core Project

```
dotnet add package Dapper
```

EntityBase

All items will have an Id and DateTimeCreated property, this will be inhe=rited from the EntityBase class. Additionally, overiding the ToString() fungtion to return a JSON formatted string makes reading test results easier.

dotnet add package NewtonSoft.Json

```c#
    public class EntityBase
    {
        public Guid Id { get; set; }

        public DateTime CreateDateTime { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
```



## Creating the Angular Application
npm install -g @angular/cli@latest

cd C:\Git\dontnetcore-api-angular-template

ng new template --routing --directory web

###References
1. https://github.com/domaindrivendev/Swashbuckle.AspNetCore
2. https://github.com/serilog/
3. http://hamidmosalla.com/2018/02/15/asp-net-core-2-logging-with-serilog-and-microsoft-sql-server-sink/
4. https://code-maze.com/net-core-web-development-part1/
5.  https://code-maze.com/net-core-web-development-part2/
6. https://code-maze.com/net-core-web-development-part3/
7. https://code-maze.com/net-core-web-development-part4/
