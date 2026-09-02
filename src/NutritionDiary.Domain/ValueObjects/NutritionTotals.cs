namespace NutritionDiary.Domain.ValueObjects
{
    public class NutritionTotals
    {
        public double EnergyKcal { get; set; }
        public double Fat { get; set; }
        public double SaturatedFat{ get; set; }
        public double Carbohydrates { get; set; }
        public double Proteins { get; set; }
        public double Sugars { get; set; }
        public double Fiber { get; set; }
        public double? Salt { get; set; }
        public double? Iron { get; set; }
        public double? Calcium { get; set; }
        public double? Potassium { get; set; }
        public double? VitaminD { get; set; }
        public double? VitaminC { get; set; }
        public double? VitaminB12 { get; set; }
    }
}
