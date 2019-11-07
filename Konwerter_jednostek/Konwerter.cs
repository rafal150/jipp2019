using System;
using System.Collections.Generic;
using System.Text;

namespace Konwerter_jednostek
{
    public static class Konwerter
    {
        public static double Konwertuj(double wartosc, int typ_wejscie, int typ_wyjscie)
        {
            var funkcja = pobierz_funkcje(typ_wejscie, typ_wyjscie);
            return funkcja(wartosc);
        }

        private static Func<double,double> pobierz_funkcje(int typ_wejscie, int typ_wyjscie) //rzeczywista konwersja jednostek przy pomocy tabeli z sql
        {
            var wspolczynniki = PolaczenieDb.PobierzWspolczynniki(typ_wejscie, typ_wyjscie);

            if (!wspolczynniki.CzyOdwrotne)
            {
                return new Func<double, double>(x => x * wspolczynniki.A + wspolczynniki.B);
            }
            else
            {
                return new Func<double, double>(x => (x - wspolczynniki.B) / wspolczynniki.A);
            }
        }
    }
}
