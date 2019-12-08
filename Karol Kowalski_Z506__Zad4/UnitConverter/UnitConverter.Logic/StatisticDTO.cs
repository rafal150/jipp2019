using System;

namespace UnitConverter.Logic
{
    public class StatisticDTO
    {
        public int Id { get; set; }

        public DateTime? DateTime { get; set; }
        public string UnitFrom { get; set; }
        public string UnitTo { get; set; }

        //public int? RawValue { get; set; }
        public decimal? RawValue { get; set; }

        //public int? ConvertedValue { get; set; }
        public decimal? ConvertedValue { get; set; }

        public string Type { get; set; }
    }
}