using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerConverterPlugin
{
    class WattUnitConverter : PowerUnitConverter
    {
        public override string Unit => "W";

        public override decimal ConvertFromSI(decimal value)
        {
            return value;
        }

        public override decimal ConvertToSI(decimal value)
        {
            return value;
        }
    }
}
