using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter.Logic.UnitConverters.Length
{
    class CableUnitConverter : LengthUnitConverter
    {
        public override string Unit => "cable";

        public override decimal ConvertFromSI(decimal value)
        {
            return value / 185.32m;
        }

        public override decimal ConvertToSI(decimal value)
        {
            return value * 185.32m;
        }
    }
}
