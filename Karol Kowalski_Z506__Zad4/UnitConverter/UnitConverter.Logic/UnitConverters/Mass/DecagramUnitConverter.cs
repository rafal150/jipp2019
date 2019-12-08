using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter.Logic.UnitConverters.Mass
{
    class DecagramUnitConverter : MassUnitConverter
    {
        public override string Unit => "dag";

        public override decimal ConvertFromSI(decimal value)
        {
            return value * 100m;
        }

        public override decimal ConvertToSI(decimal value)
        {
            return value * 0.01m;
        }
    }
}
