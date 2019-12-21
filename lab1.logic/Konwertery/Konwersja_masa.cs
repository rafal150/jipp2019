using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace lab1
{
    public partial class Konwersja_masa : IKonwersja
    {


        public string Nazwa => "Masy";

        public List<string> Jednostki => new List<string>(new[] { "mg", "g", "dkg", "kg", "T", "uncja", "funt", "karat", "kwintal" });

        public int Konwertuj(string z, string na, double wartosc)
        {
            int wynik;
            //referencja kg
            if (z == "kg") wartosc = wartosc;
            if (z == "mg") wartosc = wartosc * 0.000001;
            if (z == "g") wartosc = wartosc * 0.001;
            if (z == "dkg") wartosc = wartosc * 0.01;
            if (z == "T") wartosc = wartosc * 1000;
            if (z == "uncja") wartosc = wartosc * 0.028349523;
            if (z == "funt") wartosc = wartosc * 0.45359237;
            if (z == "karat") wartosc = wartosc * 0.0002;
            if (z == "kwintal") wartosc = wartosc * 100;
            if (na == "kg") wartosc = wartosc;
            if (na == "mg") wartosc = wartosc / 0.000001;
            if (na == "g") wartosc = wartosc / 0.001;
            if (na == "dkg") wartosc = wartosc / 0.01;
            if (na == "T") wartosc = wartosc / 1000;
            if (na == "uncja") wartosc = wartosc / 0.028349523;
            if (na == "funt") wartosc = wartosc / 0.45359237;
            if (na == "karat") wartosc = wartosc / 0.0002;
            if (na == "kwintal") wartosc = wartosc / 100;
            wynik = (int)wartosc;
            return wynik;
        }
      

    }
}
