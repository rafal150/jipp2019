using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Konwerter5.Uslugi;
using Newtonsoft.Json;
using System.Net;

namespace Konwerter5ZlotoPlugin
{
    public class Konwerter5Zloto  : IKonwerter5
    {
        double wartoscDoPrzeliczen;
        public string NazwaKategorii => "Złoto";
        public List<string> Jednostki => new List<string>(new[] { "Złoto", "PLN" });


        double SetPrzelicznik()
        {
            string NBPWebApiJson = @"http://api.nbp.pl/api/cenyzlota/?format=json";
            using (WebClient webClient = new WebClient())
            {
                string JsonString = webClient.DownloadString(NBPWebApiJson);
                var kurs = KursZlota.FromJson(JsonString);

                return kurs[0].Cena;

            }
        }



        public double Konwertuj(string zJednostki, string doJednostki, double wartosc)
        {
            Konwerter5Zloto konwersja = new Konwerter5Zloto
            {
                wartoscDoPrzeliczen = wartosc,
            };
            string ZJ = zJednostki;
            string DJ = doJednostki;
            if (ZJ == DJ)
            {
                return wartosc;
            }
            if (DJ == "PLN")
            {
                return wartoscDoPrzeliczen * SetPrzelicznik();
            }
            return wartoscDoPrzeliczen / SetPrzelicznik();

        }
    }
}
