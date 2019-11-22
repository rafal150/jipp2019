using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter4.UnitConverters.Temperature
{
    class CelciusUnitConverter : TemperatureUnitConverter
    {
        public override string Unit => "°C";

        public override decimal ConvertFromSI(decimal value)
        {
            return value - 273.15m;
        }

        public override decimal ConvertToSI(decimal value)
        {
            return value + 273.15m;
        }
    }
}
