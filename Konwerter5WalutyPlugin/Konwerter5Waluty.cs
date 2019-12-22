using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Konwerter5.Uslugi;
using System.Reflection;


namespace Konwerter5WalutyPlugin
{
    public class Konwerter5Waluty : IKonwerter5
    {
        double wartoscDoPrzeliczen;
        public string NazwaKategorii => "Waluty";
        public List<string> Jednostki => new List<string>(new[] { "EUR", "PLN" }); //brzydki hack powinienem pobierac tabele z jsona, ale zadanie wymaga tylko EURPLN i PLNEUR

      
        double SetPrzelicznik()
        {
            string NBPWebApiJson = @"http://api.nbp.pl/api/exchangerates/rates/A/EUR/?format=json";
            using (WebClient webClient = new WebClient())
            {
                string JsonString = webClient.DownloadString(NBPWebApiJson);
                var tabeleKursow = TabeleKursow.FromJson(JsonString);
                if (tabeleKursow.Rates.Length > 0)
                { 
                    return tabeleKursow.Rates[0].Mid;
                }
              
            }return 1;

            
        }



        public double Konwertuj(string zJednostki, string doJednostki, double wartosc)
        {
            Konwerter5Waluty konwersja = new Konwerter5Waluty
            {
                wartoscDoPrzeliczen = wartosc,
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


        double EURPLN() => wartoscDoPrzeliczen * SetPrzelicznik();
        double PLNEUR() => wartoscDoPrzeliczen / SetPrzelicznik();
    }
}
