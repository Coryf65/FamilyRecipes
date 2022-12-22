using AutoMapper;
using FamilyRecipes.API.DTOs;
using FamilyRecipes.API.Models;

namespace FamilyRecipes.API.Configurations;

/// <summary>
/// A Class Mapper using AutoMapper
/// </summary>
public class MapperConfig : Profile
{
	/// <summary>
	/// Maps our DTOS into our classes
	/// </summary>
	public MapperConfig()
	{
		CreateMap<RecipeDto, Recipe>().ReverseMap();
		CreateMap<IngredientDto, Ingredient>().ReverseMap();
	}
}