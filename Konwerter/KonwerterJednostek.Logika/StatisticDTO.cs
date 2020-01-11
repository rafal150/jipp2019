using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterNS
{
    public class StatisticDTO
    {
        public int Id { get; set; }

        public DateTime? DateTime { get; set; }

        public string Type { get; set; }

        public string FromUnit { get; set; }

        public string FromTo { get; set; }

        public decimal? RawValue { get; set; }

        public decimal? ConvertedValue { get; set; }
    }
}
