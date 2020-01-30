using JIPP5.SDK;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace JIPP5.WalutaPlugin
{
    public class CurrencyConverter : IKonwerter
    {
        public string Nazwa => "Waluta";

        public List<string> JakieJednostki => new List<string>(new[] { "EUR", "PLN" });

        public decimal Converter(string from, decimal value, string to)
        {
            const string url = "http://api.nbp.pl/api/exchangerates/tables/A/today/?format=json";

            switch (from)
            {
                case "EUR":

                    if (to == "EUR")
                    {
                        return value;
                    }
                    else if (to == "PLN")
                    {
                        using (WebClient client = new WebClient())
                        {
                            string json = client.DownloadString(url);

                            ReadObject[] data = JsonConvert.DeserializeObject<ReadObject[]>(json);

                            if (data.Length > 0)
                            {
                                EntityObject entity = Array.Find(data[0].Rates, r => r.Code == "EUR");

                                if (entity != null)
                                {
                                    return Decimal.Parse(entity.Mid, CultureInfo.InvariantCulture) * value;
                                }
                            }
                        }
                    }
                    break;

                case "PLN":
                    if (to == "PLN")
                    {
                        return value;
                    }
                    else if (to == "EUR")
                    {
                        using (WebClient client = new WebClient())
                        {
                            string json = client.DownloadString(url);

                            ReadObject[] data = JsonConvert.DeserializeObject<ReadObject[]>(json);

                            if (data.Length > 0)
                            {
                                EntityObject entity = Array.Find(data[0].Rates, r => r.Code == "EUR");

                                if (entity != null)
                                {
                                    return Decimal.Parse(entity.Mid, CultureInfo.InvariantCulture) * value;
                                }
                            }
                        }
                    }
                    break;
            }
            return 0;
        }

    }

    public class ReadObject
    {
        public string Table { get; set; }

        public DateTime? Date { get; set; }

        public EntityObject[] Rates { get; set; }
    }

    public class EntityObject
    {
        public string Currency { get; set; }

        public string Code { get; set; }

        public string Mid { get; set; }
    }
}
