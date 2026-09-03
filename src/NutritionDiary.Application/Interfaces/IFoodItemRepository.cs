using NutritionDiary.Domain.Entities;

namespace NutritionDiary.Application.Interfaces
{
    public interface IFoodItemRepository
    {
        Task<FoodItem?> GetByIdAsync(int id, CancellationToken cancellationToken);
    }
}
