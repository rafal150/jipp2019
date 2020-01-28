namespace UnitConverter
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Z502_15.Statistics")]
    public partial class Statistic
    {
        public int Id { get; set; }

        public DateTime? DateTime { get; set; }

        [Required]
        [StringLength(50)]
        public string ConversionType { get; set; }

        [Required]
        [StringLength(50)]
        public string UnitFrom { get; set; }

        [Required]
        [StringLength(50)]
        public string UnitTo { get; set; }

        public double? ValueFrom { get; set; }

        public double? ValueTo { get; set; }
    }
}
