using System;
using System.Collections.Generic;
using System.Text;

namespace Konwerter_jednostek
{
    public class Wspolczynniki //pobiera wspolczynniki
    {
        public double A { get; }
        public double B { get; }
        public bool CzyOdwrotne { get; }

        public Wspolczynniki(double a, double b, bool czyOdwrotne)
        {
            A = a;
            B = b;
            CzyOdwrotne = czyOdwrotne;
        }
    }
}
