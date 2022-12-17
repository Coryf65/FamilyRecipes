using Microsoft.Azure.Cosmos;

namespace FamilyRecipes.API.Repositories;

public interface IDBConnector
{
	public CosmosClient CosmosClient { get; }
	public Database Database { get; }
	public Container Container { get; }
}