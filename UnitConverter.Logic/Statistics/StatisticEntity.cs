using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter.Statistics
{
    class StatisticEntity : TableEntity
    {
        public int Id { get; set; }
        public string type { get; set; }
        public string fromUnit { get; set; }
        public string toUnit { get; set; }
        public double startValue { get; set; }
        public double finalValue { get; set; }

        public DateTime? date { get; set; }
    }
}
