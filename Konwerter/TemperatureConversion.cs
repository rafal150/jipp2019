using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter
{
    class TemperatureConversion
    {
        public static double fromBase(double value)
        {
            double convertedTemperature = 0;
            switch(MainWindow.toUnit)
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

        public static double toBase(double value)
        {
            double convertedTemperature = 0;
            switch (MainWindow.fromUnit)
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

        public static double Convert(double convert)
        {
            return Math.Round(fromBase(toBase(convert)), 2);
        }
    }
}
