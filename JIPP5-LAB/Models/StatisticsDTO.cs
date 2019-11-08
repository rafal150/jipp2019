using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JIPP5_LAB.Models
{
    public class StatisticsDTO
    {
        public long id { get; set; }

        public DateTime Date { get; set; }

        public string FromUnit { get; set; }
        public string ToUnit { get; set; }

        public decimal RawData { get; set; }

        public decimal Converted { get; set; }
    }
}
