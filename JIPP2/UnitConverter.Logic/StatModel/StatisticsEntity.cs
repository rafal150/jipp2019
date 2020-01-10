using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace  WpfAppJIPP
{
    public class StatisticsEntity : TableEntity
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
