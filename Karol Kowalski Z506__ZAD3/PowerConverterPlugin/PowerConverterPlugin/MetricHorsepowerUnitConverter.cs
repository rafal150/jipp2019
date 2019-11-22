using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerConverterPlugin
{
    class MetricHorsepowerUnitConverter : PowerUnitConverter
    {
        public override string Unit => "hp(M)";

        public override decimal ConvertFromSI(decimal value)
        {
            return value / 735.49875m;
        }

        public override decimal ConvertToSI(decimal value)
        {
            return value * 735.49875m;
        }
    }
}
