using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace UnitCoverterPart2.Services
{
    public class GoldConverter : IConverter
    {
        public string Name => "Zloto";
        private readonly string nbpURL = @"http://api.nbp.pl/api/cenyzlota?format=json";
        public List<string> Units => new List<string>(new[] { "GOLD", "PLN" });

        public decimal Convert(string unitFrom, string unitTo, decimal value)
        {
            decimal rate = getRate();
            decimal result = 0;
            if (unitFrom.Equals(unitTo))
            {
                result = value;
            }
            else
            {
                if (unitFrom.Equals("GOLD") && unitTo.Equals("PLN"))
                {
                    result = value * rate;
                }
                if (unitFrom.Equals("PLN") && unitTo.Equals("GOLD"))
                {
                    result = value / rate;
                }
            }
            return result;
        }

        private decimal getRate()
        {
            decimal exhangeRate;
            using (WebClient client = new WebClient())
            {
                string response = client.DownloadString(nbpURL);
                response = response.Replace("[", "");
                response = response.Replace("]", "");
                RateObject rate = JsonConvert.DeserializeObject<RateObject>(response);
                var temp = rate.cena;
                //RateObject rate = tables[0].Rates.Where(r => r.Code == "EUR").FirstOrDefault();
                //var temp = rate.Mid;
                temp = temp.Replace(".", ",");
                exhangeRate = Decimal.Parse(temp);
            }
            return exhangeRate;
        }
        /*
        public class TableObject
        {
            public string Table { get; set; }
            public DateTime? EffectiveDate { get; set; }
            public string Rate { get; set; }
        }*/
        
        public class RateObject
        {
            public string data { get; set; }
            public string cena { get; set; }
        }

    }
}
