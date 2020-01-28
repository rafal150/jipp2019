using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter.ConversionTypes {
    class Temperature : AbstractConversionType {
        public Temperature() {
            ComboboxItems = new string[] {
                "Celsius",
                "Fahrenheit",
                "Kelvin",
            };
        }
        public double ConvertCelsiusToFahrenheit(double value) {
            return ((9.0 / 5.0) * value + 32.0);
        }
        public double ConvertCelsiusToKelvin(double value) {
            return value + 273.15;
        }
        public double ConvertFahrenheitToCelsius(double value) {
            return ((5.0 / 9.0) * (value - 32.0));
        }
        public double ConvertFahrenheitToKelvin(double value) {
            return ConvertCelsiusToKelvin(ConvertFahrenheitToCelsius(value));
        }
        public double ConvertKelvinToCelsius(double value) {
            return value - 273.15;
        }
        public double ConvertKelvinToFahrenheit(double value) {
            return ConvertCelsiusToFahrenheit(ConvertKelvinToCelsius(value));
        }
    }
}
