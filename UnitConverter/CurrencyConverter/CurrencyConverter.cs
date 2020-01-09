using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using UnitConversion;

namespace CurrencyConverter
{
    [ConverterClassType(ClassType.Constant)]
    public class CurrencyConverter : UnitConverter
    {
        private string name = "Konwerter walut";
        public override string Name
        {
            get => name;
            set => name = value;
        }

        public CurrencyConverter()
        {
            FillUnits();
        }

        private void FillUnits()
        {
            units = new Dictionary<string, Unit>();
            units.Add("PLN", new Unit("PLN", (x) => x, (x) => x));
            units.Add("EUR", new Unit("EUR", (x) => x / GetCurrencyRate("EUR"), (x) => x * GetCurrencyRate("EUR")));
        }

        private decimal GetCurrencyRate(string currency)
        {
            string url = @"http://api.nbp.pl/api/exchangerates/rates/A/" + currency + "/last/1/?format=json";

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);

                CurrencyObject curr = JsonConvert.DeserializeObject<CurrencyObject>(json);

                if (curr.rates != null && curr.rates.Length > 0)
                {
                    decimal rate = -1;
                    decimal.TryParse(curr.rates[0].Mid, System.Globalization.NumberStyles.Any, new CultureInfo("en-US"), out rate);
                    return rate;
                }
                else return -1;
            }
        }

        public class CurrencyObject
        {
            public string Table { get; set; }
            public string Currency { get; set; }
            public string Code { get; set; }
            public RateObject[] rates { get; set; }
        }

        public class RateObject
        {
            public string No { get; set; }
            public DateTime EffectiveDate { get; set; }
            public string Mid { get; set; }
        }
    }
}
