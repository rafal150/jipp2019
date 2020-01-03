using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Table;

namespace KonwerterApp
{
    class StatisticsEntity : TableEntity
    {
        public int ID { get; set; }

        public DateTime? DateTime { get; set; }

        public string Type { get; set; }

        public string FromUnit { get; set; }

        public string ToUnit { get; set; }

        public double? RawValue { get; set; }

        public double? Converted { get; set; }
    }
}
