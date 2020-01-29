using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter {
    public class StatisticDTO {
        public int Id { get; set; }

        public DateTime? DateTime { get; set; }

        public string ConversionType { get; set; }

        public string UnitFrom { get; set; }

        public string UnitTo { get; set; }

        public double? ValueFrom { get; set; }

        public double? ValueTo { get; set; }
    }
}
