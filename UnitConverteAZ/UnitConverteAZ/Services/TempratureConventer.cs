using Converter.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverteAZ
{
    public class TemperatureConverter : IConverter
    {
        public string Name => "Temperatura";

        public List<string> Units => new List<string>(new[] { "Celciusz", "Kalvin", "Rankine", "Fahrenheit" });

        public double Convert(string unitFrom, string unitTo, double value)
        {
            double calcuatedValue = 0;
            switch (unitFrom)
            {

                case "Celciusz":
                    calcuatedValue = convertFromCelciusz(unitTo, value);
                    break;
                case "Fahrenheit":
                    calcuatedValue = convertFromFahrenheit(unitTo, value);
                    break;


                case "Kalvin":
                    calcuatedValue = convertFromKalvin(unitTo, value);
                    break;
                case "Rankine":
                    calcuatedValue = convertFromRankine(unitTo, value);
                    break;
                default:
                    return value;

            }

            return calcuatedValue;
        }

        public double convertFromCelciusz(string tounit, double value)
        {
            switch (tounit)
            {
                case "Kalvin":
                    return value + 273.15;
                case "Fahrenheit":
                    return ((value * 1.8) + 32);
                case "Rankine":
                    return ((value + 237.15) * 1.8);

                default:
                    return value;

            }
        }
        public double convertFromKalvin(string tounit, double value)
        {
            switch (tounit)
            {
                case "Celciusz":
                    return value - 273.15;
                case "Fahrenheit":
                    return ((value * 1.8) - 459.67); ;
                case "Rankine":
                    return (value * 1.8);
                default:
                    return value;

            }
        }


        public double convertFromFahrenheit(string tounit, double value)
        {
            switch (tounit)
            {

                case "Celciusz":
                    return (value - 32) / 1.8;
                case "Kalvin":
                    return (value + 459.67) * 5 / 9;

                case "Rankine":
                    return ((value - 32) + 491.67);

                default:
                    return value;

            }
        }
        public double convertFromRankine(string tounit, double value)
        {
            switch (tounit)
            {

                case "Celciusz":
                    return (value / 1.8) - 273.15;
                case "Kalvin":
                    return (value * 5 / 9);

                case "Fahrenheit":
                    return (value - 459.67);

                default:
                    return value;

            }
        }
    }
}