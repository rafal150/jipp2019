using System;
using System.ComponentModel.DataAnnotations;

namespace UnitCoverterPart2
{
    public class StatisticDTO
    {

        public int id { get; set; }

        public DateTime? DateTime { get; set; }

        [StringLength(50)]
        public string UnitFrom { get; set; }

        [StringLength(50)]
        public string UnitTo { get; set; }

        public double? RawValue { get; set; }

        public double? ConvertedValue { get; set; }

        [StringLength(50)]
        public string Type { get; set; }

    }

}