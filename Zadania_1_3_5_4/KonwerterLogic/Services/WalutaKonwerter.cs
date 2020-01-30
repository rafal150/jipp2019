using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;

namespace Konwerter.Services
{
    public class WalutaKonwerter : IKonwerter
    {
        public string Name => "Waluta: PLN, EUR";

        public List<string> Units => new List<string>(new[] { "PLN", "EUR" });


        public double Convert(string unitFrom, string unitTo, double value)
        {
            string url = @"http://api.nbp.pl/api/exchangerates/tables/a/?format=json";
            double resultConvert = 0;
            float eur = 0;

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);
                TableObject[] tables = JsonConvert.DeserializeObject<TableObject[]>(json);

                if (tables.Length > 0)
                {
                    RateObject rate = tables[0].Rates.Where(r => r.Code == "EUR").FirstOrDefault();

                    if (rate != null)
                    {
                        eur = (rate.Mid);
                    }
                }

            }

            if(unitFrom == "PLN" && unitTo == "PLN")
            {
                resultConvert = value;
            }
            else if (unitFrom == "EUR" && unitTo == "EUR")
            {
                resultConvert = value;
            }
            else if (unitFrom == "PLN" && unitTo == "EUR")
            {
                resultConvert = value / eur;
            }
            else if (unitFrom == "EUR" && unitTo == "PLN")
            {
                resultConvert = value * eur;
            }

            return resultConvert;
        }



    }

    public class TableObject
    {
        public string Table { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public RateObject[] Rates { get; set; }
    }

    public class RateObject
    {
        public string Currency { get; set; }
        public string Code { get; set; }
        public float Mid { get; set; }
    }

}
