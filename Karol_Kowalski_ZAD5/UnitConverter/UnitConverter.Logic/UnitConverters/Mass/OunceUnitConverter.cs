using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter.Logic.UnitConverters.Mass
{
    class OunceUnitConverter : MassUnitConverter
    {
        public override string Unit => "oz";

        public override decimal ConvertFromSI(decimal value)
        {
            return value * 35.274m;
        }

        public override decimal ConvertToSI(decimal value)
        {
            return value / 35.274m;
        }
    }
}
