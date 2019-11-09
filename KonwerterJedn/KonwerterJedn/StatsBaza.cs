namespace KonwerterJedn
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StatsBaza")]
    public partial class StatsBaza
    {
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string UnitFrom { get; set; }

        [Required]
        [StringLength(10)]
        public string UnitTo { get; set; }

        [Required]
        [StringLength(10)]
        public string ValueFrom { get; set; }

        [Required]
        [StringLength(10)]
        public string ValueTo { get; set; }

        [Required]
        [StringLength(10)]
        public string Type { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime DateTime { get; set; }
    }
}
