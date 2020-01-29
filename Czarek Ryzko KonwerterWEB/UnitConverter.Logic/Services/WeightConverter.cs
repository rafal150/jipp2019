using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterZSQLiAZUREiPLUGIN.Services
{
    public class WeightConverter : KonwerterInterfejs
    {
        public string Name => "Masy";

        public List<string> Units => new List<string>(new[] { "kg", "T", "g" });

        public decimal Convert(string unitFrom, string unitTo, decimal value)
        {
            if (unitFrom == "kg" && unitTo == "T")
            {
                return value / 1000;
            }
            else if (unitFrom == "kg" && unitTo == "g")
            {
                return value * 100;
            }
            else if (unitFrom == "T" && unitTo == "kg")
            {
                return value * 1000;
            }
            else if (unitFrom == "T" && unitTo == "g")
            {
                return value * 10000;
            }
            else if (unitFrom == "g" && unitTo == "kg")
            {
                return value / 100;
            }
            else if (unitFrom == "g" && unitTo == "T")
            {
                return value / 100000;
            }

            else
                return value;
        }
    }
}
