# FamilyRecipes

🚧 Currently under Development 🚧

- This will be an app to save and share recipes that my family uses. Now they can all be in one singular spot not all over the place!

### Tools
- [Serilog](https://serilog.net/) for logging
- [Swagger](https://swagger.io/) testing the api / Documenting it
- [Postman](https://www.postman.com/) for more in depth testing of my API
- [CosmosDB](https://azure.microsoft.com/en-us/products/cosmos-db/) [docs](https://learn.microsoft.com/en-us/azure/cosmos-db/nosql/) for the Database layer, this is new to me so still learning this
- [Bootstrap](https://getbootstrap.com/docs/5.0/getting-started/introduction/) for styling

### Architecture
- FamilyRecipes.API -> .NET6 Web API (MVC style)
- FamilyRecipes.WebApp -> The FrontEnd, a Blazor Web App interacts with the API
- FamilyRecipes.Tests -> the XUnit part to run tests on my project
- Cosmos DB on Azure -> The NOSQL DB to store data

#### TODOs
- add in Authentication and Authorization [docs](https://learn.microsoft.com/en-us/aspnet/core/blazor/security/server/?view=aspnetcore-7.0&tabs=visual-studio)
- demo images from [lorem picsum](https://picsum.photos/)
- Add links to images in the NOSQL document that ties to Azure Blob storage