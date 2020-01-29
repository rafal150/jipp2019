using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterZSQLiAZUREiPLUGIN.Services
{
    public class TempConverter : KonwerterInterfejs
    {
        public string Name => "Temperatura";

        public List<string> Units => new List<string>(new[] { "Celsjusz", "Fahrenheit", "Kelvin", "Rankine" });

        public decimal Convert(string unitFrom, string unitTo, decimal value)
        {
            if (unitFrom == "Celsjusz" && unitTo == "Fahrenheit")
            {
                return 9 * value / 5 + 32;
            }

            else if (unitFrom == "Celsjusz" && unitTo == "Kelvin")
            {
                return value - 273;
            }
            else if (unitFrom == "Celsjusz" && unitTo == "Rankine")
            {
                return 9 * (value / +273);
            }

            if (unitFrom == "Fahrenheit" && unitTo == "Celsjusz")
            {
                return 5 * (value - 32) / 9;
            }
            else if (unitFrom == "Fahrenheit" && unitTo == "Kelvin")
            {
                return 5 * (value + 459) / 9;
            }
            else if (unitFrom == "Fahrenheit" && unitTo == "Rankine")
            {
                return value + 459;
            }

            if (unitFrom == "Kelvin" && unitTo == "Celsjusz")
            {
                return value - 273;
            }
            else if (unitFrom == "Kelvin" && unitTo == "Fahrenheit")
            {
                return 9 * value / 5 - 459;
            }
            else if (unitFrom == "Kelvin" && unitTo == "Rankine")
            {
                return value * 9 / 5;
            }


            if (unitFrom == "Rankine" && unitTo == "Celsjusz")
            {
                return (value - 491) * 5 / 9;
            }
            else if (unitFrom == "Rankine" && unitTo == "Fahrenheit")
            {
                return value - 459;
            }
            else if (unitFrom == "Rankine" && unitTo == "Kelvin")
            {
                return value * 5 / 9;
            }

            else
                return value; 
            }

   
        
    }
}
