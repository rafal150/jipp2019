using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter.Services
{
    public class PojemnoscKonwerter : IKonwerter
    {
        public string Name => "Pojemnosc: L, DL, ML";

        public List<string> Units => new List<string>(new[] { "L", "DL", "ML" });


        public double Convert(string unitFrom, string unitTo, double value)
        {
            if (unitFrom == "L" && unitTo == "DL")
            {
                return value * 10;
            }
            else if (unitFrom == "L" && unitTo == "ML")
            {
                return value * 1000;
            }
            else if (unitFrom == "DL" && unitTo == "ML")
            {
                return value * 100;
            }
            else if (unitFrom == "DL" && unitTo == "L")
            {
                return value * 0.1;
            }
            else if (unitFrom == "ML" && unitTo == "L")
            {
                return value * 0.001;
            }
            else if (unitFrom == "ML" && unitTo == "DL")
            {
                return value * 0.01;
            }
            else
                return value;
        }
    }

}
