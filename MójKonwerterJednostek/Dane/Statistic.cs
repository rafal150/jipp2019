namespace MójKonwerterJednostek.Dane
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Statistic
    {
        public int ID { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime DateTime { get; set; }

        [Required]
        [StringLength(50)]
        public string UnitFrom { get; set; }

        [Required]
        [StringLength(50)]
        public string UnitTo { get; set; }

        public decimal RawValue { get; set; }

        public decimal ConvertedValue { get; set; }

        [Required]
        [StringLength(50)]
        public string Type { get; set; }
    }
}
