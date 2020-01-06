using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerConverterPlugin
{
    class KilowattUnitConverter : PowerUnitConverter
    {
        public override string Unit => "kW";

        public override decimal ConvertFromSI(decimal value)
        {
            return value * 0.001m;
        }

        public override decimal ConvertToSI(decimal value)
        {
            return value * 1000m;
        }
    }
}
