namespace Konwerter_Azure.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Statystyki")]
    public partial class Statystyki
    {
        public int id { get; set; }

        public DateTime? czas { get; set; }

        [StringLength(25)]
        public string grupa { get; set; }

        [StringLength(25)]
        public string przeliczZ { get; set; }

        public decimal? dane { get; set; }

        [StringLength(25)]
        public string przeliczNa { get; set; }

        public decimal? wynik { get; set; }
    }
}
