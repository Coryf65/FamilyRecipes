using System.Net.Http;
using System.Text.Json;
using FamilyRecipes.WebApp.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.Net.Http.Headers;

namespace FamilyRecipes.WebApp.Data;

public class RecipeService
{

    private HttpClient _httpClient;

    // cory simple method of getting recipe
    public async void GetRecipe()
    {
        //string baseUrl = configuration["DataverseConfig:BaseUri"];
        string baseUrl = "https://localhost:7114";

        // Get the HttpClient
        _httpClient = HttpClientFactory.CreateClient();

        // Send the request
        var dataRequest = await _httpClient.GetAsync($"{baseUrl}api/data/v9.2/WhoAmI");
    }

    public IEnumerable<RecipeModel>? Recipe { get; set; }

    public async Task<RecipeModel> GetRecipeByID(string guid = "11ab1d8c-0605-47c9-8879-a45a89da63b5")
    {
        var client = ClientFactory.CreateClient("recipeapi");
       
        Recipe = await client.GetFromJsonAsync<IEnumerable<RecipeModel>>($"/api/Recipe/{guid}");

        return (RecipeModel)Recipe;
    }



    // Get all recipes 


    // get recipe by name


    // get recipe by author


    // save recipe


    // update recipe


    // delete recipe
}