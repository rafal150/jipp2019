using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter.Model
{
    public class StatisticEntity : TableEntity
    {
        public int Id { get; set; }

        public DateTime? DateTime { get; set; }
        public string UnitFrom { get; set; }
        public string UnitTo { get; set; }
        public string Type { get; set; }
        public double? RawValue { get; set; }
        public double? ConvertedValue { get; set; }
    }
}
