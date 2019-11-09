using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterJedn
{
    class Temp
    {
        public string TempFrom;
        public string TempTo;
        public double Wartosc;
        public double Wynik;
        public string Type = "Temp";
        public string WynikString;

        public Temp(string TempFrom, string TempTo, double Wartosc)
        {
            if (TempFrom == "Celciusz" && TempTo == "Ferenheit")
            {
                Wynik = (Wartosc * 1.8 + 32);
                WynikString = Wynik.ToString();

            }
            if (TempFrom == "Celciusz" && TempTo == "Celciusz")
            {
                Wynik = Wartosc;
                WynikString = Wynik.ToString();

            }
            if (TempFrom == "Celciusz" && TempTo == "Kelvin")
            {
                Wynik = (Wartosc + 273.15);
                WynikString = Wynik.ToString();

            }
            if (TempFrom == "Celciusz" && TempTo == "Rankin")
            {
                Wynik = ((Wartosc + 273.15) * 1.8);
                WynikString = Wynik.ToString();

            }
            ////F////
            if (TempFrom == "Ferenheit" && TempTo == "Ferenheit")
            {
                Wynik = Wartosc;
                WynikString = Wynik.ToString();
            }
            if (TempFrom == "Ferenheit" && TempTo == "Celciusz")
            {
                Wynik = ((Wartosc - 32) / 1.8);
                WynikString = Wynik.ToString();
            }
            if (TempFrom == "Ferenheit" && TempTo == "Kelvin")
            {
                Wynik = ((5 / 9) * (Wartosc - 32) + 273.15);
                WynikString = Wynik.ToString();
            }
            if (TempFrom == "Ferenheit" && TempTo == "Rankin")
            {
                Wynik = (Wartosc + 459.67);
                WynikString = Wynik.ToString();
            }
            /////K/////
            if (TempFrom == "Kelvin" && TempTo == "Kelvin")
            {
                Wynik = Wartosc;
                WynikString = Wynik.ToString();
            }
            if (TempFrom == "Kelvin" && TempTo == "Ferenheit")
            {
                Wynik = ((9 / 5) * (Wartosc - 273.15) + 32);
                WynikString = Wynik.ToString();
            }
            if (TempFrom == "Kelvin" && TempTo == "Celciusz")
            {
                Wynik = (Wartosc - 273.15);
                WynikString = Wynik.ToString();
            }
            if (TempFrom == "Kelvin" && TempTo == "Rankin")
            {
                Wynik = (Wartosc * 9 / 5);
                WynikString = Wynik.ToString();
            }
            /////R/////
            if (TempFrom == "Rankin" && TempTo == "Rankin")
            {
                Wynik = Wartosc;
                WynikString = Wynik.ToString();
            }
            if (TempFrom == "Rankin" && TempTo == "Ferenheit")
            {
                Wynik = (Wartosc - 459.67);
                WynikString = Wynik.ToString();
            }
            if (TempFrom == "Rankin" && TempTo == "Celciusz")
            {
                Wynik = ((Wartosc - 491.7) * 5 / 9);
                WynikString = Wynik.ToString();
            }
            if (TempFrom == "Rankin" && TempTo == "Kelvin")
            {
                Wynik = (Wartosc * 5 / 9);
                WynikString = Wynik.ToString();
            }
        }

        public string PodajWynik()
        { return this.WynikString; }

    }
}
