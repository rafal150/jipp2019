using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter.Desktop
{
    public class HistoryItem
    {
        public DateTime? DateTime { get; set; }

        public string ConversionType { get; set; }

        public string UnitFrom { get; set; }

        public decimal? ValueToConvert { get; set; }

        public string UnitTo { get; set; }

        public decimal? ConvertedValue { get; set; }
    }
}
