namespace KonwerterApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TabelaKonwertera")]
    public partial class TabelaKonwertera
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public DateTime? DateTime { get; set; }

        [StringLength(50)]
        public string Type { get; set; }

        [StringLength(50)]
        public string FromUnit { get; set; }

        [StringLength(50)]
        public string ToUnit { get; set; }

        public double? RawValue { get; set; }

        public double? Converted { get; set; }
    }
}
