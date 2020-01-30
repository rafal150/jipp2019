using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter.Services
{
    public class MasaKonwerter : IKonwerter
    {
        public string Name => "Masy: mg, dkg, kg, t, g";

        public List<string> Units => new List<string>(new[] {"mg", "dkg", "kg", "T", "g" });

        public double Convert(string unitFrom, string unitTo, double value)
        {
            if (unitFrom == "kg" && unitTo == "T")
            {
                return value * 1000;
            }
            else if (unitFrom == "kg" && unitTo == "g")
            {
                return value / 100;
            }
            else if (unitFrom == "kg" && unitTo == "mg")
            {
                return value * 10000000;
            }
            else if (unitFrom == "kg" && unitTo == "dkg")
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
            else if (unitFrom == "T" && unitTo == "mg")
            {
                return value * 10000000;
            }
            else if (unitFrom == "T" && unitTo == "dkg")
            {
                return value * 100000;
            }
            else if (unitFrom == "g" && unitTo == "kg")
            {
                return value * 100;
            }
            else if (unitFrom == "g" && unitTo == "T")
            {
                return value / 100000;
            }
            else if (unitFrom == "g" && unitTo == "mg")
            {
                return value * 100;
            }
            else if (unitFrom == "g" && unitTo == "dkg")
            {
                return value * 0.1;
            }
            else if (unitFrom == "mg" && unitTo == "kg")
            {
                return value * 10000000;
            }
            else if (unitFrom == "mg" && unitTo == "T")
            {
                return value * 100000000;
            }
            else if (unitFrom == "mg" && unitTo == "dkg")
            {
                return value * 10000;
            }
            else if (unitFrom == "mg" && unitTo == "g")
            {
                return value * 0.001;
            }
            else if (unitFrom == "dkg" && unitTo == "kg")
            {
                return value * 0.01;
            }
            else if (unitFrom == "dkg" && unitTo == "T")
            {
                return value * 1000000;
            }
            else if (unitFrom == "dkg" && unitTo == "mg")
            {
                return value * 10000;
            }
            else if (unitFrom == "dkg" && unitTo == "g")
            {
                return value * 10;
            }
            else
                return value;
        }
    }
}

