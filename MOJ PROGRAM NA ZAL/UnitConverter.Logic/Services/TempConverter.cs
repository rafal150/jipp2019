using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterZSQLiAZUREiPLUGIN.Services
{
    public class TempConverter : IKonwerter
    {
        public string Name => "Temperatura";

        public List<string> Units => new List<string>(new[] { "Celsjusz", "Fahrenheit", "Kelvin", "Rankine" });

        public decimal Convert(string unitFrom, string unitTo, decimal value)
        {

            if (unitFrom == "Celsjusz" )
            {

                return value;
            }

            else if (unitFrom == "Fahrenheit" )
            {
                return value;
            }
            else if (unitFrom == "Kelvin" )
            {
                return value;
            }
            else if (unitFrom == "Rankine" )
            {
                return value;
            }

            else
                return value; 
            }

   
        
    }
}
