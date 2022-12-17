using FamilyRecipes.API.Models;

namespace FamilyRecipes.API.Repositories;

public interface ICosmosService
{
	Task<IEnumerable<Recipe>> GetMultipleAsync(string query);
	Task<Recipe> GetAsync(Guid id);
	Task AddAsync(Recipe recipe);
	Task UpdateAsync(Guid id, Recipe recipe);
	Task DeleteAsync(Guid id);
}