using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace WpfAppJIPP
{
    public class StatisticDTO
    {
        public int Id { get; set; }

        public DateTime? Czas { get; set; }

        public string Typ { get; set; }

        public string Konwersja_z { get; set; }

  
        public string Konwersja_na { get; set; }

        public decimal? Wartosc_wprowadzona { get; set; }

        public decimal? Wynik { get; set; }
    }
}
