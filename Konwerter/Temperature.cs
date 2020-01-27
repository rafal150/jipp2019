using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter
{
    class Temperature
    {
        public double FarenheitToCelsiusz(double temperatura)
        {
            temperatura = (temperatura - 32) / 1.8;
            return temperatura;
        }
        public double CelsiuszToFarenheit(double temperatura)
        {
            temperatura =1.8*temperatura+32;
            return temperatura;
        }
        public double KelvinToCelsiusz(double temperatura)
        {
            temperatura = temperatura - 273.15;
            return temperatura;
        }
        public double CelsiuszToKelvin(double temperatura)
        {
            temperatura = temperatura + 273.15;
            return temperatura;
        }
        public double RankineToCelsiusz(double temperatura)
        {
            temperatura = (temperatura / 1.8) - 273.15;
            return temperatura;
        }
        public double CelsiuszToRankine(double temperatura)
        {
            temperatura = (temperatura + 273.15) * 1.8;
            return temperatura;
        }

        //public double FarhenheitToKelvin(double temperature)
        //{
        //    return (temperature + 459.67) * 5 / 9;
        //}
        //public double CF(double temperature)
        //{
        //    return (temperature * 1.8) + 32;
        //}
        //public double CelsiusToKelvin(double temperature)
        //{
        //    return temperature + 273.15;
        //}
        //public double KelvinToCelsius(double temperature)
        //{
        //    return temperature - 273.15;
        //}
        //public double KelvinToFarhenheit(double temperature)
        //{
        //    return temperature - 459.67;
        //}
    }
}
