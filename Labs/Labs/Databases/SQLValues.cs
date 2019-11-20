namespace Labs
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("jipp")]
    public partial class SQLValues
    {
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string category { get; set; }

        [StringLength(50)]
        public string Subcategory { get; set; }

        [Required]
        [StringLength(50)]
        public string from { get; set; }

        [Required]
        [StringLength(50)]
        public string to { get; set; }

        public DateTime? DateTime { get; set; }

        public double? initial { get; set; }

        public double? converted { get; set; }
    }
}
