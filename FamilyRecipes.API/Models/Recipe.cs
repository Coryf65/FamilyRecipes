using System.Drawing;

namespace FamilyRecipes.API.Models;

public record Recipe
{
    public Guid Id { get; init; } // init allows set on init but not after
    public DateTime CreatedDateUTC { get; set; }
    public string Name { get; set; }
    public string Author { get; set; }
    public string URL { get; set; }
    public Image[] Images { get; set; }
    public string Description { get; set; }
    public int PrepTimeMins { get; set; }
    public int CookTimeMins { get; set; }
    public int TotalTimeMins { get; set; }
    public double Rating { get; set; }
    public Ingredient[] Ingredients { get; set; }
    public string[] Instructions { get; set; }
}