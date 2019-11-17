using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Units_Converter
{
    public class StatisticsDTO
    {
        public int Id { get; set; }

        public DateTime? DateTime { get; set; }
        public string UnitFrom { get; set; }
        public string UnitTo { get; set; }

        public int? RawValue { get; set; }

        public int? ConvertedValue { get; set; }
        public string Type { get; set; }
    }
}
