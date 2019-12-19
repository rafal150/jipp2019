using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Converter.SDK;

namespace Konwerter
{
    class TemperatureConversion : IConverter
    {
        public string Name => "Temperature";

        public List<string> Units => new List<string>(new[] { "Celsius", "Fahrenheit", "Kelvin", "Rankine" });
        public double Convert(string fromUnit, string toUnit, double value)
        {
           double fromBase(double v)
            {
                double convertedTemperature = 0;
                switch (toUnit)
                {
                    case "Celsius":
                        {
                            convertedTemperature = v;
                            break;
                        }
                    case "Fahrenheit":
                        {
                            convertedTemperature = (v * 1.8) + 32;
                            break;
                        }
                    case "Kelvin":
                        {
                            convertedTemperature = v + 273.15;
                            break;
                        }
                    case "Rankine":
                        {
                            convertedTemperature = (v + 273.15) * 1.8;
                            break;
                        }
                }
                return convertedTemperature;
            }

            double toBase(double v)
            {
                double convertedTemperature = 0;
                switch (fromUnit)
                {
                    case "Celsius":
                        {
                            convertedTemperature = v;
                            break;
                        }
                    case "Fahrenheit":
                        {
                            convertedTemperature = (v - 32) / 1.8;
                            break;
                        }
                    case "Kelvin":
                        {
                            convertedTemperature = v - 273.15;
                            break;
                        }
                    case "Rankine":
                        {
                            convertedTemperature = (v / 1.8) - 273.15;
                            break;
                        }
                }
                return convertedTemperature;
            }
            return Math.Round(fromBase(toBase(value)), 2);
        }
    }
}
