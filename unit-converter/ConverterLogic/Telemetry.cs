namespace converter
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Z502_17.Telemetry")]
    public partial class Telemetry
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Type { get; set; }

        public DateTime Date { get; set; }

        [Required]
        [StringLength(20)]
        public string UnitFrom { get; set; }

        [Required]
        [StringLength(20)]
        public string UnitTo { get; set; }

        public float ValueFrom { get; set; }

        public float ValueTo { get; set; }
    }
}
