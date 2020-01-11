namespace Unitconverter
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UnitConverter")]
    public partial class UnitConverter
    {
        public int Id { get; set; }

        public DateTime? DateTime { get; set; }

        [StringLength(50)]
        public string Type { get; set; }

        [StringLength(50)]
        public string FromUnit { get; set; }

        [StringLength(50)]
        public string ToUnit { get; set; }

        public int? RawValue { get; set; }

        public int? ConvertedValue { get; set; }
    }
}
