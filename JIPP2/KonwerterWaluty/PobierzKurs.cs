using KonwerterSDK;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterWaluty
{
    public class PobierzKurs
    {
        public decimal DajKurs(string currency)
        {
            string url = @"http://api.nbp.pl/api/exchangerates/tables/A/today/?format=json";
            decimal kurs = 0;
            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);

                TableObject[] tables = JsonConvert.DeserializeObject<TableObject[]>(json);

                if (tables.Length > 0)
                {
                    RateObject rate = tables[0].Rates.Where(r => r.Code == currency).FirstOrDefault();

                    if (rate != null)
                    {
                        kurs = Decimal.Parse(rate.Mid.Replace('.', ','));
                    }
                }
            }
            return kurs;
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
