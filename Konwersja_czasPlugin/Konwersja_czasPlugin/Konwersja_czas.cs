using lab1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwersja_czasPlugin
{
    public class Konwersja_czas : IKonwersja
    {
        public string Nazwa => "Czas";

        public List<string> Jednostki => new List<string>(new[] { "ms", "s","min", "h" });
        public int Konwertuj(string z, string na, double wartosc)
        {
            int wynik;
            //referencja - sekunda
            if (z == "s") wartosc = wartosc;
            if (z == "ms") wartosc = (wartosc / 1000);
            if (z == "min") wartosc = wartosc * 60;
            if (z == "h") wartosc = (wartosc) * 3600;
            if (na == "s") wartosc = wartosc;
            if (na == "ms") wartosc = (wartosc * 1000);
            if (na == "min") wartosc = wartosc / 60;
            if (na == "h") wartosc = (wartosc) / 3600;
            wynik = (int)wartosc;
            return wynik;
        }
    }
}
