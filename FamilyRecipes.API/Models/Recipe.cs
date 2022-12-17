using System.Drawing;

namespace FamilyRecipes.API.Models;

/// <summary>
/// An object that represents a Recipe
/// </summary>
public record Recipe
{
    /// <summary>
    /// The ID for this Recipe as a GUID
    /// </summary>
    public Guid Id { get; init; } // init allows set on init but not after
	/// <summary>
	/// The Date Time this recipe was added into the DB, in UTC
	/// </summary>
	public DateTime CreatedDateUTC { get; set; }
    /// <summary>
    /// The Recipes Name
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// The Author / Person whom created this Recipe
    /// </summary>
    public string Author { get; set; }
    /// <summary>
    /// If available the orginal URL for the Recipe
    /// </summary>
    public string URL { get; set; }
    /// <summary>
    /// Some Glamor shot / Images of this recipe in process or done
    /// </summary>
    public Image[] Images { get; set; }
    /// <summary>
    /// A Description of what this Recipe is
    /// </summary>
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
    /// <summary>
    /// All Ingredients this recipe needs to complete
    /// </summary>
    public Ingredient[] Ingredients { get; set; }
    /// <summary>
    /// A step by step instructions how to make / cook
    /// </summary>
    public string[] Instructions { get; set; }
}