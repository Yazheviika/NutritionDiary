using NutritionDiary.Domain.Enums;
using NutritionDiary.Domain.ValueObjects;

namespace NutritionDiary.Domain.Entities
{
    public class DiaryEntry
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public FoodItem FoodItem { get; set; }
        public string FoodItemName { get; set; }
        public NutritionTotals NutritionTotalsSnapshot { get; set; }
        public double QuantityInG { get; set; }
        public Meal Meal { get; set; }
        public DateOnly Date { get; set; }
    }
}
