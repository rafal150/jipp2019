using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter4.UnitConverters.Length
{
    class MetreUnitConverter : LengthUnitConverter
    {
        public override string Unit => "m";

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
