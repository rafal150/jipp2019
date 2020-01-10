using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterJedn
{
    public class StatisticDTO
    {
        public int Id { get; set; }

        public string UnitFrom { get; set; }

        public string UnitTo { get; set; }

        public string ValueFrom { get; set; }

        public string ValueTo { get; set; }

        public string Type { get; set; }

        public DateTime DateTime { get; set; }
    }
}
