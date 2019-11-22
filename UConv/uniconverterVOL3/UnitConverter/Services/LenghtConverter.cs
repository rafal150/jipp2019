using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter.Services
{
    class LenghtConverter : IConverter
    {
        public string Name => "Długości";

        public List<string> Units => new List<string>(new[]
        {
            "Milimetr",
            "Centymetr",
            "Decymetr",
            "Metr",
            "Kilometr",
            "Cal",
            "Stopa",
            "Jard",
            "Mila",
            "Mila morska"
        });

        public decimal Convert(string temp, float input)
        {
            float value = 0;
            switch (temp)
            {
                case "Milimetr":
                    value = input * 1000;
                    break;
                case "Centymetr":
                    value = input * 100;
                    break;
                case "Decymetr":
                    value = input * 10;
                    break;
                case "Metr":
                    value = input;
                    break;
                case "Kilometr":
                    value = input * 0.001f;
                    break;
                case "Cal":
                    value = input * 39.3701f;
                    break;
                case "Stopa":
                    value = input * 3.2808f;
                    break;
                case "Jard":
                    value = input * 1.0936f;
                    break;
                case "Mila":
                    value = input * 0.0006f;
                    break;
                case "Mila morska":
                    value = input * 0.0005f;
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
                case "Milimetr":
                    value = input * 0.001f;
                    break;
                case "Centymetr":
                    value = input * 0.01f;
                    break;
                case "Decymetr":
                    value = input * 0.10f;
                    break;
                case "Metr":
                    value = input;
                    break;
                case "Kilometr":
                    value = input * 1000;
                    break;
                case "Cal":
                    value = input * 0.03f;
                    break;
                case "Stopa":
                    value = input * 0.30f;
                    break;
                case "Jard":
                    value = input * 0.91f;
                    break;
                case "Mila":
                    value = input * 1609.34f;
                    break;
                case "Mila morska":
                    value = input * 1852.00f;
                    break;
            }
            value = System.Convert.ToSingle(value.ToString());
            return value;
        }
    } }

