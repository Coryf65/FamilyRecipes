# FamilyRecipes

🚧 Currently under Development 🚧

- This will be an app to save and share recipes that my family uses. Now they can all be in one singular spot not all over the place!

tools
- [Serilog](https://serilog.net/) for logging
- [Swagger](https://swagger.io/) testing the api / Documenting it
- [Postman](https://www.postman.com/) for more in depth testing of my API
- [CosmosDB](https://azure.microsoft.com/en-us/products/cosmos-db/) [docs](https://learn.microsoft.com/en-us/azure/cosmos-db/nosql/) for the Database layer, this is new to me so still learning this

> I may not use Seq
- [Seq](https://datalust.co/seq) for parsing through logs can read logs from many apps

architecture
- FamilyRecipes.API -> .NET6 Web API
- FamilyRecipes.WebApp -> a Blazor Web App for users to interact with the API
- Cosmos DB on Azure

## 