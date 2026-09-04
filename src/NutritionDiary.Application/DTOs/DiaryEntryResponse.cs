using NutritionDiary.Domain.Enums;
using NutritionDiary.Domain.ValueObjects;

namespace NutritionDiary.Application.DTOs
{
    public class DiaryEntryResponse
    {
        public int Id { get; set; }
        public string FoodItemName { get; set; }
        public NutritionTotals NutritionTotals { get; set; }
        public double QuantityInG { get; set; }
        public Meal Meal { get; set; }
        public DateOnly Date { get; set; }
    }
}