using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unitconverter.Services
{
    class DlugosciKonwerter : IConverter
    {
        public string Name => "Dlugosci";

        public List<string> Units => new List<string>(new[] { "mm", "cm", "dcm", "m", "km", "cal", "stopa", "jard", "mila", "kabel", "mila morska" });

        public double Convert(string nazwa1, string nazwa2, double wartosc)
        {
            int wyjscie = (int)wartosc;
            if (nazwa1 == nazwa2) { return wyjscie; }
            //na metry
            if (nazwa1 == "mm") { wartosc = wartosc * 0.001; }
            if (nazwa1 == "cm") { wartosc = wartosc * 0.01; }
            if (nazwa1 == "dcm") { wartosc = wartosc * 0.1; }
            if (nazwa1 == "km") { wartosc = wartosc * 1000; }
            if (nazwa1 == "cal") { wartosc = wartosc * 0.0254; }
            if (nazwa1 == "stopa") { wartosc = wartosc * 0.3048; }
            if (nazwa1 == "jard") { wartosc = wartosc * 0.9144; }
            if (nazwa1 == "mila") { wartosc = wartosc * 1609.344; }
            if (nazwa1 == "kabel") { wartosc = wartosc * 185.2; }
            if (nazwa1 == "mila morska") { wartosc = wartosc * 1852; }
            //na reszte
            if (nazwa2 == "mm") { wartosc = wartosc * 1000; }
            if (nazwa2 == "cm") { wartosc = wartosc * 100; }
            if (nazwa2 == "dcm") { wartosc = wartosc * 10; }
            if (nazwa2 == "km") { wartosc = wartosc * 0.001; }
            if (nazwa2 == "cal") { wartosc = wartosc * 39.370079; }
            if (nazwa2 == "stopa") { wartosc = wartosc * 3.2808399; }
            if (nazwa2 == "jard") { wartosc = wartosc * 1.0936133; }
            if (nazwa2 == "mila") { wartosc = wartosc * 0.00062137119; }
            if (nazwa2 == "kabel") { wartosc = wartosc * 0.0053995680; }
            if (nazwa2 == "mila morska") { wartosc = wartosc * 0.00053995680; }
            wyjscie = (int)wartosc;
            return wyjscie;
        }
    }
}
