using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter.Logic.UnitConverters.Temperature
{
    class RankineUnitConverter : TemperatureUnitConverter
    {
        public override string Unit => "°R";

        public override decimal ConvertFromSI(decimal value)
        {
            return value * 9m / 5m;
        }

        public override decimal ConvertToSI(decimal value)
        {
            return value * 5m / 9m;
        }
    }
}
