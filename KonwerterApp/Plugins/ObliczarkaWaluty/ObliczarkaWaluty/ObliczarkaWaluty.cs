using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using KonwerterApp.Services;
using Newtonsoft.Json;

namespace ObliczarkaWaluty
{
    public class ObliczarkaWaluty : IConverter
    {
        public string Nazwa => "Waluta";

        public List<string> Jednostki => new List<string>(new[] { "EUR", "PLN" });

        public float Konwertuj(string JednostkaPoczatkowa, string JednostkaKoncowa, float wartosc)
        {
            string url = @"http://api.nbp.pl/api/exchangerates/tables/A/today/?format=json";

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);

                TableObject[] tables = JsonConvert.DeserializeObject<TableObject[]>(json);

                    RateObject rate = tables[0].Rates.Where(r => r.Code == "EUR").FirstOrDefault();
                double euroRate = double.Parse(rate.Mid);
                        //"EUR, PLN"
                        //zamiana wartosci na double
                        double WartoscDouble = Convert.ToDouble(wartosc);

                //Konwersja temperatury na Kelwiny            
                if (JednostkaPoczatkowa == "PLN")
                    WartoscDouble /= euroRate;
                else if (JednostkaPoczatkowa == "EUR");
                /*----------------------------*/
                /* ----------z PLN-------*/
                /*----------------------------*/
                if (JednostkaKoncowa == "PLN")
                    WartoscDouble *= euroRate;
                else if (JednostkaKoncowa == "EUR");

                return (float)WartoscDouble;
            }
        }
    }
}
