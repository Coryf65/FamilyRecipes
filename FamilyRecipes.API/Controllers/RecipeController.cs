using AutoMapper;
using FamilyRecipes.API.DTOs;
using FamilyRecipes.API.Interfaces;
using FamilyRecipes.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace FamilyRecipes.API.Repositories;

/// <summary>
/// The Controller to handle actions with the Recipes and DB
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class RecipeController : ControllerBase
{
	private readonly ILogger<RecipeController> _log;
	private readonly ICosmosService _cosmosDbService;
	private readonly IMapper _mapper;

	/// <summary>
	/// Recipe Constructor to get DI items
	/// </summary>
	/// <param name="logger"></param>
	/// <param name="cosmosDbService"></param>
	public RecipeController(ILogger<RecipeController> logger, ICosmosService cosmosDbService, IMapper mapper)
	{
		_log = logger;
		_cosmosDbService = cosmosDbService;
		_mapper = mapper;
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
	public async Task<ActionResult> List()
	{
		//return Ok(await _cosmosDbService.GetMultipleAsync("select * from c"));

		IEnumerable<Recipe> result = await _cosmosDbService.GetMultipleAsync("select * from c");

		if (result is null)
			return NotFound("No Recipes found.");

		return Ok(result);
	}

	/// <summary>
	/// Gets a Recipe by the GUID
	/// </summary>
	/// <param name="id">The Recipes id / GUID</param>
	/// <returns>The Recipe found or Not Found</returns>
	[HttpGet("{id}")]
	public async Task<ActionResult> Get(Guid id)
	{
		Recipe result = await _cosmosDbService.GetAsync(id);

		if (result is null)
			return NotFound($"No Recipes found with id: '{id}'");

		return Ok(result);
	}

	/// <summary>
	/// Create a new Recipe
	/// </summary>
	/// <param name="recipeDto">All Recipe Data</param>
	/// <returns></returns>
	[HttpPost]
	public async Task<ActionResult> Create([FromBody] RecipeDto recipeDto)
	{
		var recipe = _mapper.Map<Recipe>(recipeDto);

		recipe.Id = Guid.NewGuid();

		foreach (var i in recipe.Ingredients)
		{
			i.Id = Guid.NewGuid();
		}

		await _cosmosDbService.AddAsync(recipe);
		return CreatedAtAction(nameof(Get), new { id = recipe.Id }, recipe);
	}

	/// <summary>
	/// Update an existing Recipe 
	/// </summary>
	/// <param name="recipe">All Recipe Data</param>
	/// <returns></returns>
	[HttpPut("{id}")]
	public async Task<ActionResult> Edit([FromBody] Recipe recipe)
	{
		await _cosmosDbService.UpdateAsync(recipe.Id, recipe);
		return NoContent();
	}

	/// <summary>
	/// Delete a Recipe by GUID
	/// </summary>
	/// <param name="id"></param>
	/// <returns></returns>
	[HttpDelete("{id}")]
	public async Task<ActionResult> Delete(Guid id)
	{
		await _cosmosDbService.DeleteAsync(id);
		return NoContent();
	}
}