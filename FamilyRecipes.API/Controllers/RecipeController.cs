using FamilyRecipes.API.Models;
using FamilyRecipes.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FamilyRecipes.API.Controllers;

/// <summary>
/// The Controller to handle actions with the Recipes and DB
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class RecipeController : ControllerBase
{
	private readonly ILogger<RecipeController> _log;
	private readonly ICosmosService _cosmosDbService;

	/// <summary>
	/// Recipe Constructor to get DI items
	/// </summary>
	/// <param name="logger"></param>
	/// <param name="cosmosDbService"></param>
	public RecipeController(ILogger<RecipeController> logger, ICosmosService cosmosDbService)
	{
		_log = logger;
		_cosmosDbService = cosmosDbService;
	}

	/// <summary>
	/// Lists all available Recipes
	/// </summary>
	/// <returns></returns>
	/// <response code="200">Returns the Recipes JSON data</response>
	/// <response code="400">Returns if No Recipes are found</response>
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	[HttpGet]
	public async Task<IActionResult> List()
	{
		//return Ok(await _cosmosDbService.GetMultipleAsync("select * from c"));

		IEnumerable<Recipe> result = await _cosmosDbService.GetMultipleAsync("select * from c");

		if (result is null)
			return BadRequest("No Recipes found.");

		return Ok(result);
	}

	/// <summary>
	/// Gets a Recipe by the GUID
	/// </summary>
	/// <param name="id">The Recipes id / GUID</param>
	/// <returns>The Recipe found or Not Found</returns>
	[HttpGet("{id}")]
	public async Task<IActionResult> Get(Guid id)
	{
		Recipe result = await _cosmosDbService.GetAsync(id);

		if (result is null)
			return NotFound($"No Recipes found with id: '{id}'");

		return Ok(result);
	}
}