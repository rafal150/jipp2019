
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using IConvertible = ConverterSDK.IConvertible;

namespace CurrencyConverterPlugin
{
    public class CurrencyConverter : IConvertible
    {
        public string ConverterName => "Waluta";
        public List<string> Units =>
                new List<string>()
                {
                    "EUR",
                    "PLN",    
                };

        public string Convert(int indexFrom, int indexTo, double value)
        {
            if (indexFrom == indexTo)
                return value.ToString();
            //eur->zlote
            if (indexFrom == 0 && indexTo == 1)
                return (value * GetCurrency("EUR").Mid).ToString();
            else return (value / GetCurrency("EUR").Mid).ToString();
           
        }
        private RateObject GetCurrency(string currency)
        {
            string url = @"http://api.nbp.pl/api/exchangerates/tables/A/today/?format=json";

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);

                TableObject[] tables = JsonConvert.DeserializeObject<TableObject[]>(json);

                if (tables.Length > 0)
                {
                    RateObject rate = tables[0].Rates.Where(r => r.Code == currency).FirstOrDefault();

                    if (rate != null)
                        return rate;
                    else return null;
                }
            }
            return null;
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
            public double Mid { get; set; }
        }
    }
}
