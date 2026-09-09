namespace NutritionDiary.Infrastructure.ExternalApis.Usda
{
    public record UsdaFoodDetailResponse(
        int FdcId,
        string Description,
        string? BrandOwner,
        string? FoodCategory,
        List<UsdaNutrientDetail> FoodNutrients
    );

    public record UsdaNutrientDetail(
        double Amount,
        UsdaNutrientInfo Nutrient
    );

    public record UsdaNutrientInfo(
        int Id,
        string Name,
        string UnitName
    );
}