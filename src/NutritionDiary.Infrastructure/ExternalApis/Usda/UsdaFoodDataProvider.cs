using Microsoft.Extensions.Configuration;
using NutritionDiary.Application.DTOs;
using NutritionDiary.Application.Interfaces;
using NutritionDiary.Domain.Entities;
using System.Net.Http.Json;

namespace NutritionDiary.Infrastructure.ExternalApis.Usda
{
    public class UsdaFoodDataProvider : IFoodDataProvider
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _apiKey;

        public UsdaFoodDataProvider(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _apiKey = configuration["ExternalApis:Usda:ApiKey"]!;
        }

        public async Task<Product?> ImportAsync(string externalId, CancellationToken cancellationToken)
        {
            var client = _httpClientFactory.CreateClient("UsdaClient");
            var response = await client.GetAsync($"food/{externalId}?api_key={_apiKey}", cancellationToken);

            if(!response.IsSuccessStatusCode)
            {
                return null;
            }

            var detail = await response.Content.ReadFromJsonAsync<UsdaFoodDetailResponse>(cancellationToken: cancellationToken);
            return detail is null ? null : UsdaMapper.ToProduct(detail);
        }

        public async Task<List<FoodSearchResult>> SearchAsync(string searchTerm, CancellationToken cancellationToken)
        {
            var client = _httpClientFactory.CreateClient("UsdaClient");

            var encodedSearchTerm = Uri.EscapeDataString(searchTerm);
            var response = await client.GetAsync($"foods/search?query={encodedSearchTerm}&api_key={_apiKey}", cancellationToken);

            if(!response.IsSuccessStatusCode)
            {
                return new List<FoodSearchResult>();
            }

            var searchResult = await response.Content.ReadFromJsonAsync<UsdaSearchResponse>(cancellationToken: cancellationToken);

            if (searchResult is null) 
            {
                return new List<FoodSearchResult>();
            }

            return searchResult.Foods.Select(UsdaMapper.ToSearchResult).ToList();
        }
    }
}