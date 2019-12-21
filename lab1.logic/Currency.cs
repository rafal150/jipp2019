using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;

namespace lab1.logic
{
    class Currency
    {
        public double GetEuro()
        {
            string url = @"http://api.nbp.pl/api/exchangerates/tables/A/today/?format=json";

            WebClient client = new WebClient();
            string json = client.DownloadString(url);

            TableObject[] tables = JsonConvert.DeserializeObject<TableObject[]>(json);

            if (tables.Length > 0)
            {
                RateObject rate = tables[0].Rates.Where(r => r.Code == "EUR").FirstOrDefault();

                if (rate != null)
                {
                    string string_tmp;
                    double value = 0;
                    string_tmp = rate.Mid;
                    value = double.Parse(string_tmp, System.Globalization.CultureInfo.InvariantCulture);
                    return value;
                }
                else
                    return 0;
            }
            else
                return 0;

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
