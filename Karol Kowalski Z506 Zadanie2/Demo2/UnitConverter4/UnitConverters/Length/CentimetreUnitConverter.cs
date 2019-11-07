using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter4.UnitConverters.Length
{
    class CentimetreUnitConverter : LengthUnitConverter
    {
        public override string Unit => "cm";

        public override decimal ConvertFromSI(decimal value)
        {
            return value * 100m;
        }

        public override decimal ConvertToSI(decimal value)
        {
            return value * 0.01m;
        }
    }
}
