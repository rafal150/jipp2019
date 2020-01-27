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
        public float ConvertCelsiusToFahrenheit(float value) {
            return ((9.0f / 5.0f) * value + 32.0f);
        }
        public float ConvertCelsiusToKelvin(float value) {
            return value + 273.15f;
        }
        public float ConvertFahrenheitToCelsius(float value) {
            return ((5.0f / 9.0f) * (value - 32.0f));
        }
        public float ConvertFahrenheitToKelvin(float value) {
            return ConvertCelsiusToKelvin(ConvertFahrenheitToCelsius(value));
        }
        public float ConvertKelvinToCelsius(float value) {
            return value - 273.15f;
        }
        public float ConvertKelvinToFahrenheit(float value) {
            return ConvertCelsiusToFahrenheit(ConvertKelvinToCelsius(value));
        }
    }
}
