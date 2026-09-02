using NutritionDiary.Domain.ValueObjects;

namespace NutritionDiary.Domain.Entities
{
    public abstract class FoodItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public NutritionFacts NutritionFacts { get; set; }

        public abstract NutritionTotals GetNutritionTotals(double quantityInG);
    }
}
