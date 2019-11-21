using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace konwerter.services
{
    public class WeightConverter : IConverter
    {
        public string Name => "Weights";

        public List<string> Units => new List<string>(new[] { "miligram", "gram", "dekagram", "kilogram", "ton", "ounce", "pound", "carat","quintal" });

        public decimal Convert(string inputUnit, string outputUnit, decimal value)
        {
            decimal result = value;

            // Convert to kilograms
            switch (inputUnit)
            {
                case "miligram":
                    result = decimal.Multiply(value, 0.0000001M);
                    break;

                case "gram":
                    result = decimal.Multiply(value, 0.001M);
                    break;

                case "dekagram":
                    result = decimal.Multiply(value, 0.01M);
                    break;

                case "ton":
                    result = decimal.Multiply(value, 1000M);
                    break;

                case "ounce":
                    result = decimal.Multiply(value, 0.0283495231M);
                    break;

                case "pound":
                    result = decimal.Multiply(value, 0.45359237M);
                    break;

                case "carat":
                    result = decimal.Multiply(value, 0.0002M);
                    break;

                case "quintal":
                    result = decimal.Multiply(value, 100M);
                    break;
            }

            // Convert from kilograms to selected unit
            switch (outputUnit)
            {
                case "miligram":
                    result = decimal.Divide(result, 0.0000001M);
                    break;

                case "gram":
                    result = decimal.Divide(result, 0.001M);
                    break;

                case "dekagram":
                    result = decimal.Divide(result, 0.01M);
                    break;

                case "ton":
                    result = decimal.Divide(result, 1000M);
                    break;

                case "ounce":
                    result = decimal.Multiply(result, 35.27396195M);
                    break;

                case "pound":
                    result = decimal.Multiply(result, 2.2046226218M);
                    break;

                case "carat":
                    result = decimal.Multiply(result, 5000);
                    break;

                case "quintal":
                    result = decimal.Divide(result, 100M);
                    break;
            }

            return result;
        }
    }
}