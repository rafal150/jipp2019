using Converter.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter
{
    class TemperatureConversion : IConverter
    {
        public string Name => "Temperature";

        public List<string> Units => new List<string>(new[] { "Celsius", "Fahrenheit", "Kelvin", "Rankine" });
        public double Convert(string fromUnit, string toUnit, double value)
        {
           double fromBase(double value)
            {
                double convertedTemperature = 0;
                switch (toUnit)
                {
                    case "Celsius":
                        {
                            convertedTemperature = value;
                            break;
                        }
                    case "Fahrenheit":
                        {
                            convertedTemperature = (value * 1.8) + 32;
                            break;
                        }
                    case "Kelvin":
                        {
                            convertedTemperature = value + 273.15;
                            break;
                        }
                    case "Rankine":
                        {
                            convertedTemperature = (value + 273.15) * 1.8;
                            break;
                        }
                }
                return convertedTemperature;
            }

            double toBase(double value)
            {
                double convertedTemperature = 0;
                switch (fromUnit)
                {
                    case "Celsius":
                        {
                            convertedTemperature = value;
                            break;
                        }
                    case "Fahrenheit":
                        {
                            convertedTemperature = (value - 32) / 1.8;
                            break;
                        }
                    case "Kelvin":
                        {
                            convertedTemperature = value - 273.15;
                            break;
                        }
                    case "Rankine":
                        {
                            convertedTemperature = (value / 1.8) - 273.15;
                            break;
                        }
                }
                return convertedTemperature;
            }
            return Math.Round(fromBase(toBase(value)), 2);
        }
    }
}
