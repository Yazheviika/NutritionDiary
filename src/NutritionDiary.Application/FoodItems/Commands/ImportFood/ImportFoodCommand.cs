using MediatR;
using NutritionDiary.Application.Common;
using NutritionDiary.Application.DTOs;
using NutritionDiary.Domain.Enums;

namespace NutritionDiary.Application.FoodItems.Commands.ImportFood
{
    public record ImportFoodCommand(string ExternalId, Source Source) : IRequest<Result<ProductResponse>>;
}