namespace konwerter
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UsageStatistics
    {
        public int ID { get; set; }

        public DateTime DateTime { get; set; }

        [Required]
        [StringLength(50)]
        public string UnitType { get; set; }

        [Required]
        [StringLength(50)]
        public string InputUnit { get; set; }

        [Required]
        [StringLength(50)]
        public string OutputUnit { get; set; }

        public decimal Value { get; set; }
    }
}
