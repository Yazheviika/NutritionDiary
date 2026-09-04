using MediatR;
using NutritionDiary.Application.Common;
using NutritionDiary.Application.DTOs;
using NutritionDiary.Domain.Enums;

namespace NutritionDiary.Application.DiaryEntries.Commands.LogDiaryEntry
{
    public record LogDiaryEntryCommand(
            string UserId,
            int FoodId,
            double QuantityInG,
            Meal Meal,
            DateOnly Date
        ) : IRequest<Result<DiaryEntryResponse>>;
}