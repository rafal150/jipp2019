using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using Newtonsoft.Json;
using SEM5WPF_1.Services;
using System.Threading.Tasks;

namespace KonwertnbpPlugin
{
    public class KonwerterNbpPlugin : IKonwerter
    {
        public string Name => "EuroPLN";

        public List<string> Units => new List<string>(new[] { "Pln", "Euro" });

        public decimal Konwerter(string jednostkaZ, string jednostkaDo, decimal wartosc)
        {
            string kursEuro = "0";
            string url = @"http://api.nbp.pl/api/exchangerates/tables/A/today/?format=json";

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);
                TableObject[] tables = JsonConvert.DeserializeObject<TableObject[]>(json);

                if (tables.Length > 0)
                {
                    RateObject rate = tables[0].Rates.Where(r => r.Code == "EUR").FirstOrDefault();

                    if (rate != null)
                    {
                        kursEuro = rate.Mid;

                        
                    }
                }
            }

            switch (jednostkaZ)
            {

                case "Pln":
                    if (jednostkaZ == "Pln")
                    {
                       // decimal x = Convert.ToDecimal(kursEuro);
                        return wartosc / Convert.ToDecimal(kursEuro, CultureInfo.InvariantCulture);

                    }
                    break;
                case "Euro":
                    if (jednostkaZ == "Euro")
                    {
                        return wartosc * Convert.ToDecimal(kursEuro, CultureInfo.InvariantCulture);
                    }
                    break;
            }
            return wartosc;
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
        public string Mid { get; set; }
    }
}
