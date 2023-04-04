using FamilyRecipes.WebApp.Models;

namespace FamilyRecipes.WebApp.Data;

/// <summary>
/// Service that will handle Recipe calls to API
/// </summary>
public class RecipeService
{
    private HttpClient _httpClient;

    public RecipeService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    /// <summary>
    /// Demo Method to pull one recipe, bbq chicken
    /// </summary>
    /// <returns>One BBQ Chicken Recipe that is used for testing</returns>
    public async Task<RecipeModel> GetBBQRecipe()
    {
        // Send the request
        var dataRequest = await _httpClient.GetFromJsonAsync<RecipeModel>("/api/Recipe/11ab1d8c-0605-47c9-8879-a45a89da63b5");

        return dataRequest;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="guid"></param>
    /// <returns></returns>
    public async Task<RecipeModel> GetRecipeByID(string guid)
    {
        var recipe = await _httpClient.GetFromJsonAsync<RecipeModel>($"/api/Recipe/{guid}");

        return recipe;
    }


    // Get all recipes


    // get recipe by name


    // get recipe by author


    // save recipe


    // update recipe


    // delete recipe
}