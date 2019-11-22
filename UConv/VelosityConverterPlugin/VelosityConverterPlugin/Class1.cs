using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitConverter.Services;

namespace VelosityConverterPlugin
{
    public class VelosityConverter : IConverter
    {
        public string Name => "Prędkości";

        public List<string> Units => new List<string>(new[]
        {
        "Kilometr na godzinę",
        "Mila na godzinę",
        "Kilometr na sekundę",
        "Mila na sekundę",
        "Metr na sekundę",
        "Mach",
        "Węzeł"
        });

        public decimal Convert(string temp, float input)
        {
            float value = 0;
            switch (temp)
            {
                case "Kilometr na godzinę":
                    value = input * 3.6f;
                    break;
                case "Mila na godzinę":
                    value = input * 2.2369f;
                    break;
                case "Kilometr na sekundę":
                    value = input * 0.001f;
                    break;
                case "Mila na sekundę":
                    value = input * 0.0006f;
                    break;
                case "Metr na sekundę":
                    value = input;
                    break;
                case "Mach":
                    value = input * 0.0029f;
                    break;
                case "Węzeł":
                    value = input * 1.9438f;
                    break;
            }
            value = System.Convert.ToSingle(value.ToString());
            return (decimal)value;
        }

        public float toBaseUnit(string temp, float input)
        {
            float value = 0;
            switch (temp)
            {
                case "Kilometr na godzinę":
                    value = input * 0.2778f;
                    break;
                case "Mila na godzinę":
                    value = input * 0.447f;
                    break;
                case "Kilometr na sekundę":
                    value = input * 1000 ;
                    break;
                case "Mila na sekundę":
                    value = input * 1609.344f;
                    break;
                case "Metr na sekundę":
                    value = input;
                    break;
                case "Mach":
                    value = input * 340.2778f;
                    break;
                case "Węzeł":
                    value = input * 0.5144f;
                    break;
            }
            value = System.Convert.ToSingle(value.ToString());
            return value;
        }
    }
}
