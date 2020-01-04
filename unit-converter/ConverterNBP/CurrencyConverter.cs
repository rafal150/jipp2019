using converter;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace ConverterNBP
{
    public class CurrencyConverter : IConverter
    {
        public string Name => "Currency";

        public List<string> Units => new List<string>() { "PLN", "EUR" };

        public double Convert(string unitFrom, string unitTo, double value)
        {
            return value * GetRateFromNBP(unitFrom, unitTo);
        }

        private double GetRateFromNBP(string from, string to)
        {
            string url = @"http://api.nbp.pl/api/exchangerates/tables/A?format=json";            double rate = 1;            
            using (WebClient client = new WebClient())            {                string json = client.DownloadString(url);
                TableObject[] tables = JsonConvert.DeserializeObject<TableObject[]>(json);                
                if (tables.Length == 0) {
                    return double.NaN;
                }                if (from != "PLN")
                {
                    rate *= GetRateByCode(tables[0], from);
                }                if (to != "PLN")
                {
                    rate /= GetRateByCode(tables[0], to);
                }
            }

            return rate;
        }

        private double GetRateByCode(TableObject table, string code)
        {
            var rate = table.Rates.Where(r => r.Code == code).FirstOrDefault();
            return rate != null ? double.Parse(rate.Mid.Replace('.', ',')) : double.NaN;
        }
    }
}

class TableObject
{
    public string Table { get; set; }
    public DateTime? EffectiveDate { get; set; }
    public RateObject[] Rates { get; set; }
}

class RateObject
{
    public string Currency { get; set; }
    public string Code { get; set; }
    public string Mid { get; set; }
}
