using KonwerterJedn.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NBPConverter
{
    public class NBPConverter : IConverter
    {
        public string Nazwa => "Waluta";

        public List<string> Jednostki => new List<string>(new[] { "PLN", "EUR" });

        public double Convert(string fromUnit, string toUnit, double value)
        {
            string url = @"http://api.nbp.pl/api/exchangerates/tables/A/?format=json";

            double convValue = 0;

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);

                TableObject[] tables = JsonConvert.DeserializeObject<TableObject[]>(json);

                if (tables.Length > 0)
                {
                    RateObject rate = tables[0].Rates.Where(r => r.Code == "EUR").FirstOrDefault();

                    if (rate != null)
                    {
                        convValue = double.Parse(rate.Mid.Replace('.', ','));
                    }
                }
            }

            double fromBase(double cur)
            {
                double convertedCurrency = 0;
                switch (toUnit)
                {
                    case "PLN":
                        {
                            convertedCurrency = cur;
                            break;
                        }
                    case "EUR":
                        {
                            convertedCurrency = cur / convValue;
                            break;
                        }
                }
                return convertedCurrency;
            }
            double toBase(double cur)
            {
                double convertedCurrency = 0;
                switch (fromUnit)
                {
                    case "PLN":
                        {
                            convertedCurrency = cur;
                            break;
                        }
                    case "EUR":
                        {
                            convertedCurrency = cur * convValue;
                            break;
                        }
                }
                return convertedCurrency;
            }
            return fromBase(toBase(value));
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
}
