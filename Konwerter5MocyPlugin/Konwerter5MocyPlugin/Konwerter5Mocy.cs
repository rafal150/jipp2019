using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Konwerter5.Uslugi;

namespace Konwerter5MocyPlugin
{
    public class Konwerter5Mocy : IKonwerter5
    {
        double wartoscDoPrzeliczen;
        public string NazwaKategorii => "Moc";

        public List<string> Jednostki => new List<string>(new[] {"hp","W","BTU"});

        public double Konwertuj(string zJednostki, string doJednostki, double wartosc)
        {
            Konwerter5Mocy konwersja = new Konwerter5Mocy
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

        double hpW() => wartoscDoPrzeliczen * 745.699872;
        double Whp() => wartoscDoPrzeliczen / 745.699872;
        double BTUW() => wartoscDoPrzeliczen * 0.293071;
        double WBTU() => wartoscDoPrzeliczen / 0.293071;

        double BTUhp() => wartoscDoPrzeliczen * 0.000393014779; 
        double hpBTU() => wartoscDoPrzeliczen / 0.000393014779;


    }
}
