using FamilyRecipes.API.Models;
using Microsoft.Azure.Cosmos;

namespace FamilyRecipes.API.Repositories;

/// <summary>
/// <c>CosmosService</c> handles the calling CosmosDB CRUD actions
/// </summary>
public class CosmosService : ICosmosService
{
	private Container _container;
	private ILogger<CosmosService> _log;

	/// <summary>
	/// Setup the class to bring in the logger, and Cosmos Container to operate with
	/// </summary>
	/// <param name="logger"></param>
	/// <param name="dBConnector"></param>
	public CosmosService(ILogger<CosmosService> logger, IDBConnector dBConnector)
	{
		_log = logger;
		_container = dBConnector.Container;
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="recipe"></param>
	/// <returns></returns>
	public async Task AddAsync(Recipe recipe)
	{
		await _container.CreateItemAsync(recipe, new PartitionKey(recipe.Id.ToString()));
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="id"></param>
	/// <returns></returns>
	public async Task DeleteAsync(Guid id)
	{
		await _container.DeleteItemAsync<Recipe>(id.ToString(), new PartitionKey(id.ToString()));
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="id"></param>
	/// <returns></returns>
	public async Task<Recipe> GetAsync(Guid id)
	{
		try
		{
			var response = await _container.ReadItemAsync<Recipe>(id.ToString(), new PartitionKey(id.ToString()));
			return response.Resource;
		}
		catch (CosmosException error) //For handling item not found and other exceptions
		{
			_log.LogError("GetAsync(string id) Error: {errorMessage}: {errorException}: {errorStackTrace}", error.Message, error.InnerException, error.StackTrace);
			return null;
		}
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="query"></param>
	/// <returns></returns>
	public async Task<IEnumerable<Recipe>> GetMultipleAsync(string query)
	{
		var sql = _container.GetItemQueryIterator<Recipe>(new QueryDefinition(query));
		var results = new List<Recipe>();
		while (sql.HasMoreResults)
		{
			var response = await sql.ReadNextAsync();
			results.AddRange(response.ToList());
		}
		return results;
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="id"></param>
	/// <param name="recipe"></param>
	/// <returns></returns>
	public async Task UpdateAsync(Guid id, Recipe recipe)
	{
		await _container.UpsertItemAsync(recipe, new PartitionKey(id.ToString()));
	}
}