using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterNS.Modell 
{
    class StatisticEntity : TableEntity
    {
        public DateTime? DateTime { get; set; }

        public string Type { get; set; }

        public string FromUnit { get; set; }

        public string FromTo { get; set; }

        public double RawValue { get; set; }

        public double ConvertedValue { get; set; }
    }
}
