using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerConverterPlugin
{
    class BtuPerSecondUnitConverter : PowerUnitConverter
    {
        public override string Unit => "BTU/s";

        public override decimal ConvertFromSI(decimal value)
        {
            return value / 1055.05585262m;
        }

        public override decimal ConvertToSI(decimal value)
        {
            return value * 1055.05585262m;
        }
    }
}
