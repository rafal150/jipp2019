namespace UnitConverteAZ.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UnitConverterAZ
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Type { get; set; }

        public DateTime? Calculation_Time { get; set; }

        [StringLength(50)]
        public string UnitFrom { get; set; }

        public double? Value_From { get; set; }

        [StringLength(50)]
        public string Unit_To { get; set; }

        public double? Converted_Value { get; set; }
    }
}
