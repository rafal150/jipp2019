using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unitconverter
{
    class Temperatury
    {
        //public string[] rodzaj = new string[3] { "Temperatury", "Długości", "Masy" };
        public string[] temp = new string[4] { "C", "F", "K", "R" };
        //public string[] dlug = new string[11] { "mm", "cm", "dcm", "m", "km", "cal", "stopa", "jard", "mila", "kabel", "mila morska" };
        //public string[] masy = new string[9] { "mg", "g", "dkg", "kg", "T", "uncja", "funt", "karat", "kwintal" };

        public int licztemp(string nazwa1, string nazwa2, double wartosc)
        {
            int wyjscie = (int)wartosc;
            if (nazwa1 == nazwa2) { return wyjscie; }
            //na C
            if (nazwa1 == "F") { wartosc = (double)5 / (double)9 * (wartosc - 32); }
            if (nazwa1 == "K") { wartosc = wartosc - 273.15; }
            if (nazwa1 == "R") { wartosc = (wartosc - 491.67) * 5 / 9; }
            //na reszte
            if (nazwa2 == "F") { wartosc = (double)9 / (double)5 * wartosc + 32; }
            if (nazwa2 == "R") { wartosc = wartosc * 1.8 + 491.67; }
            if (nazwa2 == "K") { wartosc = wartosc + 273.15; }
            wyjscie = (int)wartosc;
            return wyjscie;
        }
        /*
        public int liczdlug(string nazwa1, string nazwa2, double wartosc)
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
        */
        /*
        public int liczmasy(string nazwa1, string nazwa2, double wartosc)
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
        */
    }
}