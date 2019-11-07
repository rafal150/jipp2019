using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter4.UnitConverters.Length
{
    class InchUnitConverter : LengthUnitConverter
    {
        public override string Unit => "in";

        public override decimal ConvertFromSI(decimal value)
        {
            return value / 0.0254m;
        }

        public override decimal ConvertToSI(decimal value)
        {
            return value * 0.0254m;
        }
    }
}
