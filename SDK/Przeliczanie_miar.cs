using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter_jednostek
{
    public class Przeliczanie_miar
    {
        public double A { get; }
        public double B { get; }
        public int Wejscie_ID { get; }
        public int Wyjscie_ID { get; }

        public Przeliczanie_miar(double a, double b, int wejscie_ID, int wyjscie_ID)
        {
            A = a;
            B = b;
            Wejscie_ID = wejscie_ID;
            Wyjscie_ID = wyjscie_ID;
        }
    }
}

