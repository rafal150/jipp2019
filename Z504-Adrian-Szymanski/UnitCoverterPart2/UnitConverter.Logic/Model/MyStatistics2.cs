namespace UnitConverter.Logic.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MyStatistics2
    {
        public int id { get; set; }

        public DateTime? DateTime { get; set; }

        [StringLength(70)]
        public string UnitFrom { get; set; }

        [StringLength(70)]
        public string UnitTo { get; set; }

        public double? RawValue { get; set; }

        public double? ConverterValue { get; set; }

        [StringLength(70)]
        public string Type { get; set; }
    }
}
