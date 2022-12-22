using FamilyRecipes.API.Models;
using System.ComponentModel.DataAnnotations;

namespace FamilyRecipes.API.DTOs;

/// <summary>
/// The DTO for the <c>Recipe</c>
/// </summary>
public class RecipeDto
{
	/// <summary>
	/// The Author / Person whom created this Recipe
	/// </summary>
	[Required]
	public string Name { get; set; }

	/// <summary>
	/// A Description of what this Recipe is
	/// </summary>
	[Required]
	public string Description { get; set; }

	/// <summary>
	/// Person whom created this Recipe
	/// </summary>
	[Required]
	public string Author { get; set; }

	/// <summary>
	/// All Ingredients this recipe needs to complete
	/// </summary>
	public Ingredient[] Ingredients { get; set; }

	/// <summary>
	/// A step by step instructions how to make / cook
	/// </summary>
	public string[] Instructions { get; set; }
}