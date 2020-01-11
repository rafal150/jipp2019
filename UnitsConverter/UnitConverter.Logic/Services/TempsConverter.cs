using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Units_Converter.Services
{
    public class TempsConverter : IConverter
    {
        public string Name => "Temperatures";

        public List<string> Units => new List<string>(new[] { "Celsius", "Fahrenheit", "Kelvin", "Rankine" });

        public decimal Convert(string unitFrom, string unitTo, decimal value)
        {
            decimal unitFromD = value;
           
                if (unitFrom == "Celsius")
                {
                    if (unitTo == "Celsius") value = unitFromD;
                    else if (unitTo == "Fahrenheit") value = ((9 * unitFromD / 5) + 32);
                    else if (unitTo == "Kelvin") value = (unitFromD - 273.15m);
                    else if (unitTo == "Rankine") value = (9 * (unitFromD + 273.15m) / 5);
                    
                }
                else if (unitFrom == "Fahrenheit")
                {
                    if (unitTo == "Fahrenheit") value = unitFromD;
                    else if (unitTo == "Celsjusz") value = (5 * (unitFromD - 32m) / 9);
                    else if (unitTo == "Kelvin") value = (5 * (unitFromD + 459.67m) / 9);
                    else if (unitTo == "Rankine") value = (unitFromD + 459.67m);
                    
                }
                else if (unitFrom == "Kelvin")
                {
                    if (unitTo == "Kelvin") value = unitFromD;
                    else if (unitTo == "Celsjusz") value = (unitFromD - 273.15m);
                    else if (unitTo == "Fahrenheit") value = (9 * unitFromD / 5 - 459.67m);
                    else if (unitTo == "Rankine") value = (unitFromD * 9 / 5);
                    
                }
                else if (unitFrom == "Rankine")
                {
                    if (unitTo == "Rankine") value = unitFromD;
                    else if (unitTo == "Celsjusz") value = ((unitFromD - 491.67m) * 5 / 9);
                    else if (unitTo == "Fahrenheit") value = (unitFromD - 459.67m);
                    else if (unitTo == "Kelvin") value = (unitFromD * 5 / 9);
                    
                }
            return value;
        }
    }
}