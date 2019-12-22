using Microsoft.WindowsAzure.Storage.Table;
using System;

namespace Konwerter5.Logic.ModelDanych
{
    public class StatystykiUzyciaEntity : TableEntity
    {
        public string TypKonwersji { get; set; }

        public DateTime? Data { get; set; }

        public int Id { get; set; }

        public string ZJednostki { get; set; }

        public string DoJednostki { get; set; }

        public double? WartoscDoPrzeliczen { get; set; }

        public double? WartoscPrzeliczona { get; set; }


    }
}
