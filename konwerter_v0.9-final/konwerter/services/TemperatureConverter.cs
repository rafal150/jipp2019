using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace konwerter.services
{
    public class TemperatureConverter : IConverter
    {
        public string Name => "Temperatures";

        public List<string> Units => new List<string>(new[] { "Rankine", "kelvin", "Fahrenheit", "Celsius" });

        public decimal Convert(string inputUnit, string outputUnit, decimal inputValue)
        {
            decimal result = inputValue;

            // Convert input unit to kelvin
            switch (inputUnit)
            {
                case "Rankine":
                    result = decimal.Multiply(inputValue, 0.5555555556M);
                    break;

                case "Fahrenheit":
                    result = decimal.Multiply(decimal.Add(inputValue, 459.67M), decimal.Divide(5, 9));
                    break;

                case "celsius":
                    result = decimal.Add(inputValue, 273.15M);
                    break;
            }

            // Convert from kelvin to desired unit
            switch (outputUnit)
            {
                case "Rankine":
                    result = decimal.Multiply(result, 1.8M);
                    break;

                case "Fahrenheit":
                    result = decimal.Multiply(result, 1.8M);
                    result = decimal.Subtract(result, 459.67M);
                    break;

                case "celsius":
                    result = decimal.Subtract(result, 273.15M);
                    break;
            }

            return result;
        }
    }
}