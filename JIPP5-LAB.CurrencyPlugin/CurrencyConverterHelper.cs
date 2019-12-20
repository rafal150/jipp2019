using JIPP5_LAB.SDK;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace JIPP5_LAB.Plugin
{
    public class CurrencyConverterHelper : IConverterHelper
    {
        public string Name => "Waluty";

        public List<string> UnitTypes => new List<string>()
        {
            "EUR",
            "PLN",
        };

        public string Convert(string fromUnit, decimal input, string toUnit, out decimal convertedValue)
        {
            NumberFormatInfo setPrecision = new NumberFormatInfo
            {
                NumberDecimalDigits = 2
            };

            const string url = "http://api.nbp.pl/api/exchangerates/tables/A/today/?format=json";
            decimal euro = 0;
            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);

                ReadObject[] data = JsonConvert.DeserializeObject<ReadObject[]>(json);

                if (data.Length > 0)
                {
                    EntityObject entity = Array.Find(data[0].Rates, r => r.Code == "EUR");
                    euro = decimal.Parse(entity?.Mid, new CultureInfo("en-US"));
                }
            }

            if (fromUnit == "EUR")
            {
                if (toUnit == "EUR")
                {
                    convertedValue = input;
                    return input.ToString();
                }
                convertedValue = input * euro;
                return convertedValue.ToString();
            }
            else if(fromUnit == "PLN")
            {
                if (toUnit == "PLN")
                {
                    convertedValue = input;
                    return input.ToString();
                }
                convertedValue = input / euro;
                return convertedValue.ToString();
            }
            convertedValue = -1;
            return null;
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
