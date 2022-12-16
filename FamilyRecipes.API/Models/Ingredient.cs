namespace FamilyRecipes.API.Models;

public record Ingredient
{
    public Guid Id { get; init; }
    public string Name { get; set; }
    public string Amount { get; set; }
}