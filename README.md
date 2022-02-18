# EFCore Training/Test project

## Description
- This is a test only project
- Using .net core 6 and Entity Framework Core 6.0.2

## Environment
- Using SQL Server on Docker
```
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=yourStrong(!)Password" -e "MSSQL_PID=Express" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2019-latest 
```

- Using secrets.json to store ConnectionString
```
{
  "db-connection-string": "Data Source=localhost;Initial Catalog=your-db-name;Persist Security Info=True;User ID=user-here;Password=your-string-password-here"
}
```


## WebApi

To run this project, use the command line:
```
dotnet run
```

... or Open in Visual Studio 2022 and press F5
