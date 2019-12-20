using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace konwerter.services
{
    public class LengthConverter : IConverter
    {
        public string Name => "Lenghts";

        public List<string> Units => new List<string>(new[] { "milimeter","centimeter","decimeter","meter","kilometer", "mile", "yard", "foot","inch","nautical mile", "cable lenght" });

        public decimal Convert(string inputUnit, string outputUnit, decimal value)
        {
            // Convert to meters
            decimal result = value;

            switch (inputUnit)
            {
                case "milimeter":
                    result = decimal.Multiply(value, 0.001M);
                    break;
                case "centimeter":
                    result = decimal.Multiply(value, 0.01M);
                    break;
                case "decimeter":
                    result = decimal.Multiply(value, 0.1M);
                    break;
                case "kilometer":
                    result = decimal.Multiply(value, 1000M);
                    break;
                case "mile":
                    result = decimal.Multiply(value, 1609.344M);
                    break;
                case "yard":
                    result = decimal.Multiply(value, 0.9144M);
                    break;
                case "foot":
                    result = decimal.Multiply(value, 0.3048M);
                    break;
                case "inch":
                    result = decimal.Multiply(value, 0.0254M);
                    break;
                case "nautical mile":
                    result = decimal.Multiply(value, 1852M);
                    break;
                case "cable lenght":
                    result = decimal.Multiply(value, 185.2M);
                    break;
            }

            // Convert from meters to selected unit
            switch (outputUnit)
            {
                case "milimeter":
                    result = decimal.Divide(result, 0.001M);
                    break;

                case "centimeter":
                    result = decimal.Divide(result, 0.01M);
                    break;

                case "decimeter":
                    result = decimal.Divide(result, 0.1M);
                    break;

                case "kilometer":
                    result = decimal.Divide(result, 1000M);
                    break;

                case "mile":
                    result = decimal.Multiply(result, 0.0006213712M);
                    break;

                case "yard":
                    result = decimal.Multiply(result, 1.0936132983M);
                    break;

                case "foot":
                    result = decimal.Multiply(result, 3.280839895M);
                    break;

                case "inch":
                    result = decimal.Multiply(result, 39.37007874M);
                    break;

                case "nautical mile":
                    result = decimal.Multiply(result, 0.000539956803M);
                    break;

                case "cable lenght":
                    result = decimal.Multiply(result, 0.004556722076M);
                    break;
            }

            return result;
        }
    }
}
