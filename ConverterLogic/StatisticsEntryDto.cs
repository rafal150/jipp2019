using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterLogic
{
    public class StatisticsEntryDto
    {
        public DateTime date { get; set; }
        public string from { get; set; }
        public string to { get; set; }
        public string fromValue { get; set; }
        public double resultValue { get; set; }

        public StatisticsEntryDto()
        {
            //empty ctor
        }

        public StatisticsEntryDto(DateTime date, string from, string to, string fromValue, double resultValue)
        {
            this.date = date;
            this.from = from;
            this.to = to;
            this.fromValue = fromValue;
            this.resultValue = resultValue;
        }
    }
}
