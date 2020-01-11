using konwerter.services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Converter.logic.services
{
    class CurrencyConverter : IConverter
    {
        public string Name => "Currencies";

        public List<string> Units => new List<string>(new[] { "EUR", "PLN"});

        public decimal Convert(string inputUnit, string outputUnit, decimal value)
        {
            decimal eurEx=0, plnEx=0;

            string url = @"http://api.nbp.pl/api/exchangerates/tables/A/today/?format=json";

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);

                TableObject[] tables = JsonConvert.DeserializeObject<TableObject[]>(json);

                if (tables.Length > 0)
                {
                    RateObject eurRate = tables[0].Rates.Where(r => r.Code == "EUR").FirstOrDefault();

                    if (eurRate != null)
                    {
                        eurEx = decimal.Parse(eurRate.Mid);
                    }

                    RateObject plnRate = tables[0].Rates.Where(r => r.Code == "PLN").FirstOrDefault();

                    if (plnRate != null)
                    {
                        plnEx = decimal.Parse(plnRate.Mid);
                    }

                }
            }

            if (inputUnit == "EUR")
            {
                return decimal.Multiply(value, eurEx);
            }
            else
            {
                return decimal.Multiply(value, plnEx);
            }
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