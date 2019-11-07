using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter4.UnitConverters.Mass
{
    class KilogramUnitConverter : MassUnitConverter
    {
        public override string Unit => "kg";

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
