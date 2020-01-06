using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter.Logic.UnitConverters.Temperature
{
    class KelvinUnitConverter : TemperatureUnitConverter
    {
        public override string Unit => "K";

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
