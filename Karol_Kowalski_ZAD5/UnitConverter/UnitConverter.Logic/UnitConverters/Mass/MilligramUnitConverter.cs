using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter.Logic.UnitConverters.Mass
{
    class MilligramUnitConverter : MassUnitConverter
    {
        public override string Unit => "mg";

        public override decimal ConvertFromSI(decimal value)
        {
            return value * 1000000m;
        }

        public override decimal ConvertToSI(decimal value)
        {
            return value * 0.000001m;
        }
    }
}
