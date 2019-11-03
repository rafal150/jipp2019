using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter
{
    class Temperature
    {

        public double FarhenheitToKelvin(double temperature)
        {
            return (temperature + 459.67) * 5 / 9;
        }
        public double CF(double temperature)
        {
            return (temperature * 1.8) + 32;
        }
        public double CelsiusToKelvin(double temperature)
        {
            return temperature + 273.15;
        }
        public double KelvinToCelsius(double temperature)
        {
            return temperature - 273.15;
        }
        public double KelvinToFarhenheit(double temperature)
        {
            return temperature - 459.67;
        }
    }
}
