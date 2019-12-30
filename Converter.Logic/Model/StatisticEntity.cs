using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Table;

namespace Konwerter
{
    class StatisticEntity: TableEntity
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public DateTime DateTime { get; set; }
        public string UnitFrom { get; set; }
        public double ValueFrom { get; set; }
        public string UnitTo { get; set; }
        public double? ValueTo { get; set; }
    }
}
