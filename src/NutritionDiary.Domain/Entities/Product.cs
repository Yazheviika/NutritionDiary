using NutritionDiary.Domain.Enums;
using NutritionDiary.Domain.ValueObjects;

namespace NutritionDiary.Domain.Entities
{
    public class Product : FoodItem
    {
        public string? Brand { get; set; }
        public string? Category { get; set; }
        public NutriScoreGrade? NutriscoreGrade { get; set; }
        public Source Source { get; set; }
        public string? ExternalId { get; set; }

        public override NutritionTotals GetNutritionTotals(double quantityInG)
        {
            return new NutritionTotals()
            {
                EnergyKcal = NutritionFacts.EnergyKcalPer100g / 100 * quantityInG,
                Fat = NutritionFacts.FatPer100g / 100 * quantityInG,
                SaturatedFat = NutritionFacts.SaturatedFatPer100g / 100 * quantityInG,
                Carbohydrates = NutritionFacts.CarbohydratesPer100g / 100 * quantityInG,
                Proteins = NutritionFacts.ProteinsPer100g / 100 * quantityInG,
                Sugars = NutritionFacts.SugarsPer100g / 100 * quantityInG,
                Fiber = NutritionFacts.FiberPer100g / 100 * quantityInG,
                Salt = NutritionFacts.SaltPer100g / 100 * quantityInG,
                Iron = NutritionFacts.IronPer100g / 100 * quantityInG,
                Calcium = NutritionFacts.CalciumPer100g / 100 * quantityInG,
                Potassium = NutritionFacts.PotassiumPer100g / 100 * quantityInG,
                VitaminD = NutritionFacts.VitaminDPer100g / 100 * quantityInG,
                VitaminC = NutritionFacts.VitaminCPer100g / 100 * quantityInG,
                VitaminB12 = NutritionFacts.VitaminB12Per100g / 100 * quantityInG,
            };
        }
    }
}
