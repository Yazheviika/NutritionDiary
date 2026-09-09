using MediatR;
using NutritionDiary.Application.DTOs;

namespace NutritionDiary.Application.FoodItems.Queries.SearchFoods
{
    public record SearchFoodsQuery(string SearchTerm) : IRequest<List<FoodSearchResult>>;
}