using NutritionDiary.Application.DTOs;
using NutritionDiary.Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace NutritionDiary.Application.Common.Mapping
{
    [Mapper]
    public partial class DiaryEntryMapper
    {
        [MapperIgnoreSource(nameof(DiaryEntry.UserId))]
        [MapperIgnoreSource(nameof(DiaryEntry.FoodItem))]
        [MapProperty(nameof(DiaryEntry.NutritionTotalsSnapshot), nameof(DiaryEntryResponse.NutritionTotals))]
        public partial DiaryEntryResponse ToResponse(DiaryEntry entry);
    }
}