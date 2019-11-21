using System;
using System.ComponentModel.DataAnnotations;

namespace Konwerter5.ModelDanych
{
    public class StatystykiUzycia
    {
        public int Id { get; set; }

        public DateTime? Data { get; set; }

        [StringLength(50)]
        public string ZJednostki { get; set; }

        [StringLength(50)]
        public string DoJednostki { get; set; }

        public double? WartoscDoPrzeliczen { get; set; }

        public double? WartoscPrzeliczona { get; set; }

        [StringLength(50)]
        public string TypKonwersji { get; set; }
    }
}
