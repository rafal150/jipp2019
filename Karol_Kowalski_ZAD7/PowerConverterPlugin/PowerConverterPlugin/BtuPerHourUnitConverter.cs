using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerConverterPlugin
{
    class BtuPerHourUnitConverter : PowerUnitConverter
    {
        public override string Unit => "BTU/h";

        public override decimal ConvertFromSI(decimal value)
        {
            return value / 0.293071m;
        }

        public override decimal ConvertToSI(decimal value)
        {
            return value * 0.293071m;
        }
    }
}
