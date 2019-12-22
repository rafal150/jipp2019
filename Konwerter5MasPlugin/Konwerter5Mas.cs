using System.Collections.Generic;
using System.Reflection;
using Konwerter5.Uslugi;

namespace Konwerter5MasPlugin
{
    class Konwerter5Mas : IKonwerter5
    {
        double wartoscDoPrzeliczen;
        public string NazwaKategorii => "Masy";
        public List<string> Jednostki => new List<string>(new[] { "Kilogram", "Funt", "Uncja" });
        public double Konwertuj(string zJednostki, string doJednostki, double wartosc)
        {
            Konwerter5Mas konwersja = new Konwerter5Mas
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

        double KilogramFunt() => wartoscDoPrzeliczen / 0.45359237;
        double KilogramUncja() => wartoscDoPrzeliczen / 0.02834952;
        double FuntKilogram() => wartoscDoPrzeliczen * 0.45359237;
        double UncjaKilogram() => wartoscDoPrzeliczen * 0.02834952;
        double FuntUncja() => wartoscDoPrzeliczen * 16;
        double UncjaFunt() =>  wartoscDoPrzeliczen / 16;
    }
}
