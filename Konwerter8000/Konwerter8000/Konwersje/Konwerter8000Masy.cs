using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Konwerter8000.Konwersje
{
    class Konwerter8000Masy :IKonwerter8000
    {
        double DoObliczen;
        public string NazwaKategorii => "Masy";

        public List<string> Jednostki => new List<string>(new[] { "Kilogram", "Funt", "Uncja" });

        public double Konwertuj(string zJednostki, string doJednostki, double wartosc)
        {
            Konwerter8000Masy konwersja = new Konwerter8000Masy
            {
                DoObliczen = wartosc
            };
            string ZJ = zJednostki;
            string DJ = doJednostki;
            if (ZJ == DJ)
            {
                return wartosc;
            }
            MethodInfo metoda = konwersja.GetType().GetMethod(ZJ + DJ, BindingFlags.NonPublic | BindingFlags.Instance); 

            return (double)metoda.Invoke(konwersja, null);
        }

        double KilogramFunt() => DoObliczen / 0.45359237;
        double KilogramUncja() => DoObliczen / 0.02834952;
        double FuntKilogram() => DoObliczen * 0.45359237;
        double UncjaKilogram() => DoObliczen * 0.02834952;
        double FuntUncja() => DoObliczen * 16;
        double UncjaFunt() => DoObliczen / 16;

    }

    
}
