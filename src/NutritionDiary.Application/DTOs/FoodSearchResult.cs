namespace NutritionDiary.Application.DTOs
{
    public record FoodSearchResult(string ExternalId, string Name, string? Brand, double? CaloriesPer100g);
}