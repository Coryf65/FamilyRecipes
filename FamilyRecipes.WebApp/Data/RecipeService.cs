using System.Text.Json;
using FamilyRecipes.WebApp.Models;
using Microsoft.Net.Http.Headers;

namespace FamilyRecipes.WebApp.Data;

public class RecipeService
{
    // cory simple method of getting recipe
    public async void GetRecipe()
    {


        //// Fullway to do this
        //var request = new HttpRequestMessage(
        //    HttpMethod.Get,
        //    "https://localhost:7114/api/Recipe/11ab1d8c-0605-47c9-8879-a45a89da63b5"
        //);

        //HttpClient client = _clientFactory.CreateClient();

        //HttpResponseMessage response = await client.SendAsync(request);

        //if (!response.IsSuccessStatusCode)
        //    error = $"Error getting recipe data: {response.ReasonPhrase}";

        //return await response.Content.ReadFromJsonAsync<RecipeModel>();


    }

    private readonly IHttpClientFactory _httpClientFactory;
    public IEnumerable<RecipeModel>? Recipe { get; set; }

    public async Task OnGet()
    {
        var httpRequestMessage = new HttpRequestMessage(
            HttpMethod.Get,
            "https://localhost:7114/api/Recipe/11ab1d8c-0605-47c9-8879-a45a89da63b5")
        {
            Headers =
            {
                { HeaderNames.Accept, "application/json" },
                { HeaderNames.UserAgent, "BlazorAppCory" }
            }
        };

        var httpClient = _httpClientFactory.CreateClient();
        var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

        if (httpResponseMessage.IsSuccessStatusCode)
        {
            using var contentStream =
                await httpResponseMessage.Content.ReadAsStreamAsync();

            Recipe = await JsonSerializer.DeserializeAsync<IEnumerable<RecipeModel>>(contentStream);
        }
    }



    // Get all recipes 


    // get recipe by name


    // get recipe by author


    // save recipe


    // update recipe


    // delete recipe
}