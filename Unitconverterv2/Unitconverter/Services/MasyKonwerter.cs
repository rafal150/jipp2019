using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unitconverter.Services
{
    class MasyKonwerter : IConverter
    {
        public string Name => "Masa";

        public List<string> Units => new List<string>(new[] { "mg", "g", "dkg", "kg", "T", "uncja", "funt", "karat", "kwintal" });

        public double Convert(string nazwa1, string nazwa2, double wartosc)
        {
            int wyjscie = (int)wartosc;
            if (nazwa1 == nazwa2) { return wyjscie; }
            //na kg
            if (nazwa1 == "mg") { wartosc = wartosc * 0.000001; }
            if (nazwa1 == "g") { wartosc = wartosc * 0.001; }
            if (nazwa1 == "dkg") { wartosc = wartosc * 0.01; }
            if (nazwa1 == "T") { wartosc = wartosc * 1000; }
            if (nazwa1 == "uncja") { wartosc = wartosc * 0.028349523; }
            if (nazwa1 == "funt") { wartosc = wartosc * 0.45359237; }
            if (nazwa1 == "karat") { wartosc = wartosc * 0.000205196548333; }
            if (nazwa1 == "kwintal") { wartosc = wartosc * 100; }
            //na reszte
            if (nazwa2 == "mg") { wartosc = wartosc * 1000000; }
            if (nazwa2 == "g") { wartosc = wartosc * 1000; }
            if (nazwa2 == "dkg") { wartosc = wartosc * 100; }
            if (nazwa2 == "T") { wartosc = wartosc * 0.001; }
            if (nazwa2 == "uncja") { wartosc = wartosc * 35.273962; }
            if (nazwa2 == "funt") { wartosc = wartosc * 2.2046226; }
            if (nazwa2 == "karat") { wartosc = wartosc * 48733763219894; }
            if (nazwa2 == "kwintal") { wartosc = wartosc * 0.01; }
            wyjscie = (int)wartosc;
            return wyjscie;
        }
    }
}
