using System;

namespace Konwerter5.Logic

{
    public class StatystykiUzyciaDTO
    {
        public int Id { get; set; }

        public DateTime? Data { get; set; }

        public string ZJednostki { get; set; }

        public string DoJednostki { get; set; }

        public double? WartoscDoPrzeliczen { get; set; }

        public double? WartoscPrzeliczona { get; set; }

        public string TypKonwersji { get; set; }
    }
}
