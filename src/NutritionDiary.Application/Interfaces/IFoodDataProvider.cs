using NutritionDiary.Application.DTOs;
using NutritionDiary.Domain.Entities;

namespace NutritionDiary.Application.Interfaces
{
    public interface IFoodDataProvider
    {
        Task<List<FoodSearchResult>> SearchAsync(string searchTerm, CancellationToken cancellationToken);
        Task<Product?> ImportAsync(string externalId, CancellationToken cancellationToken);
    }
}