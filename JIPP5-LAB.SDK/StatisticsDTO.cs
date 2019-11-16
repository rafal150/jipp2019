using System;

namespace JIPP5_LAB.SDK
{
    public class StatisticsDTO
    {
        public long id { get; set; }

        public DateTime Date { get; set; }

        public string FromUnit { get; set; }
        public string ToUnit { get; set; }

        public decimal RawData { get; set; }

        public decimal Converted { get; set; }
    }
}