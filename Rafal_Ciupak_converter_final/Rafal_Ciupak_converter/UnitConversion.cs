using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rafal_Ciupak_converter
{
    class UnitConversion
    {
        public String From { get; }
        public String To { get; }

        private Func<double, double> ConvertFun;

        public UnitConversion(String from, String to, Func<double, double> convertFun)
        {
            From = from;
            To = to;
            ConvertFun = convertFun;
        }

        public double Convert(double source)
        {
            return ConvertFun.Invoke(source);
        }
    }
}
