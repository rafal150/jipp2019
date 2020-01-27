namespace Konwerter
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class STATISTICS
    {
        [Key]
        public int ID_STAT { get; set; }

        public double? CONVERTED_FROM_VAL { get; set; }

        public double? CONVERTED_TO_VAL { get; set; }

        [StringLength(50)]
        public string CONVERTED_FROM { get; set; }

        [StringLength(50)]
        public string CONVERTED_TO { get; set; }

        public DateTime? DATE { get; set; }

        [StringLength(50)]
        public string TYPE { get; set; }
    }
}
