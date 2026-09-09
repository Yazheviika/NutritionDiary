using MediatR;
using NutritionDiary.Application.DTOs;

namespace NutritionDiary.Application.DiaryEntries.Queries.GetDiaryEntriesForUser
{
    public record GetDiaryEntriesForUserQuery(string UserId, DateOnly Date) : IRequest<List<DiaryEntryResponse>>;
}