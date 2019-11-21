using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Konwerter_jednostek
{
    public static class Konwerter
    {
        private static IEnumerable<Przeliczanie_miar> przelicznik;
        public static double Konwertuj(double wartosc, int typ_wejscie, int typ_wyjscie, IEnumerable<Przeliczanie_miar> przelicz)
        {
            przelicznik = przelicz;
            var funkcja = pobierz_funkcje(typ_wejscie, typ_wyjscie);
            return funkcja(wartosc);
        }

        private static Func<double, double> pobierz_funkcje(int typ_wejscie, int typ_wyjscie) //rzeczywista konwersja jednostek przy pomocy tabeli z sql
        {
            var wspolczynniki = przelicznik.Where(x => x.Wejscie_ID == typ_wejscie && x.Wyjscie_ID == typ_wyjscie).First();
            return new Func<double, double>(x => x * wspolczynniki.A + wspolczynniki.B);
        }
    }
}
