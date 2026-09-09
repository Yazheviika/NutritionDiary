using MediatR;
using NutritionDiary.Application.DTOs;
using NutritionDiary.Application.Interfaces;

namespace NutritionDiary.Application.FoodItems.Queries.SearchFoods
{
    public class SearchFoodsQueryHandler : IRequestHandler<SearchFoodsQuery, List<FoodSearchResult>>
    {
        private readonly IFoodDataProvider _foodDataProvider;

        public SearchFoodsQueryHandler(IFoodDataProvider foodDataProvider)
        {
            _foodDataProvider = foodDataProvider;
        }

        public async Task<List<FoodSearchResult>> Handle(SearchFoodsQuery request, CancellationToken cancellationToken)
        {
            return await _foodDataProvider.SearchAsync(request.SearchTerm, cancellationToken);
        }
    }
}