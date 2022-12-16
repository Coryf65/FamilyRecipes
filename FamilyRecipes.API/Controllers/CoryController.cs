using Azure;
using FamilyRecipes.API.Models;
using FamilyRecipes.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;

namespace FamilyRecipes.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CoryController : ControllerBase
{
	private readonly ILogger<CoryController> _logger;
	private readonly IDBConnector _repository;

	public CoryController(ILogger<CoryController> logger, IDBConnector cosmosDB)
	{
		_logger = logger;
		_repository = cosmosDB;
	}

	[HttpGet(Name = "GetDBInfo")]
	public async Task<ActionResult<List<Recipe>>> GetAsync()
	{
		using FeedIterator<Recipe> feed = _repository.Container.GetItemQueryIterator<Recipe>(
			queryText: "SELECT * FROM recipe"
		);

		// Iterate query result pages
		while (feed.HasMoreResults)
		{
			FeedResponse<Recipe> response = await feed.ReadNextAsync();

			// Iterate query results
			foreach (Recipe item in response)
			{
				Console.WriteLine($"Found item:\t{item.Name}");
			}

			return Ok(response);
		}

		return NotFound("No Recipes found");
	}

	//[HttpGet("{id}")]
	//public ActionResult<Recipe> GetRecipe(Guid id)
	//{
	//	// use cosmos connection

	//	// get recipe by guid

	//	// return recipe

	//	return Ok(null);
	//}


	// ActionResult<Recipe>
	[HttpGet("{id}")]
	public async Task<ActionResult<List<Recipe>>> GetRecipe(Guid id)
	{
		string sqlCosmosQuery = "SELECT top 1 * FROM recipe";

		// use cosmos connection
		var query = _repository.Container.GetItemQueryIterator<Recipe>(sqlCosmosQuery);

		// get recipe by guid
		List<Recipe> results = new();
		
		while (query.HasMoreResults)
		{
			var response = await query.ReadNextAsync();
			results.AddRange(response);
		}

		if (results is null)
			return NotFound("The thingy not findy");

		// return recipe
		return Ok(results);
	}

	[HttpGet("Get2")]
	public async Task<IActionResult> Get2()
	{
		var sqlCosmosQuery = "select * from c"; // c is an alais
		var result = await _repository.
			

		return Ok();
	}
}
