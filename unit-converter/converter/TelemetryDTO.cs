using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace converter
{
    public class TelemetryDTO
    {
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public string UnitFrom { get; set; }
        public string UnitTo { get; set; }
        public float ValueFrom { get; set; }
        public float ValueTo { get; set; }
    }
}
