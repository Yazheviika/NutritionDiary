namespace NutritionDiary.Infrastructure.ExternalApis.Usda
{
    public record UsdaFoodDetailResponse(
        int FdcId,
        string Description,
        string? BrandOwner,
        UsdaFoodCategory? FoodCategory,
        List<UsdaNutrientDetail> FoodNutrients
    );

    public record UsdaNutrientDetail(
        double Amount,
        UsdaNutrientInfo Nutrient
    );

    public record UsdaFoodCategory(
        int Id, 
        string Description
    );

    public record UsdaNutrientInfo(
        int Id,
        string Name,
        string UnitName
    );
}