using System;
using System.Collections.Generic;
using konwerter.services;

namespace VolumeConverterPlugin
{
    public class VolumeConverter : IConverter
    {
        public string Name => "Volume";

        public List<string> Units => new List<string>(new[] { "cubic milimeter", "cubic centimeter","cubic meter","mililiter","liter","gallon","quart"});

        public decimal Convert(string inputUnit, string outputUnit, decimal inputValue)
        {
            decimal result = inputValue;

            // convert to liters
            switch (inputUnit)
            {
                case "cubic milimeter":
                    result = decimal.Divide(inputValue, 1000000);
                    break;

                case "cubic centimeter":
                    result = decimal.Divide(inputValue, 1000);
                    break;

                case "cubic meter":
                    result = decimal.Multiply(inputValue, 1000);
                    break;

                case "mililiter":
                    result = decimal.Divide(inputValue, 1000);
                    break;

                case "gallon":
                    result = decimal.Multiply(inputValue, 3.785411784M);
                    break;

                case "quart":
                    result = decimal.Multiply(inputValue, 0.946352946M);
                    break;
                default:
                    break;
            }

            // convert from liters to selected unit
            switch (outputUnit)
            {
                case "cubic milimeter":
                    result = decimal.Multiply(result, 1000000);
                    break;

                case "cubic centimeter":
                    result = decimal.Multiply(result, 1000);
                    break;

                case "cubic meter":
                    result = decimal.Divide(result, 1000);
                    break;

                case "mililiter":
                    result = decimal.Multiply(result, 1000);
                    break;

                case "gallon":
                    result = decimal.Multiply(result, 0.2641720524M);
                    break;

                case "quart":
                    result = decimal.Multiply(result, 1.0566882094M);
                    break;
                default:
                    break;
            }

            return result;
        }
    }
}
