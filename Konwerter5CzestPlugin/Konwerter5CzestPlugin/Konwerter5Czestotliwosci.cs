using System.Collections.Generic;
using System.Reflection;
using Konwerter5.Uslugi;

namespace Konwerter5CzestPlugin
{
    public class Konwerter5Czestotliwosci : IKonwerter5
    {
        double wartoscDoPrzeliczen;
        public string NazwaKategorii => "Czestotliwosci";

        public List<string> Jednostki => new List<string>(new[] {"rads","Hz" });

        public double Konwertuj(string zJednostki, string doJednostki, double wartosc)
        {
            Konwerter5Czestotliwosci konwersja = new Konwerter5Czestotliwosci
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

        double radsHz() => wartoscDoPrzeliczen * 6.2831853;
        double Hzrads() => wartoscDoPrzeliczen / 6.2831853;

    }
}
