using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter4.UnitConverters.Mass
{
    class GramUnitConverter : MassUnitConverter
    {
        public override string Unit => "g";

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
