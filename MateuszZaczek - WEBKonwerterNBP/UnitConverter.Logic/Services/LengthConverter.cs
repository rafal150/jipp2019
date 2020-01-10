using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterZSQLiAZUREiPLUGIN.Services
{
    public class LengthConverter : KonwerterInterfejs
    {
        public string Name => "Długości";

        public List<string> Units => new List<string>(new[] { "m", "km" , "cm"});

        public decimal Convert(string unitFrom, string unitTo, decimal value)
        {
                       
            if (unitFrom == "cm" && unitTo =="m")
            {
                return value * 10; 
            }
            else if (unitFrom == "cm" && unitTo == "km")
            {
                return value * 10000;
            }
            else if (unitFrom == "km" && unitTo == "cm")
            {
                return value / 10000;
            }
            else if (unitFrom == "km" && unitTo == "m")
            {
                return value / 1000;
            }
            else if (unitFrom == "m" && unitTo == "cm")
            {
                return value / 10;
            }
            else if (unitFrom == "m" && unitTo == "km")
            {
                return value / 1000;
            }

            else
                return value;
        }
    }
    }

