using System.Collections.Generic;
using System.Reflection;

namespace Konwerter5.Uslugi
{
    class Konwerter5Odleglosci : IKonwerter5
    {
        double wartoscDoPrzeliczen;
        public string NazwaKategorii => "Odleglosci";

        public List<string> Jednostki => new List<string>(new[] { "Metr", "Stopa", "Cal" });

        public double Konwertuj(string zJednostki, string doJednostki, double wartosc)
        {
            Konwerter5Odleglosci konwersja = new Konwerter5Odleglosci
            {
                wartoscDoPrzeliczen = wartosc
            };
            string ZJ = zJednostki;
            string DJ = doJednostki;
            if (ZJ == DJ)
            {
                return wartosc;
            }

            MethodInfo metoda = konwersja.GetType().GetMethod(ZJ + DJ, BindingFlags.NonPublic | BindingFlags.Instance); //Stackoverflow https://stackoverflow.com/questions/135443/how-do-i-use-reflection-to-invoke-a-private-method

            return (double)metoda.Invoke(konwersja, null);
        }

        double MetrStopa() => wartoscDoPrzeliczen / 0.3048; 
        double MetrCal() => wartoscDoPrzeliczen / 0.0254;
        double StopaMetr() => wartoscDoPrzeliczen * 0.3048;
        double CalMetr() => wartoscDoPrzeliczen * 0.0254;
        double StopaCal() => wartoscDoPrzeliczen * 12;
        double CalStopa() => wartoscDoPrzeliczen / 12;
    }
}
