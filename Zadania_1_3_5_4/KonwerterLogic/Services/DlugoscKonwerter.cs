using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter.Services
{
    public class DlugoscKonwerter : IKonwerter
    {
        public string Name => "Dlugosci Konwenter: mm, m, km, cm";

        public List<string> Units => new List<string>(new[] {"mm", "m", "km", "cm" });

        public double Convert(string unitFrom, string unitTo, double value)
        {
            if (unitFrom == "cm" && unitTo == "m")
            {
                return value * 100;
            }
            else if (unitFrom == "cm" && unitTo == "km")
            {
                return value * 10000;
            }
            else if (unitFrom == "cm" && unitTo == "mm")
            {
                return value * 10;
            }
            else if (unitFrom == "km" && unitTo == "cm")
            {
                return value * 10000;
            }
            else if (unitFrom == "km" && unitTo == "m")
            {
                return value * 1000;
            }
            else if (unitFrom == "km" && unitTo == "mm")
            {
                return value * 100000;
            }
            else if (unitFrom == "m" && unitTo == "cm")
            {
                return value / 10;
            }
            else if (unitFrom == "m" && unitTo == "km")
            {
                return value / 1000;
            }
            else if (unitFrom == "m" && unitTo == "mm")
            {
                return value * 1000;
            }

            else
                return value;
        }
    }
}
