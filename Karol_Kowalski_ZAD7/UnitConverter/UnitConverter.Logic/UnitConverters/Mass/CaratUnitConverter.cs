using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter.Logic.UnitConverters.Mass
{
    class CaratUnitConverter : MassUnitConverter
    {
        public override string Unit => "ct";

        public override decimal ConvertFromSI(decimal value)
        {
            return value * 5000m;
        }

        public override decimal ConvertToSI(decimal value)
        {
            return value * 0.0002m;
        }
    }
}
