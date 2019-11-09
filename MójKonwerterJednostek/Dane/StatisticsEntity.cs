using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Table;

namespace MójKonwerterJednostek.Dane
{
    public class StatisticsEntity : TableEntity
    {
        public int ID { get; set; }


        public DateTime DateTime { get; set; }


        public string UnitFrom { get; set; }


        public string UnitTo { get; set; }

        public int RawValue { get; set; }

        public int ConvertedValue { get; set; }

        public string Type { get; set; }
    }
}
