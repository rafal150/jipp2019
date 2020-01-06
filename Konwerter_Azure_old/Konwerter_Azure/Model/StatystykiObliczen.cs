namespace Konwerter_Azure.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StatystykiObliczen")]
    public partial class StatystykiObliczen
    {
        public int id { get; set; }

        public DateTime? czas { get; set; }

        public int? grupa { get; set; }

        public int? przeliczZ { get; set; }

        public decimal? dane { get; set; }

        public int? przeliczNa { get; set; }

        public decimal? wynik { get; set; }
    }
}
