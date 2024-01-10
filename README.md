# Packages

    - dotnet add package Swashbuckle.AspNetCore
    - dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
    - dotnet add package Microsoft.EntityFrameworkCore.Design

# Create and Apply Migrations

    - dotnet ef migrations add InitialCreate
    - dotnet ef database update

# Global Framework installation

    - dotnet tool install --global dotnet-ef

# Gitignore file

    - Important: Added most of the files in obj, because theese are use specific
