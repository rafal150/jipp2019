using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerConverterPlugin
{
    class BtuPerMinuteUnitConverter : PowerUnitConverter
    {
        public override string Unit => "BTU/min";

        public override decimal ConvertFromSI(decimal value)
        {
            return value / 17.584264m;
        }

        public override decimal ConvertToSI(decimal value)
        {
            return value * 17.584264m;
        }
    }
}
