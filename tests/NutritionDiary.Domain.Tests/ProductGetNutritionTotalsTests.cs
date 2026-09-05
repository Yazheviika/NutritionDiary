using FluentAssertions;
using NutritionDiary.Domain.Entities;
using NutritionDiary.Domain.Enums;
using NutritionDiary.Domain.ValueObjects;

namespace NutritionDiary.Domain.Tests
{
    public class ProductGetNutritionTotalsTests
    {
        [Fact]
        public void GetNutritionTotals_ScalesMacrosCorrectly()
        {
            // Arrange
            var product = new Product
            {
                Id = 1,
                Name = "Test Product",
                NutritionFacts = new NutritionFacts
                {
                    EnergyKcalPer100g = 200,
                    FatPer100g = 5,
                    SaturatedFatPer100g = 2,
                    CarbohydratesPer100g = 30,
                    ProteinsPer100g = 10,
                    SugarsPer100g = 15,
                    FiberPer100g = 3,
                    SaltPer100g = 1,
                    IronPer100g = 2,
                    CalciumPer100g = 3,
                    PotassiumPer100g = 4,
                    VitaminDPer100g = 5,
                    VitaminCPer100g = 6,
                    VitaminB12Per100g = 7
                },
                Source = Source.UserCreated,
            };

            var expectedNutritionTotals = new NutritionTotals
            {
                EnergyKcal = 400,
                Fat = 10, 
                SaturatedFat = 4, 
                Carbohydrates = 60, 
                Proteins = 20, 
                Sugars = 30, 
                Fiber = 6, 
                Salt = 2, 
                Iron = 4, 
                Calcium = 6, 
                Potassium = 8, 
                VitaminD = 10, 
                VitaminC = 12, 
                VitaminB12 = 14,
            };

            // Act
            var result = product.GetNutritionTotals(200);

            // Assert
            result.Should().BeEquivalentTo(expectedNutritionTotals, options => options
                .Using<double>(ctx => ctx.Subject.Should().BeApproximately(ctx.Expectation, 0.0001))
                .WhenTypeIs<double>());
        }

        [Fact]
        public void GetNutritionTotals_PropagatesNullMicronutrients()
        {
            // Arrange
            var product = new Product
            {
                Id = 1,
                Name = "Test Product",
                NutritionFacts = new NutritionFacts
                {
                    EnergyKcalPer100g = 200,
                    FatPer100g = 5,
                    SaturatedFatPer100g = 2,
                    CarbohydratesPer100g = 30,
                    ProteinsPer100g = 10,
                    SugarsPer100g = 15,
                    FiberPer100g = 3,
                    SaltPer100g = 1,
                    IronPer100g = 2,
                    CalciumPer100g = null,
                    PotassiumPer100g = 4,
                    VitaminDPer100g = null,
                    VitaminCPer100g = 6,
                    VitaminB12Per100g = 7
                },
                Source = Source.UserCreated,
            };

            // Act
            var result = product.GetNutritionTotals(200);

            // Assert
            Assert.Null(result.Calcium);
            Assert.Null(result.VitaminD);
        }
    }
}