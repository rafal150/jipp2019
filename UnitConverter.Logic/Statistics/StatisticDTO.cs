using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace UnitConverter.Statistics
{
    public class StatisticDTO
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
