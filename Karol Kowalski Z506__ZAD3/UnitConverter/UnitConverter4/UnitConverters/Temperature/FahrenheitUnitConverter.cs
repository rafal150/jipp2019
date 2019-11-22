using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter4.UnitConverters.Temperature
{
    class FahrenheitUnitConverter : TemperatureUnitConverter
    {
        public override string Unit => "°F";

        public override decimal ConvertFromSI(decimal value)
        {
            return value * 9m / 5m - 459.67m;
        }

        public override decimal ConvertToSI(decimal value)
        {
            return (value + 459.67m) * 5m / 9m;
        }
    }
}
