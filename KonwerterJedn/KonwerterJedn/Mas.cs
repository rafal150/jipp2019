using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterJedn
{
    class Mas
    {
        public string MasFrom;
        public string MasTo;
        public double Wartosc;
        public double Wynik;
        public string Type = "Masa";
        public string WynikString;

        public Mas(string MasFrom, string MasTo, double Wartosc)
        {
            if (MasFrom == "mg" && MasTo == "mg")
            {
                Wynik = Wartosc;
                WynikString = Wynik.ToString();
            }
            if (MasFrom == "mg" && MasTo == "g")
            {
                Wynik = (Wartosc * 0.001);
                WynikString = Wynik.ToString();
            }
            if (MasFrom == "mg" && MasTo == "dkg")
            {
                Wynik = (Wartosc * 0.0001);
                WynikString = Wynik.ToString();
            }
            if (MasFrom == "mg" && MasTo == "kg")
            {
                Wynik = (Wartosc * 0.000001);
                WynikString = Wynik.ToString();
            }
            if (MasFrom == "mg" && MasTo == "t")
            {
                Wynik = (Wartosc * 0.000000001);
                WynikString = Wynik.ToString();
            }
            if (MasFrom == "mg" && MasTo == "uncja")
            {
                Wynik = (Wartosc * 0.000035274);
                WynikString = Wynik.ToString();
            }
            if (MasFrom == "mg" && MasTo == "funt")
            {
                Wynik = (Wartosc * 0.0000022046);
                WynikString = Wynik.ToString();
            }
            if (MasFrom == "mg" && MasTo == "karat")
            {
                Wynik = (Wartosc * 0.005);
                WynikString = Wynik.ToString();
            }
            if (MasFrom == "mg" && MasTo == "kwintal")
            {
                Wynik = (Wartosc * 0.00000001);
                WynikString = Wynik.ToString();
            }

            ///////////g////////////
            if (MasFrom == "g" && MasTo == "g")
            {
                Wynik = Wartosc;
                WynikString = Wynik.ToString();
            }
            if (MasFrom == "g" && MasTo == "mg")
            {
                Wynik = (Wartosc * 1000);
                WynikString = Wynik.ToString();
            }
            if (MasFrom == "g" && MasTo == "dkg")
            {
                Wynik = (Wartosc * 0.1);
                WynikString = Wynik.ToString();
            }
            if (MasFrom == "g" && MasTo == "kg")
            {
                Wynik = (Wartosc * 0.001);
                WynikString = Wynik.ToString();
            }
            if (MasFrom == "g" && MasTo == "t")
            {
                Wynik = (Wartosc * 0.000001);
                WynikString = Wynik.ToString();
            }

            if (MasFrom == "g" && MasTo == "uncja")
            {
                Wynik = (Wartosc * 0.0353);
                WynikString = Wynik.ToString();
            }
            if (MasFrom == "g" && MasTo == "funt")
            {
                Wynik = (Wartosc * 0.0022);
                WynikString = Wynik.ToString();
            }
            if (MasFrom == "g" && MasTo == "karat")
            {
                Wynik = (Wartosc * 5);
                WynikString = Wynik.ToString();
            }
            if (MasFrom == "g" && MasTo == "kwintal")
            {
                Wynik = (Wartosc * 0.00001);
                WynikString = Wynik.ToString();
            }



            ////dkg/////
            if (MasFrom == "dkg" && MasTo == "dkg")
            {
                Wynik = Wartosc;
                WynikString = Wynik.ToString();
            }
            if (MasFrom == "dkg" && MasTo == "g")
            {
                Wynik = (Wartosc * 10000);
                WynikString = Wynik.ToString();
            }
            if (MasFrom == "dkg" && MasTo == "mg")
            {
                Wynik = (Wartosc * 10);
                WynikString = Wynik.ToString();
            }
            if (MasFrom == "dkg" && MasTo == "kg")
            {
                Wynik = (Wartosc * 0.01);
                WynikString = Wynik.ToString();
            }
            if (MasFrom == "dkg" && MasTo == "t")
            {
                Wynik = (Wartosc * 0.00001);
                WynikString = Wynik.ToString();
            }

            if (MasFrom == "dkg" && MasTo == "uncja")
            {
                Wynik = (Wartosc * 0.3527);
                WynikString = Wynik.ToString();
            }
            if (MasFrom == "dkg" && MasTo == "funt")
            {
                Wynik = (Wartosc * 0.022);
                WynikString = Wynik.ToString();
            }
            if (MasFrom == "dkg" && MasTo == "karat")
            {
                Wynik = (Wartosc * 50);
                WynikString = Wynik.ToString();
            }
            if (MasFrom == "dkg" && MasTo == "kwintal")
            {
                Wynik = (Wartosc * 0.0001);
                WynikString = Wynik.ToString();
            }



            ////kg/////
            if (MasFrom == "kg" && MasTo == "kg")
            {
                Wynik = Wartosc;
                WynikString = Wynik.ToString();
            }
            if (MasFrom == "kg" && MasTo == "g")
            {
                Wynik = (Wartosc * 1000000);
                WynikString = Wynik.ToString();
            }
            if (MasFrom == "kg" && MasTo == "mg")
            {
                Wynik = (Wartosc * 1000);
                WynikString = Wynik.ToString();
            }
            if (MasFrom == "kg" && MasTo == "dkg")
            {
                Wynik = (Wartosc * 100);
                WynikString = Wynik.ToString();
            }
            if (MasFrom == "kg" && MasTo == "t")
            {
                Wynik = (Wartosc * 0.001);
                WynikString = Wynik.ToString();
            }

            if (MasFrom == "kg" && MasTo == "uncja")
            {
                Wynik = (Wartosc * 35.274);
                WynikString = Wynik.ToString();
            }
            if (MasFrom == "kg" && MasTo == "funt")
            {
                Wynik = (Wartosc * 2.2046);
                WynikString = Wynik.ToString();
            }
            if (MasFrom == "kg" && MasTo == "karat")
            {
                Wynik = (Wartosc * 5000);
                WynikString = Wynik.ToString();
            }
            if (MasFrom == "kg" && MasTo == "kwintal")
            {
                Wynik = (Wartosc * 0.01);
                WynikString = Wynik.ToString();
            }




            ////t/////
            if (MasFrom == "t" && MasTo == "t")
            {
                Wynik = Wartosc;
                WynikString = Wynik.ToString();
            }
            if (MasFrom == "t" && MasTo == "g")
            {
                Wynik = (Wartosc * 1.000000);
                WynikString = Wynik.ToString();
            }
            if (MasFrom == "t" && MasTo == "mg")
            {
                Wynik = (Wartosc * 1.000000000);
                WynikString = Wynik.ToString();
            }
            if (MasFrom == "t" && MasTo == "dkg")
            {
                Wynik = (Wartosc * 100000);
                WynikString = Wynik.ToString();
            }
            if (MasFrom == "t" && MasTo == "kg")
            {
                Wynik = (Wartosc * 1000);
                WynikString = Wynik.ToString();
            }
            if (MasFrom == "t" && MasTo == "uncja")
            {
                Wynik = (Wartosc * 35273.9621);
                WynikString = Wynik.ToString();
            }
            if (MasFrom == "t" && MasTo == "funt")
            {
                Wynik = (Wartosc * 2204.6226);
                WynikString = Wynik.ToString();
            }
            if (MasFrom == "t" && MasTo == "karat")
            {
                Wynik = (Wartosc * 5.000000);
                WynikString = Wynik.ToString();
            }
            if (MasFrom == "t" && MasTo == "kwintal")
            {
                Wynik = (Wartosc * 10);
                WynikString = Wynik.ToString();
            }



            /////uncja//////
            if (MasFrom == "uncja" && MasTo == "uncja")
            {
                Wynik = Wartosc;
                WynikString = Wynik.ToString();
            }
            if (MasFrom == "uncja" && MasTo == "mg")
            {
                Wynik = (Wartosc * 28349.523);
                WynikString = Wynik.ToString();
            }
            if (MasFrom == "uncja" && MasTo == "g")
            {
                Wynik = (Wartosc * 28.3495);
                WynikString = Wynik.ToString();
            }
            if (MasFrom == "uncja" && MasTo == "dkg")
            {
                Wynik = (Wartosc * 2.835);
                WynikString = Wynik.ToString();
            }
            if (MasFrom == "uncja" && MasTo == "kg")
            {
                Wynik = (Wartosc * 0.0283);
                WynikString = Wynik.ToString();
            }
            if (MasFrom == "uncja" && MasTo == "t")
            {
                Wynik = (Wartosc * 0.00000283);
                WynikString = Wynik.ToString();
            }
            if (MasFrom == "uncja" && MasTo == "funt")
            {
                Wynik = (Wartosc * 0.0625);
                WynikString = Wynik.ToString();
            }
            if (MasFrom == "uncja" && MasTo == "karat")
            {
                Wynik = (Wartosc * 141.75);
                WynikString = Wynik.ToString();
            }
            if (MasFrom == "uncja" && MasTo == "kwintal")
            {
                Wynik = (Wartosc * 0.0003);
                WynikString = Wynik.ToString();
            }

            ////funt///////
            if (MasFrom == "funt" && MasTo == "funt")
            {
                Wynik = Wartosc;
                WynikString = Wynik.ToString();
            }
            if (MasFrom == "funt" && MasTo == "mg")
            {
                Wynik = (Wartosc * 0.000045359);
                WynikString = Wynik.ToString();
            }
            if (MasFrom == "funt" && MasTo == "g")
            {
                Wynik = (Wartosc * 453.5924);
                WynikString = Wynik.ToString();
            }
            if (MasFrom == "funt" && MasTo == "dkg")
            {
                Wynik = (Wartosc * 45.3592);
                WynikString = Wynik.ToString();
            }
            if (MasFrom == "funt" && MasTo == "kg")
            {
                Wynik = (Wartosc * 0.4536);
                WynikString = Wynik.ToString();
            }
            if (MasFrom == "funt" && MasTo == "uncja")
            {
                Wynik = (Wartosc * 16);
                WynikString = Wynik.ToString();
            }
            if (MasFrom == "funt" && MasTo == "t")
            {
                Wynik = (Wartosc * 0.0005);
                WynikString = Wynik.ToString();
            }
            if (MasFrom == "funt" && MasTo == "karat")
            {
                Wynik = (Wartosc * 2267.9619);
                WynikString = Wynik.ToString();
            }
            if (MasFrom == "funt" && MasTo == "kwintal")
            {
                Wynik = (Wartosc * 0.0045);
                WynikString = Wynik.ToString();
            }
            ////karat//////
            if (MasFrom == "karat" && MasTo == "karat")
            {
                Wynik = Wartosc;
                WynikString = Wynik.ToString();
            }
            if (MasFrom == "karat" && MasTo == "g")
            {
                Wynik = (Wartosc * 0.2);
                WynikString = Wynik.ToString();
            }
            if (MasFrom == "karat" && MasTo == "mg")
            {
                Wynik = (Wartosc * 200);
                WynikString = Wynik.ToString();
            }
            if (MasFrom == "karat" && MasTo == "dkg")
            {
                Wynik = (Wartosc * 0.02);
                WynikString = Wynik.ToString();
            }
            if (MasFrom == "karat" && MasTo == "kg")
            {
                Wynik = (Wartosc * 0.0002);
                WynikString = Wynik.ToString();
            }
            if (MasFrom == "karat" && MasTo == "uncja")
            {
                Wynik = (Wartosc * 0.0071);
                WynikString = Wynik.ToString();
            }
            if (MasFrom == "karat" && MasTo == "funt")
            {
                Wynik = (Wartosc * 0.0004);
                WynikString = Wynik.ToString();
            }
            if (MasFrom == "karat" && MasTo == "t")
            {
                Wynik = (Wartosc * 0.0000002);
                WynikString = Wynik.ToString();
            }
            if (MasFrom == "karat" && MasTo == "kwintal")
            {
                Wynik = (Wartosc * 0.000002);
                WynikString = Wynik.ToString();
            }

            ////kwintal/////
            if (MasFrom == "kwintal" && MasTo == "kwintal")
            {
                Wynik = Wartosc;
                WynikString = Wynik.ToString();
            }
            if (MasFrom == "kwintal" && MasTo == "g")
            {
                Wynik = (Wartosc * 100000);
                WynikString = Wynik.ToString();
            }
            if (MasFrom == "kwintal" && MasTo == "mg")
            {
                Wynik = (Wartosc * 100000000);
                WynikString = Wynik.ToString();
            }
            if (MasFrom == "kwintal" && MasTo == "dkg")
            {
                Wynik = (Wartosc * 100);
                WynikString = Wynik.ToString();
            }
            if (MasFrom == "kwintal" && MasTo == "kg")
            {
                Wynik = (Wartosc * 1000);
                WynikString = Wynik.ToString();
            }
            if (MasFrom == "kwintal" && MasTo == "uncja")
            {
                Wynik = (Wartosc * 3527.3962);
                WynikString = Wynik.ToString();
            }
            if (MasFrom == "kwintal" && MasTo == "funt")
            {
                Wynik = (Wartosc * 220.4623);
                WynikString = Wynik.ToString();
            }
            if (MasFrom == "kwintal" && MasTo == "karat")
            {
                Wynik = (Wartosc * 5.00000);
                WynikString = Wynik.ToString();
            }
            if (MasFrom == "kwintal" && MasTo == "t")
            {
                Wynik = (Wartosc * 0.1);
                WynikString = Wynik.ToString();
            }
        }
        public string PodajWynik()
        { return this.WynikString; }

    }
}
