namespace NutritionDiary.Domain.ValueObjects
{
    public class NutritionFacts
    {
        public double EnergyKcalPer100g { get; set; }
        public double FatPer100g { get; set; }
        public double SaturatedFatPer100g { get; set; }
        public double CarbohydratesPer100g { get; set; }
        public double ProteinsPer100g { get; set; }
        public double SugarsPer100g { get; set; }
        public double FiberPer100g { get; set; }
        public double? SaltPer100g { get; set; }
        public double? IronPer100g { get; set; }
        public double? CalciumPer100g { get; set; }
        public double? PotassiumPer100g { get; set; }
        public double? VitaminDPer100g { get; set; }
        public double? VitaminCPer100g { get; set; }
        public double? VitaminB12Per100g { get; set; }
    }
}
