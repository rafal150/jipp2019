using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter.Logic.UnitConverters.Length
{
    class YardUnitConverter : LengthUnitConverter
    {
        public override string Unit => "yd";

        public override decimal ConvertFromSI(decimal value)
        {
            return value / 0.9144m;
        }

        public override decimal ConvertToSI(decimal value)
        {
            return value * 0.9144m;
        }
    }
}
