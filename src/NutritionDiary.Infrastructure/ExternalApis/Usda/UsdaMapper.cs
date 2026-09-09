using NutritionDiary.Application.DTOs;
using NutritionDiary.Domain.Entities;
using NutritionDiary.Domain.Enums;
using NutritionDiary.Domain.ValueObjects;

namespace NutritionDiary.Infrastructure.ExternalApis.Usda
{
    public class UsdaMapper
    {
        public static FoodSearchResult ToSearchResult(UsdaSearchFoodItem item)
        {
            int caloriesPer100UsdaId = 1008;
            var calories = item.FoodNutrients.FirstOrDefault(n => n.NutrientId == caloriesPer100UsdaId)?.Value;
            return new FoodSearchResult
            (
                ExternalId: item.FdcId.ToString(),
                Name: item.Description,
                Brand: item.BrandOwner,
                CaloriesPer100g: calories
            );
        }

        public static Product? ToProduct(UsdaFoodDetailResponse detail)
        {
            var nutrients = detail.FoodNutrients;

            var energy = GetNutrientValue(nutrients, UsdaNutrientIds.Energy);
            var protein = GetNutrientValue(nutrients, UsdaNutrientIds.Protein);
            var fat = GetNutrientValue(nutrients, UsdaNutrientIds.Fat);
            var carbs = GetNutrientValue(nutrients, UsdaNutrientIds.Carbohydrates);
            var saturatedFat = GetNutrientValue(nutrients, UsdaNutrientIds.SaturatedFat);
            var sugars = GetNutrientValue(nutrients, UsdaNutrientIds.Sugars);
            var fiber = GetNutrientValue(nutrients, UsdaNutrientIds.Fiber);

            if (energy is null || protein is null || fat is null || carbs is null
                || saturatedFat is null || sugars is null || fiber is null)
            {
                return null;
            }

            var sodiumMg = GetNutrientValue(nutrients, UsdaNutrientIds.Sodium);
            var saltPer100g = sodiumMg.HasValue ? sodiumMg.Value * 2.5 / 1000 : (double?)null;

            return new Product
            {
                Name = detail.Description,
                Brand = detail.BrandOwner,
                Category = detail.FoodCategory?.Description,
                Source = Source.USDA,
                ExternalId = detail.FdcId.ToString(),
                NutritionFacts = new NutritionFacts()
                {
                    EnergyKcalPer100g = energy.Value,
                    ProteinsPer100g = protein.Value,
                    FatPer100g = fat.Value,
                    CarbohydratesPer100g = carbs.Value,
                    SaturatedFatPer100g = saturatedFat.Value,
                    SugarsPer100g = sugars.Value,
                    FiberPer100g = fiber.Value,
                    SaltPer100g = saltPer100g,
                    IronPer100g = GetNutrientValue(nutrients, UsdaNutrientIds.Iron),
                    CalciumPer100g = GetNutrientValue(nutrients, UsdaNutrientIds.Calcium),
                    PotassiumPer100g = GetNutrientValue(nutrients, UsdaNutrientIds.Potassium),
                    VitaminDPer100g = GetNutrientValue(nutrients, UsdaNutrientIds.VitaminD),
                    VitaminCPer100g = GetNutrientValue(nutrients, UsdaNutrientIds.VitaminC),
                    VitaminB12Per100g = GetNutrientValue(nutrients, UsdaNutrientIds.VitaminB12)
                }
            };
        }

        private static double? GetNutrientValue(List<UsdaNutrientDetail> nutrients, int nutrientId)
            => nutrients.FirstOrDefault(n => n.Nutrient.Id == nutrientId)?.Amount;
    }
}