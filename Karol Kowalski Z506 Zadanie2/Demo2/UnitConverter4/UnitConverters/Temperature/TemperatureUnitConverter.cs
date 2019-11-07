using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter4.UnitConverters.Temperature
{
    abstract class TemperatureUnitConverter : IUnitConverter
    {
        public string Type => "Temperatura";

        public abstract string Unit { get; }

        public abstract decimal ConvertFromSI(decimal value);

        public abstract decimal ConvertToSI(decimal value);
    }
}
