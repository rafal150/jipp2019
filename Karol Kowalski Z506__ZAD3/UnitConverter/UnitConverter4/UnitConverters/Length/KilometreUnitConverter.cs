using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter4.UnitConverters.Length
{
    class KilometreUnitConverter : LengthUnitConverter
    {
        public override string Unit => "km";

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
