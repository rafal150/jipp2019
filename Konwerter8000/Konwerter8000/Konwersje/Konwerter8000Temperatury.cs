using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Konwerter8000.Konwersje
{
    class Konwerter8000Temperatury : IKonwerter8000
    {
        double DoObliczen;
        public string NazwaKategorii => "Temperatury";

        public List<string> Jednostki => new List<string>(new[] { "Celsjusz", "Kelvin", "Farenheit" });

        public double Konwertuj(string zJednostki, string doJednostki, double wartosc)
        {
            Konwerter8000Temperatury konwersja = new Konwerter8000Temperatury
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

        double CelsjuszKelvin() => DoObliczen + 273.15;
        double CelsjuszFarenheit() => DoObliczen * 1.8 + 32;
        double KelvinCelsjusz() => DoObliczen - 273.15;
        double FarenheitCelsjusz() => (DoObliczen -32) /1.8;
        double KelvinFarenheit() => DoObliczen *9/5 - 459.67;
        double FarenheitKelvin() => (DoObliczen + 459.67) * 5 /9;

    }
    
}
