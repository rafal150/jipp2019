using System;

namespace UnitConverter.Logic
{
    public class HistoryDTO
    {
        public DateTime? DateTime { get; set; }

        public string ConversionType { get; set; }

        public string UnitFrom { get; set; }

        public decimal? ValueToConvert { get; set; }

        public string UnitTo { get; set; }

        public decimal? ConvertedValue { get; set; }
    }
}
