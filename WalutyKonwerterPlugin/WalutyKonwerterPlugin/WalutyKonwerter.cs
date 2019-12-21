using Konwerter.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using System.Globalization;

namespace WalutyKonwerterPlugin
{
    public class WalutyKonwerter : IKonwerter
    {
        public string Typ => "konwerter walut";
        public List<string> Jednostki => new List<string>(new[] { "PLN", "EUR" });        
        
        public double Przelicz(string fromType, string toType, double value)
        {
            double kurs=0;
            string url = @"http://api.nbp.pl/api/exchangerates/tables/A/last/?format=json";

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);

                TableObject[] tables = JsonConvert.DeserializeObject<TableObject[]>(json);

                if (tables.Length > 0)
                {
                    RateObject rate = tables[0].Rates.Where(r => r.Code == "EUR").FirstOrDefault();

                    if (rate != null)
                    {
                        kurs = double.Parse(rate.Mid, CultureInfo.InvariantCulture);
                    }
                }
            }
            
            double result = 0;
            switch (fromType)
            {
                case "PLN":
                    switch (toType)
                    {
                        case "PLN":
                            result = value;
                            break;
                        case "EUR":
                            result = value / kurs;
                            break;
                        default:
                            break;
                    }
                    break;
                case "EUR":
                    switch (toType)
                    {
                        case "PLN":
                            result = value * kurs;
                            break;
                        case "EUR":
                            result = value;
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
            return result;
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