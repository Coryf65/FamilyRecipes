using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace FamilyRecipes.API.Models;

public record Ingredient
{
	[Key]
	[JsonProperty(PropertyName = "id")]
	public Guid Id { get; set; }
	[JsonProperty(PropertyName = "name")]
	public string Name { get; set; }
	[JsonProperty(PropertyName = "amount")]
	public string Amount { get; set; }
}