namespace WpfAppJIPP
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Statistics
    {
        public int Id { get; set; }

        public DateTime? Czas { get; set; }

        [StringLength(20)]
        public string Typ { get; set; }

        [StringLength(20)]
        public string Konwersja_z { get; set; }

         [StringLength(20)]
        public string Konwersja_na { get; set; }

        public decimal? Wartosc_wprowadzona { get; set; }

        public decimal? Wynik { get; set; }
    }
}