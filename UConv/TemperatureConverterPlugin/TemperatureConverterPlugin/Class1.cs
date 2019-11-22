using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitConverter.Services;

namespace TemperatureConverterPlugin
{
    public class TemperatureConverter: IConverter
    {
        public string Name => "Temperatury";

        public List<string> Units => new List<string>(new[] 
        {
            "Celsjusz", 
            "Kelvin", 
            "Fahrenheit" 
        });

        public decimal Convert(string temp, float input)
        {
            float value = 0;
            switch (temp)
            {
                case "Celsjusz":
                    value = input;
                    break;
                case "Fahrenheit":
                    value = input * 0.555555556f * (input + 32);
                    break;
                case "Kelvin":
                    value = input + 273.15f;
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
                case "Celsjusz":
                    value = input;
                    break;
                case "Fahrenheit":
                    value = 0.555555556f * (input - 32);
                    break;
                case "Kelvin":
                    value = input - 273.15f;
                    break;
            }
            value = System.Convert.ToSingle(value.ToString());
            return value;
        }
    }
}
