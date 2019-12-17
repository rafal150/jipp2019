using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Labs.Converters;
using System.Net;
using Newtonsoft.Json;
using System.Globalization;

namespace MoneyConvPlugin
{
    public class MoneyConv : IConverter
    {
        public string Name => "Euro";

        public List<string> Units => new List<string>(new[] { "EUR", "PLN" });

        public double Convert(string from, string to, double value)
        {
            string url = @"http://api.nbp.pl/api/exchangerates/tables/A/today/?format=json";

            double result = 0;

            switch (from)
            {
                case "EUR":

                    if (to == "EUR")
                    {
                        result = value;
                    }
                    else if (to == "PLN")
                    {
                        using (WebClient client = new WebClient())
                        {
                            string json = client.DownloadString(url);

                            TableObj[] tables = JsonConvert.DeserializeObject<TableObj[]>(json);

                            if (tables.Length > 0)
                            {
                                RateObj rate = tables[0].Rates.Where(r => r.Code == "EUR").FirstOrDefault();

                                if (rate != null)
                                {
                                    result = Double.Parse(rate.Mid, CultureInfo.InvariantCulture) * value;
                                }
                            }
                        }
                    }
                    break;

                case "PLN":
                    if (to == "PLN")
                    {
                        result = value;
                    }
                    else if (to == "EUR")
                    {
                        using (WebClient client = new WebClient())
                        {
                            string json = client.DownloadString(url);

                            TableObj[] tables = JsonConvert.DeserializeObject<TableObj[]>(json);

                            if (tables.Length > 0)
                            {
                                RateObj rate = tables[0].Rates.Where(r => r.Code == "EUR").FirstOrDefault();

                                if (rate != null)
                                {
                                    result = Double.Parse(rate.Mid, CultureInfo.InvariantCulture) * value;
                                }
                            }
                        }
                    }
                    break;
            }

            return result;
        }

    }

    public class TableObj
    {
        public string Table { get; set; }

        public DateTime? Date { get; set; }

        public RateObj[] Rates { get; set; }
    }

    public class RateObj
    {
        public string Currency { get; set; }

        public string Code { get; set; }

        public string Mid { get; set; }
    }


}
