namespace UnitConverter
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StatisticJZ")]
    public partial class StatisticJZ
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime? DateTime { get; set; }

        [StringLength(50)]
        public string UnitFrom { get; set; }

        [StringLength(50)]
        public string UnitTo { get; set; }

        [StringLength(50)]
        public string Type { get; set; }

        public double? RawValue { get; set; }

        public double? ConvertedValue { get; set; }
    }
}
