using NutritionDiary.Domain.Enums;
using NutritionDiary.Domain.ValueObjects;

namespace NutritionDiary.Application.DTOs
{
    public class ProductResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Brand { get; set; }
        public string? Category { get; set; }
        public NutriScoreGrade? NutriscoreGrade { get; set; }
        public NutritionFacts NutritionFacts { get; set; }
        public Source Source { get; set; }
    }
}