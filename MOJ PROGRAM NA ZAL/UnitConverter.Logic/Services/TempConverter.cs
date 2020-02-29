using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterZSQLiAZUREiPLUGIN.Services
{
    public class TempConverter : IKonwerter
    {
        public string Name => "Czas";

        public List<string> Units => new List<string>(new[] { "Dni", "Wiek(100lat)" });

        public decimal Convert(string unitFrom, string unitTo, decimal value)
        {

            if (unitFrom == "Dni" && unitTo == "Wiek(100lat)")
            {
                value= value/(365 * 100);
                return value;
            }

            else if (unitFrom == "Wiek(100lat)")
            {
                value = value * 36500;
                return value;
            }
           

            else
                return value; 
            }

   
        
    }
}
