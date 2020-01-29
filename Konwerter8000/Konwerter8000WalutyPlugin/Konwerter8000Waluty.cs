using System.Collections.Generic;
using System.Linq;
using Konwerter8000.Konwersje;
using System.Net;
using Newtonsoft.Json;

namespace Konwerter8000WalutyPlugin
{
    public class Konwerter8000Waluty : IKonwerter8000
    {
        string NBPWebAPIJson = @"http://api.nbp.pl/api/exchangerates/tables/A/?format=json";

        public string NazwaKategorii => "Waluty";

        public List<string> Jednostki => PobierzJednostki();

        public double Konwertuj(string zJednostki, string doJednostki, double wartosc)
        {
            string ZJ = zJednostki;
            string DJ = doJednostki;
            double kursZJ = PobierzKurs(zJednostki); 
            double kursDJ = PobierzKurs(doJednostki);
            if (ZJ == DJ)
            {
                return wartosc;
            }
            
            if (ZJ == "PLN")
            {
                return wartosc / kursDJ;
            }

            if (DJ == "PLN")
            {
                return wartosc * kursZJ;
            }

            return ((wartosc / kursDJ) * kursZJ);
        }

        double PobierzKurs(string rateCode)
        {
            using (WebClient webClient = new WebClient())
            {
                string JsonString = webClient.DownloadString(NBPWebAPIJson);
                var tabeleKursow = TabeleKursow.FromJson(JsonString);
                if (tabeleKursow.Length > 0)
                {
                    return (from Rate rate in tabeleKursow[0].Rates
                            where rate.Code == rateCode
                            select rate.Mid)
                                 .FirstOrDefault();

                }
                return 1;
            }
        }

        List<string> PobierzJednostki()
        {
            List<string> listaWalut = new List<string>();

            using (WebClient webClient = new WebClient())
            {
                string JsonString = webClient.DownloadString(NBPWebAPIJson);
                var tabeleKursow = TabeleKursow.FromJson(JsonString);

                if (tabeleKursow.Length > 0)
                {
                    foreach (Rate rate in tabeleKursow[0].Rates)
                    {
                        listaWalut.Add(rate.Code);
                    }
                }
                listaWalut.Add("PLN"); //bo tabele NBP nie maja tej wartosci w sobie
            }
            return listaWalut;
        }
       
    }
}
