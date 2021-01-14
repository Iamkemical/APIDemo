# Project Name
Student CRUD API

# Description
Student CRUD API is a web API that perform Create, Read, Update and Delete Actions on the Database for a Student Entity.
The project is built using the .Net Core 3.1 (LTS) SDK.

## Features of the API
1. CRUD Operations
2. Repository Pattern.
3. DTOs.
4. Open API Specification.
5. Swagger Documentation.
6. XML Comments.
7. Unit Testing using xUnit & Moq.
8. Logging of errors and exceptions using third-party logging provider e.g NLog.
9. API Versioning.

## API Endpoints
1. GET Endpoint - This endpoint is used to get all the data available on the database.
2. POST Endpoint - This is used for creating new student entity in the database.
3. GET Endpoint - This endpoint fetches resources from the database based on the id passed.
4. PATCH Endpoint - This endpoint is used for partially updating parts of the resources.
5. PUT Endpoint - This endpoint is used in updating any part of the resource.
6. DELETE Endpoint - This endpoint is used to delete any resource in the database by passing the id.

## Student Entity
The internal data access layer (Model) comprises of:
1. StudentID
2. Firstname
3. Lastname
4. Email
5. PhoneNumber

## Logging Errors to a file
The API performs error logging using an integrated logging provider, NLog, this helps with logging errors to a file on the local machine.
See Documentation for more information on how to use NLog (https://github.com/NLog/NLog)

## Unit testing with xUnit and Moq
Unit testing is integrated into the application using popular unit testing libraries, xUnit and Moq.

## API Versioning 
API Versioning was integrated into the project so you can have different versions of the API all running concurrently on Swagger.

## XML Comments
The API also has XML Comments on relevant methods, actions and controllers for the purpose of clarity.

## Deployment
The API was deployed to AWS Elastic Beanstalk while the MSSQL Database was deployed to AWS RDS.

# Installation
## Visual Studio
1. Clone the project on your local computer or download as Zip folder. 
2. Open the .sln project. 
3. Add Migrations and Update Database on the Package Manager Console.
``` C#
add-migration <migrationname>

update-database
```
4. Build project.
5. Run project.

## Visual Studio Code
1. Clone the project on your local computer or download as Zip folder. 
2. Using the Command Prompt go to the directory of the project.
3. Open the project at the root of the folder.
4. Add Migrations and Update Database on the Terminal.
``` C#
dotnet add migration <migrationname>

dotnet update database
```
5. Clean the project using
``` C#
dotnet clean
```
6. Build project on the command line
``` C#
dotnet build
```
7. Run project.
``` C#
dotnet run
```

# Support
If you want to see the .NET documentation for building APIs using EntityFramework code first migration you can visit https://docs.microsoft.com/en-us/aspnet/core/?view=aspnetcore-5.0

# Contributing
The project is open to collaboration and is fully open-source.

# Contributor
Isaac Gabriel

# License
MIT

# Project Status
Currently there are no new features to add to the API. But the project would be migrated  to .NET 5.
