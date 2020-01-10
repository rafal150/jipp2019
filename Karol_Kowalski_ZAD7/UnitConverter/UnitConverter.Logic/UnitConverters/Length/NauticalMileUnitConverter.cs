using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter.Logic.UnitConverters.Length
{
    class NauticalMileUnitConverter : LengthUnitConverter
    {
        public override string Unit => "nmi";

        public override decimal ConvertFromSI(decimal value)
        {
            return value / 1852m;
        }

        public override decimal ConvertToSI(decimal value)
        {
            return value * 1852m;
        }
    }
}
