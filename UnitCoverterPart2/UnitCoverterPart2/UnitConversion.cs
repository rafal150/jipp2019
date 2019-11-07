using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitCoverterPart2
{
    class UnitConversion
    {
        public String From { get; }
        public String To { get; }

        private Func<double, double> ConvertRule;

        public UnitConversion(String from, String to, Func<double, double> convertRule)
        {
            From = from;
            To = to;
            ConvertRule = convertRule;
        }

        public double Convert(double source)
        {
            return ConvertRule(source);
        }
    }
}
