using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitCoverterPart2.Services
{
    public class TemperatureConverter : IConverter
    {
        public string Name => "Temperatura";

        public List<string> Units => new List<string>(new[] { "C", "F", "K","R" });

        public decimal Convert(string unitFrom, string unitTo, decimal value)
        {
            decimal valueInCelsius = ConvertToCelsius(unitFrom, value);
            decimal result = 0;
            if (unitTo.Equals("C"))
            {
                result = valueInCelsius;
            }
            if (unitTo.Equals("F"))
            {
                result = ConvertFromCelsiusToFahrenheit(valueInCelsius);
            }
            if (unitTo.Equals("K"))
            {
                result = ConvertFromCelsiusToKelvin(valueInCelsius);
            }
            if (unitTo.Equals("R"))
            {
                result = ConvertFromCelsiusToRankine(valueInCelsius);
            }
            return result;
        }

        private decimal ConvertToCelsius(string unitFrom,  decimal value)
        {
            decimal result = 0;
            if (unitFrom.Equals("C"))
            {
                result = value;
            }
            else
            {
                if (unitFrom.Equals("F"))
                {
                    result = (value - 32) / (decimal)1.8;
                }
                if (unitFrom.Equals("K"))
                {
                    result = value - (decimal)273.15;
                }
                if (unitFrom.Equals("R"))
                {
                    result = (value - (decimal)491.67) * (decimal)(5.0 / 9.0);
                }
            }
            return result;
        }

        private decimal ConvertFromCelsiusToKelvin(decimal value)
        {
            return value + (decimal)273.15;
        }
        private decimal ConvertFromCelsiusToFahrenheit(decimal value)
        {
            return value * (decimal)1.8 + (decimal)32;
        }
        private decimal ConvertFromCelsiusToRankine(decimal value)
        {
            return value * (decimal)1.8 + (decimal)491.67;
        }
    }
}
