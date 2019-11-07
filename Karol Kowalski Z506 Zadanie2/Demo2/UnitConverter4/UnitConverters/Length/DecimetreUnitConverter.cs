using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter4.UnitConverters.Length
{
    class DecimetreUnitConverter : LengthUnitConverter
    {
        public override string Unit => "dm";

        public override decimal ConvertFromSI(decimal value)
        {
            return value * 10m;
        }

        public override decimal ConvertToSI(decimal value)
        {
            return value * 0.1m;
        }
    }
}
