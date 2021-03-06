# Simple Back-End

## Description

This is a solution template for creating a new ASP.NET Core Web API

## Technical applied
- ASP.Net Core Web API
- Entity Framework Core
- MediatR
- Mapster
- FluentValidation
- Authentication: JSON Web Tokens
- XUnit, FluentAssertions, Moq
- Swagger

## Database Migrations
To use dotnet-ef for your migrations please add the following flags to your command (values assume you are executing from repository root)

> --project src/Infrastructure (optional if in this folder)
>
> --startup-project src/Api
>
> --output-dir Migrations (optional)

For example, to add a new migration from the root folder:

`dotnet ef migrations add "InitDb" --project src/Infrastructure --startup-project src/Api`

`dotnet ef database update --project src/Infrastructure --startup-project src/Api`

## API list
You can take a look at Swagger documents for more information.

https://localhost:5001/swagger/index.html

## Testing user
You can use account below for testing:

> UserName: admin
>
> Password: admin
