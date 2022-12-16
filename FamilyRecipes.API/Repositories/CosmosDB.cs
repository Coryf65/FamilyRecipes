using Microsoft.Azure.Cosmos;

namespace FamilyRecipes.API.Repositories;

public class CosmosDB : IDBConnector
{
	private readonly IConfiguration _config;
	public string EndPointUrl { private get; init; }
	public string ApiKey { private get; init; }

	// The Cosmos client instance
	public CosmosClient CosmosClient { get; private set; }
	private string DatabaseName => "familyrecipes";
	private string ContainerName => "Recipe";

	public Database Database { get; private set; }

	public Container Container { get; private set; }

	public CosmosDB(IConfiguration configuration)
	{
		_config = configuration;
		EndPointUrl = _config["EndpointUri"];
		ApiKey = _config["PrimaryKey"];
		//_connectionString = $"{EndPointUrl}{ApiKey}";
		ConnectToDB();
	}


	// Connect to DB
	private void ConnectToDB()
	{
		Console.WriteLine("Connecting to db");
		CosmosClient = new(EndPointUrl, ApiKey);

		CosmosClient.CreateDatabaseIfNotExistsAsync(id: ContainerName).Wait();

		Database = CosmosClient.GetDatabase(DatabaseName);
		Container = CosmosClient.GetContainer(DatabaseName, ContainerName);
		Console.WriteLine($"Connection good : {Database} {Container}");
	}
	
	
	// was part of hosted works to connect but not needed
	//public Task StartAsync(CancellationToken cancellationToken)
	//{
	//	// setup the connection
	//	Console.WriteLine("Starting Async Cosmos DB...");

	//	CosmosClientCon = new(EndPointUrl, ApiKey);

	//	Console.WriteLine("Connected...");

	//	_database = CosmosClientCon.GetDatabase(_databaseName);

	//	_container = CosmosClientCon.GetContainer(_containerName, _database.Id);

	//	Console.WriteLine($"databse id = {_database.Id} container id = {_container.Id}");

	//	return Task.CompletedTask;
	//}

	//public Task StopAsync(CancellationToken cancellationToken)
	//{
	//	// Stop the connection
	//	Console.WriteLine("STOPPING Async Cosmos DB...");

	//	CosmosClientCon = null;

	//	return Task.CompletedTask;
	//}
}
