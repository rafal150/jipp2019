using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitCoverter.StatisticModel
{
    public class StatisticsEntity : TableEntity
    {
        public DateTime? DateTime { get; set; }
        public double? ValueFrom { get; set; }
        public double? ValueTo { get; set; }
        public string UnitFrom { get; set; }
        public string UnitTo { get; set; }
    }
}
