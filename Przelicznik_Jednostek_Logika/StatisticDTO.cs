using System;

namespace Przelicznik_Jednostek
{
    public class StatisticDTO
    {
        public int Id { get; set; }

        public DateTime? DateTime { get; set; }
        public string UnitFrom { get; set; }
        public string UnitTo { get; set; }

        public string RawValue { get; set; }

        public string ConvertedValue { get; set; }
        public string Type { get; set; }
    }
}