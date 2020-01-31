using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Text;
using Converter.Calculator;

namespace Converter
{
    public class TemperatureCalculator : ICalculator
    {
        public TemperatureCalculator()
        {
        }

        public decimal Celsius { get; set; }

        public decimal Kelwin { get; set; }

        public decimal Fahrenheit { get; set; }

        public string Name => "Temperature";

        public List<string> Units => new List<string>(new[] { "Celsius", "Fahrenheit", "Kelwin" });

        public decimal Convert(string unitFrom, string unitTo, decimal value)
        {
            decimal convertedValue = 0;

            if (unitFrom == "Fahrenheit")
            {
                Fahrenheit = value;
                Kelwin = (value + 459.68M) * 5 / 9;
                Celsius = (value - 32) * 5 / 9;
            }
            else if (unitFrom == "Celsius")
            {
                Celsius = value;
                Fahrenheit = (value * 9) / 5 + 32;
                Kelwin = (Fahrenheit + 459.68M) * 5 / 9;
            }
            else
            {
                Celsius = value - 273.15M;
                Kelwin = value;
                Fahrenheit = (Celsius * 9) / 5 + 32;
            }

            if (unitTo == "Fahrenheit") return Fahrenheit;
            else if (unitTo == "Celsius") return Celsius;
            else return Kelwin;
        }
    
    }
}