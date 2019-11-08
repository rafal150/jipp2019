namespace Konwerter
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Z502_14.Statistics")]
    public partial class Rekord
    {
        public int Id { get; set; }

        public DateTime? DateTime { get; set; }

        [StringLength(50)]
        public string Type { get; set; }

        [StringLength(5)]
        public string FromUnit { get; set; }

        [StringLength(5)]
        public string ToUnit { get; set; }

        [StringLength(50)]
        public string RawValue { get; set; }

        [StringLength(50)]
        public string ConvertedValue { get; set; }
    }
}
