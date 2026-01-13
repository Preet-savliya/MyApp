1. Project Creation and Setup
Run these commands in your terminal to create the project and move into its folder:

dotnet new webapi -n MyApp
cd MyApp



2. Package Installation
Run these commands to install the necessary libraries for CQRS, EF Core, and Validation:

dotnet add package MediatR
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package FluentValidation.AspNetCore
dotnet add package FluentValidation.DependencyInjectionExtensions



3. Database Migration Commands
Run these commands once you have finished writing your Model and DbContext classes to build the database:

1. Create the migration file
dotnet ef migrations add InitialCreate

2. Apply to the database
dotnet ef database update

dotnet ef migrations add AddCategoryTable
dotnet ef database update

dotnet ef migrations remove
dotnet ef migrations add InitialCreateWithSeed
dotnet ef database update

dotnet ef migrations add AddMoreSeedData
dotnet ef database update

dotnet ef migrations add BulkSeedData
dotnet ef database update

dotnet ef migrations add AddNamedSeedData
dotnet ef database update

dotnet ef migrations add AddFullProductData
dotnet ef database update

dotnet ef migrations add UpdateProductPrices
dotnet ef database update
