using Microsoft.Azure.Cosmos;

namespace FamilyRecipes.API.Interfaces;

public interface IDBConnector
{
    public CosmosClient CosmosClient { get; }
    public Database Database { get; }
    public Container Container { get; }
}