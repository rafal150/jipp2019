using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace converter
{
    public class TelemetryEntity : TableEntity
    {
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public string UnitFrom { get; set; }
        public string UnitTo { get; set; }
        public double ValueFrom { get; set; }
        public double ValueTo { get; set; }
    }
}
