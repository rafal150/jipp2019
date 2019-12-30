using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Konwerter.Services;
using Newtonsoft.Json;

namespace ConverterNBP
{
    public class ConverterNBP : IConverting
    {
        public string Nazwa => "Waluta";

        public List<string> ListaJednostek => new List<String>(new[] { "EUR", "PLN" });

        public float Convert(string from, string to, double amount)
        {
            string url = @"http://api.nbp.pl/api/exchangerates/tables/A/today/?format=json";

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);

                TableObject[] tables = JsonConvert.DeserializeObject<TableObject[]>(json);

                RateObject rate = tables[0].Rates.Where(r => r.Code == "EUR").FirstOrDefault();
                double euroRate = Double.Parse(rate.Mid);
                switch (from)
                {
                    case "PLN":
                        amount /= euroRate;
                        break;
                }
                switch (to)
                {
                    case "PLN":
                        amount *= euroRate;
                        break;
                }
                return (float)amount;
            }
        }
    }
}
