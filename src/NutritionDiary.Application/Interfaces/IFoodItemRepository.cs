using NutritionDiary.Domain.Entities;
using NutritionDiary.Domain.Enums;

namespace NutritionDiary.Application.Interfaces
{
    public interface IFoodItemRepository
    {
        Task<FoodItem?> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task<Product?> GetBySourceAndExternalIdAsync(Source source, string externalId, CancellationToken cancellationToken);
    }
}
