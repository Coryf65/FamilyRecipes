using Microsoft.Azure.Cosmos;

namespace FamilyRecipes.API.Data;

public class DataAccess
{
	// CORY testing to learn about Cosmos DB
	CosmosClient CosmosClient { get; init; }

	public DataAccess(CosmosClient cosmosClient)
	{
		CosmosClient = cosmosClient;
	}

	public string Test1()
	{
		Database database = CosmosClient.GetDatabase("ToDoList");

		return database.Id;
	}
}

