using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace FamilyRecipes.API.Models;

/// <summary>
/// An object that represents a Recipe
/// </summary>
public record Recipe
{
    /// <summary>
    /// The ID for this Recipe as a GUID
    /// </summary>
    [Key]
	[JsonProperty(PropertyName = "id")]
	public Guid Id { get; set; }

	/// <summary>
	/// The Date Time this recipe was added into the DB, in UTC
	/// </summary>
	[JsonProperty(PropertyName = "createdDateUTC")]
	public DateTime CreatedDateUTC { get; set; }

	[JsonProperty(PropertyName = "name")]
	public string Name { get; set; }

	[JsonProperty(PropertyName = "author")]
	public string Author { get; set; }

	/// <summary>
	/// If available the orginal URL for the Recipe
	/// </summary>
	[JsonProperty(PropertyName = "url")]
	public string URL { get; set; }

	// TODO: Need to figure how to store images in cosmosdb / return them, maybe as binary data?
	///// <summary>
	///// Some Glamor shot / Images of this recipe in process or done
	///// </summary>
	//public Image[] Images { get; set; }

	[JsonProperty(PropertyName = "description")]
	public string Description { get; set; }

	/// <summary>
	/// Total Time it takes to Prep in Minutes
	/// </summary>
	[JsonProperty(PropertyName = "prepTimeMins")]
	public int PrepTimeMins { get; set; }

	/// <summary>
	/// Total time it takes to Cook in Minutes
	/// </summary>
	[JsonProperty(PropertyName = "cookTimeMins")]
	public int CookTimeMins { get; set; }

	/// <summary>
	/// Total time all together to complete this recipe
	/// </summary>
	[JsonProperty(PropertyName = "totalTimeMins")]
	public int TotalTimeMins { get; set; }

	/// <summary>
	/// Your Rating of this Recipe
	/// </summary>
	[JsonProperty(PropertyName = "rating")]
	public double Rating { get; set; }

	[JsonProperty(PropertyName = "ingredients")]
	public Ingredient[] Ingredients { get; set; }

	[JsonProperty(PropertyName = "instructions")]
	public string[] Instructions { get; set; }
}