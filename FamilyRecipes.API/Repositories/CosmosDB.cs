using FamilyRecipes.API.Interfaces;
using Microsoft.Azure.Cosmos;

namespace FamilyRecipes.API.Repositories;

public class CosmosDB : IDBConnector
{	
	public CosmosClient CosmosClient { get; private set; }
	public Database Database { get; private set; }
	public Container Container { get; private set; }

	private string EndPointUrl { get; init; }
	private string ApiKey { get; init; }
	private static string DatabaseName => "familyrecipes";
	private static string ContainerName => "Recipe";	
	private readonly IConfiguration _config;
	private readonly ILogger<CosmosDB> _log;

	/// <summary>
	/// Sets up start of Cosmos DB settings. Then connects us to our DB.
	/// </summary>
	/// <param name="configuration">Our Configuration</param>
	public CosmosDB(IConfiguration configuration, ILogger<CosmosDB> logger)
	{
		_config = configuration;
		_log = logger;

		EndPointUrl = _config["EndpointUri"];
		ApiKey = _config["PrimaryKey"];
		
		ConnectToDB();
	}

	/// <summary>
	/// Sets up our Cosmos DB connection and this class.
	/// </summary>
	private void ConnectToDB()
	{
		if (string.IsNullOrEmpty(EndPointUrl) || string.IsNullOrEmpty(ApiKey))
		{
			_log.LogError("Not able to connect to our Cosmos DB. Missing the EndpointURL or API Key.");
			throw new Exception("Connection to the Cosmos DB Error. please check Logs");
		}

		CosmosClient = new(EndPointUrl, ApiKey);

		CosmosClient.CreateDatabaseIfNotExistsAsync(id: DatabaseName).Wait();
		Database = CosmosClient.GetDatabase(DatabaseName);
		Container = CosmosClient.GetContainer(DatabaseName, ContainerName);

		_log.LogInformation("Connection to Cosmos DB success.");
	}
}