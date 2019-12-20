using System;

namespace UnitConversion
{
    public class ConversionHistoryDTO
    {
        public int Id { get; set; }

        public DateTime? Created { get; set; }

        public string ConversionType { get; set; }

        public string BaseUnit { get; set; }

        public decimal BaseValue { get; set; }

        public string TargetUnit { get; set; }

        public decimal TargetValue { get; set; }
    }
}