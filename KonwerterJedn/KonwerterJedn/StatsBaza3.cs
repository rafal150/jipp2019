namespace KonwerterJedn
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class StatsBaza3
    {
        public int Id { get; set; }

        [StringLength(30)]
        public string UnitFrom { get; set; }

        [StringLength(30)]
        public string UnitTo { get; set; }

        [StringLength(30)]
        public string ValueFrom { get; set; }

        [StringLength(30)]
        public string ValueTo { get; set; }

        [StringLength(20)]
        public string Type { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime DateTime { get; set; }
    }
}
