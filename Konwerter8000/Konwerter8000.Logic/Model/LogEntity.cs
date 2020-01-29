using Microsoft.WindowsAzure.Storage.Table;
using System;

namespace Konwerter8000.Model
{
    public class LogEntity : TableEntity
    {
        public DateTime? Data { get; set; }

        public int Id { get; set; }

        public string ZJednostki { get; set; }

        public string DoJednostki { get; set; }

        public double? WartoscDoPrzeliczen { get; set; }

        public double? WartoscPrzeliczona { get; set; }

    }
}
