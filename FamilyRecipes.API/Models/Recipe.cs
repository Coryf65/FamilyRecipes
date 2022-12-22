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
	public DateTime CreatedDateUTC { get; set; }

    public string Name { get; set; }
	
	public string Author { get; set; }

    /// <summary>
    /// If available the orginal URL for the Recipe
    /// </summary>
    public string URL { get; set; }

    // TODO: Need to figure how to store images in cosmosdb / return them, maybe as binary data?
	///// <summary>
	///// Some Glamor shot / Images of this recipe in process or done
	///// </summary>
	//public Image[] Images { get; set; }

	public string Description { get; set; }

    /// <summary>
    /// Total Time it takes to Prep in Minutes
    /// </summary>
    public int PrepTimeMins { get; set; }

    /// <summary>
    /// Total time it takes to Cook in Minutes
    /// </summary>
    public int CookTimeMins { get; set; }

    /// <summary>
    /// Total time all together to complete this recipe
    /// </summary>
    public int TotalTimeMins { get; set; }

    /// <summary>
    /// Your Rating of this Recipe
    /// </summary>
    public double Rating { get; set; }
    
    public Ingredient[] Ingredients { get; set; }
	
	public string[] Instructions { get; set; }
}