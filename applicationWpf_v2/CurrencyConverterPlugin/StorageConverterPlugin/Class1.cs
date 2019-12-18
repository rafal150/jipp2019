using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using applicationWpf;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CurrencyConverterPlugin
{
    public class CurrencyConverterPlugin : ConverterBase
    {
        double value, convertedValue = double.NaN;
        int fromIndex, toIndex;

        public string[] suffix => new string[]
    {
            "EUR",
            "PLN"
    };

        public string[] indexes => new string[]
    {
                "Euro",
                "PLN"
    };

        public string converterName => "currency";

        private double currentRate = 4d;
        public double Convert(double value, int fromIndex, int toIndex)
        {
            string uri = @"https://api.nbp.pl/api/exchangerates/rates/a/eur/";
            using (WebClient wc = new WebClient())
            {
                string packet = wc.DownloadString(uri);
                JObject obj = JsonConvert.DeserializeObject(packet) as JObject;
                JToken test = obj["rates"][0]["mid"];
                currentRate = double.Parse(test.ToString());
            }

            this.value = value;
            this.fromIndex = fromIndex;
            this.toIndex = toIndex;
            switch (indexes[fromIndex])
            {
                case "Euro":
                    {
                        EuroConvert();
                        break;
                    }
                case "PLN":
                    {
                        PLNConvert();
                        break;
                    }
                default:
                    return convertedValue;
                    
            }
            return convertedValue;
        }

        public string GetConvertedString()
        {
            if (convertedValue != double.NaN)
                return $"{convertedValue} {suffix[toIndex]}";
            else return "NaN";
        }

        private void PLNConvert()
        {
            switch (indexes[toIndex])
            {
                case "Euro":
                    convertedValue = value / currentRate;
                    break;
                default:
                    convertedValue = value;
                    break;
            }
        }

        private void EuroConvert()
        {
            switch (indexes[toIndex])
            {
                case "PLN":
                    convertedValue = value * currentRate;
                    break;
                default:
                    convertedValue = value;
                    break;
            }
        }
    }
}
