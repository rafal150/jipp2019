/*
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace UnitCoverterPart2
{
    public class StatDTO
    {
        public int id { get; set; }

        public DateTime? czas { get; set; }

        [StringLength(20)]
        public string konwersja_z { get; set; }

        [StringLength(20)]
        public string konwersja_na { get; set; }

        public decimal? wartosc_wprowadzona { get; set; }

        public decimal? wynik { get; set; }
    }
}
/*
