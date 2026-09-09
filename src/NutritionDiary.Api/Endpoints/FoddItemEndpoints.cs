using MediatR;
using NutritionDiary.Application.DTOs;
using NutritionDiary.Application.FoodItems.Commands.ImportFood;
using NutritionDiary.Application.FoodItems.Queries.SearchFoods;

namespace NutritionDiary.Api.Endpoints
{
    public static class FoodItemEndpoints
    {
        public static IEndpointRouteBuilder MapFoodItemEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/fooditems").WithTags("FoodItems");

            group.MapPost("/", async (ImportFoodCommand command, IMediator mediator, CancellationToken cancellationToken) =>
            {
                var result = await mediator.Send(command, cancellationToken);

                return result.IsSuccess
                ? Results.Ok(result.Value)
                : Results.BadRequest(result.Error);
            })
            .Produces<ProductResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest);

            group.MapGet("/", async ([AsParameters] SearchFoodsQuery query, IMediator mediator, CancellationToken cancellationToken) =>
                Results.Ok(await mediator.Send(query, cancellationToken)))
            .Produces<List<FoodSearchResult>>(StatusCodes.Status200OK);

            return app;
        }
    }
}
