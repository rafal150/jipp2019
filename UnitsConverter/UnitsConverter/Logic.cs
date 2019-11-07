using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitsConverter
{
    static class Logic
    {

        #region temperatury
        public static double FahrenheitToCelsius(double fahrenheit) =>
            (fahrenheit - 32.0) / 1.8;

        public static double CelsiusToFahrenheit(double celsius) =>
            (celsius * 1.8) + 32.0;

        public static double CelsiusToKelvin(double celsius) =>
           celsius + 273.15;

        public static double KelvinToCelsius(double kelvin) =>
           kelvin - 273.15;

        public static double CelsiusToRankine(double celsius) =>
            (celsius + 273.15) * 1.8;

        public static double RankineToCelsius(double rankine) =>
            (rankine / 1.8) - 273.15;

        #endregion



        public static double FindLengthUnit(string unit)
        {
            string[] lengthUnits = new string[] { "mm", "cm", "dcm", "m", "km", "cal", "stopa", "jard", "mila", "kabel", "mila morska" };
            double[] lengthCoefficient = new double[] { 1000, 100, 10, 1, 0.001, 39.3700787, 3.2808399, 1.093613, 0.000621371192, 0.0054, 0.0005399999568000035 };

            for (int i = 0; i < lengthUnits.Length; i++)
                if (unit == lengthUnits[i])
                    return lengthCoefficient[i];

            return 0;
        }

        public static double FindWeightUnit(string unit)
        {
            string[] weightUnits = new string[] { "mg", "g", "dkg", "kg", "T", "uncja", "funt", "karat", "kwintal" };
            double[] weightCoefficient = new double[] { 1000000, 1000, 100, 1, 0.001, 35.273962, 2.204623, 4999.999985, 0.01 };

            for (int i = 0; i < weightUnits.Length; i++)
                if (unit == weightUnits[i])
                    return weightCoefficient[i];

            return 0;
        }


        public static double CheckTempUnits(string convertFrom, string convertTo, double valueFrom)
        {


            if (convertFrom == "K")
            {
                if (convertTo == "°C")
                    return KelvinToCelsius(valueFrom);
                else if (convertTo == "°F")
                    return CelsiusToFahrenheit(KelvinToCelsius(valueFrom));
                else if (convertTo == "°Rank")
                    return CelsiusToRankine(KelvinToCelsius(valueFrom));
            }
            else if (convertFrom == "°C")
            {
                if (convertTo == "K")
                    return CelsiusToKelvin(valueFrom);
                else if (convertTo == "°F")
                    return CelsiusToFahrenheit(valueFrom);
                else if (convertTo == "°Rank")
                    return CelsiusToRankine(valueFrom);
            }
            else if (convertFrom == "°F")
            {
                if (convertTo == "°C")
                    return FahrenheitToCelsius(valueFrom);
                else if (convertTo == "K")
                    return CelsiusToKelvin(FahrenheitToCelsius(valueFrom));
                else if (convertTo == "°Rank")
                    return CelsiusToRankine(FahrenheitToCelsius(valueFrom));
            }
            else if (convertFrom == "°Rank")
            {
                if (convertTo == "°C")
                    return RankineToCelsius(valueFrom);
                else if (convertTo == "K")
                    return CelsiusToKelvin(RankineToCelsius(valueFrom));
                else if (convertTo == "°F")
                    return CelsiusToFahrenheit(RankineToCelsius(valueFrom));
            }

            return 0;
        }


        public static double CheckLengthUnits(string convertFrom, string convertTo, double valueFrom)
        {
            return (valueFrom / FindLengthUnit(convertFrom)) * FindLengthUnit(convertTo);

        }

        public static double CheckWeightUnits(string convertFrom, string convertTo, double valueFrom)
        {
            return (valueFrom / FindWeightUnit(convertFrom)) * FindWeightUnit(convertTo);

        }


        


    }
}
