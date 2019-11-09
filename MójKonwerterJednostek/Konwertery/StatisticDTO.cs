using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MójKonwerterJednostek.Konwertery
{
    public class StatisticDTO
    {
        public int ID { get; set; }

        
        public DateTime DateTime { get; set; }

        
        public string UnitFrom { get; set; }

       
        public string UnitTo { get; set; }

        public decimal RawValue { get; set; }

        public decimal ConvertedValue { get; set; }

        public string Type { get; set; }
    }
}
