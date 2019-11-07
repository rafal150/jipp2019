using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter4.UnitConverters.Mass
{
    class QuintalUnitConverter : MassUnitConverter
    {
        public override string Unit => "quintal";

        public override decimal ConvertFromSI(decimal value)
        {
            return value * 0.01m;
        }

        public override decimal ConvertToSI(decimal value)
        {
            return value * 100m;
        }
    }
}
