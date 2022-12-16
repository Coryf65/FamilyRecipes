using Microsoft.Azure.Cosmos;

namespace FamilyRecipes.API.Data;

public class DataAccess
{
	// CORY testing to learn about Cosmos DB
	CosmosClient CosmosClient { get; set; }

	public DataAccess(CosmosClient cosmosClient)
	{
		CosmosClient = cosmosClient;

		//// New instance of CosmosClient class
		//using CosmosClient client = new(
		//	accountEndpoint: Environment.GetEnvironmentVariable("COSMOS_ENDPOINT")!,
		//	authKeyOrResourceToken: Environment.GetEnvironmentVariable("COSMOS_KEY")!
		//);
	}

	public string Test1()
	{
		Database database = CosmosClient.GetDatabase("ToDoList");

		return database.Id;
	}
}

