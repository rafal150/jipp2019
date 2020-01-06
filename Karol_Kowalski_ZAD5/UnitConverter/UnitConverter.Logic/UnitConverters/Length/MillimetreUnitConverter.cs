using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter.Logic.UnitConverters.Length
{
    class MillimetreUnitConverter : LengthUnitConverter
    {
        public override string Unit => "mm";

        public override decimal ConvertFromSI(decimal value)
        {
            return value * 1000m;
        }

        public override decimal ConvertToSI(decimal value)
        {
            return value * 0.001m;
        }
    }
}
