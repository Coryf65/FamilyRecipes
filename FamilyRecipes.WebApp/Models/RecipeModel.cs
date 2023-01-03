namespace FamilyRecipes.WebApp.Models;

public class RecipeModel
{
    public Guid Id { get; set; }
    public DateTime CreatedDateUTC { get; set; }
    public string Name { get; set; }
    public string Author { get; set; }
    public string Url { get; set; }
    public string Description { get; set; }
    public int PrepTimeMins { get; set; }
    public int CookTimeMins { get; set; }
    public int TotalTimeMins { get; set; }
    public float Rating { get; set; }
    public IngredientModel[] Ingredients { get; set; }
    public string[] Instructions { get; set; }
}