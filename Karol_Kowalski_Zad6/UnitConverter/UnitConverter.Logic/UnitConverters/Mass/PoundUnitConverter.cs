using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter.Logic.UnitConverters.Mass
{
    class PoundUnitConverter : MassUnitConverter
    {
        public override string Unit => "lb";

        public override decimal ConvertFromSI(decimal value)
        {
            return value * 2.205m;
        }

        public override decimal ConvertToSI(decimal value)
        {
            return value / 2.205m;
        }
    }
}
