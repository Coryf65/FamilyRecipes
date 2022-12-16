using Microsoft.Azure.Cosmos;

namespace FamilyRecipes.API.Repositories;

public interface IDBConnector
{
	public string EndPointUrl { init; }
	public string ApiKey { init; }
	public CosmosClient CosmosClient { get; }
	public Database Database { get; }
	public Container Container { get; }
}