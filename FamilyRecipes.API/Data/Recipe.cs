using System.Drawing;

namespace FamilyRecipes.API.Data;

public class Recipe
{
	public int Id { get; set; }
	public string Name { get; set; }
	public Image[] Images { get; set; }
	public string Author { get; set; }
	public string URL { get; set; }
	public string Description { get; set; }
	public int PrepTime { get; set; }
	public int CookTime { get; set; }
	public int TotalTime { get; set; }
	public double Rating { get; set; }
	public Ingredient[] Ingredients { get; set; }
	public string[] Instructions { get; set; }
}