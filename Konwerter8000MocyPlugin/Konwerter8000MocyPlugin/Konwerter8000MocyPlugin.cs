using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Konwerter8000.Konwersje;

namespace Konwerter8000MocyPlugin
{
    public class Konwerter8000MocyPlugin
    {
        double DoObliczen;
        public string NazwaKategorii => "Moc";

        public List<string> Jednostki => new List<string>(new[] { "hp", "W", "BTU" });

        public double Konwertuj(string zJednostki, string doJednostki, double wartosc)
        {
            Konwerter8000MocyPlugin konwersja = new Konwerter8000MocyPlugin
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

        double hpW() => DoObliczen * 745.699872;
        double Whp() => DoObliczen / 745.699872;
        double BTUW() => DoObliczen * 0.293071;
        double WBTU() => DoObliczen / 0.293071;

        double BTUhp() => DoObliczen * 0.000393014779;
        double hpBTU() => DoObliczen / 0.000393014779;

    }
}
