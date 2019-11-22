using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter4.UnitConverters.Length
{
    class MileUnitConverter : LengthUnitConverter
    {
        public override string Unit => "mi";

        public override decimal ConvertFromSI(decimal value)
        {
            return value / 1609.344m;
        }

        public override decimal ConvertToSI(decimal value)
        {
            return value * 1609.344m;
        }
    }
}
