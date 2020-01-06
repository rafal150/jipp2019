using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerConverterPlugin
{
    class MechanicalHorsepowerUnitConverter : PowerUnitConverter
    {
        public override string Unit => "hp(I)";

        public override decimal ConvertFromSI(decimal value)
        {
            return value / 745.69987158227022m;
        }

        public override decimal ConvertToSI(decimal value)
        {
            return value * 745.69987158227022m;
        }
    }
}
