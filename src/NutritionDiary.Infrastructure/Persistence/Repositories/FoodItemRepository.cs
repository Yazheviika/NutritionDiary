using NutritionDiary.Application.Interfaces;
using NutritionDiary.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace NutritionDiary.Infrastructure.Persistence.Repositories
{
    public class FoodItemRepository : IFoodItemRepository
    {
        private readonly NutritionDbContext _context;
        public FoodItemRepository(NutritionDbContext context) => _context = context;

        public Task<FoodItem?> GetByIdAsync(int id, CancellationToken cancellationToken)
            => _context.FoodItems.FirstOrDefaultAsync(f => f.Id == id, cancellationToken);
    }
}
