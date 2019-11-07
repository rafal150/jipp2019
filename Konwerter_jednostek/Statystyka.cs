using System;
using System.Collections.Generic;
using System.Text;

namespace Konwerter_jednostek
{
    public class Statystyka
    {
        public DateTime Czas { get; }
        public string Nazwa_typu { get; }
        public string Nazwa_miary_wejscie {get;}
        public double Wartosc_do_konwersji { get; }
        public string Nazwa_miary_wyjscia { get; }
        public double Rezultat_konwersji { get; }

        public Statystyka (DateTime czas, string nazwa_typu, string nazwa_miary_wejscie, double wartosc_do_konwersji, string nazwa_miary_wyjscia, double rezultat_konwersji)
        {
            Czas = czas;
            Nazwa_typu = nazwa_typu;
            Nazwa_miary_wejscie = nazwa_miary_wejscie;
            Wartosc_do_konwersji = wartosc_do_konwersji;
            Nazwa_miary_wyjscia = nazwa_miary_wyjscia;
            Rezultat_konwersji = rezultat_konwersji;
        }
    }
}
