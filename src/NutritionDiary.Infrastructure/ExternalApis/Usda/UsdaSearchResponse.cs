namespace NutritionDiary.Infrastructure.ExternalApis.Usda
{
    public record UsdaSearchResponse(int TotalHits, List<UsdaSearchFoodItem> Foods);

    public record UsdaSearchFoodItem(
        int FdcId,
        string Description,
        string? BrandOwner,
        List<UsdaSearchNutrient> FoodNutrients
    );

    public record UsdaSearchNutrient(int NutrientId, string NutrientName, double Value);
}