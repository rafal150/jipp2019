using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Konwerter8000.Konwersje;

namespace Konwerter8000OdleglsciPlugin
{
    public class Konwerter8000OdleglosciPlugin : IKonwerter8000
    {
        double DoObliczen;
        public string NazwaKategorii => "Odleglosci";

        public List<string> Jednostki => new List<string>(new[] { "Metr", "Stopa", "Cal" });

        public double Konwertuj(string zJednostki, string doJednostki, double wartosc)
        {
            Konwerter8000OdleglosciPlugin konwersja = new Konwerter8000OdleglosciPlugin
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

        double MetrStopa() => DoObliczen / 0.3048;
        double MetrCal() => DoObliczen / 0.0254;
        double StopaMetr() => DoObliczen * 0.3048;
        double CalMetr() => DoObliczen * 0.0254;
        double StopaCal() => DoObliczen * 12;
        double CalStopa() => DoObliczen / 12;

    }
}
