using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter.Logic.UnitConverters.Length
{
    class FootUnitConverter : LengthUnitConverter
    {
        public override string Unit => "ft";

        public override decimal ConvertFromSI(decimal value)
        {
            return value / 0.3048m;
        }

        public override decimal ConvertToSI(decimal value)
        {
            return value * 0.3048m;
        }
    }
}
