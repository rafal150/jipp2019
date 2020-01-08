using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Konwerter
{
    public class KonwerteryAPI
    {
        public List<Konwerter> GetConverters()
        {
            string url = @"https://localhost:44309/api/konwerter/";

            using (WebClient client = new WebClient())
            {
                byte[] jsonData = client.DownloadData(url);
                string json = Encoding.UTF8.GetString(jsonData);

                Konwerter[] konwertery = JsonConvert.DeserializeObject<Konwerter[]>(json);

                return new List<Konwerter>(konwertery);

            }
        }

        public decimal Przelicz(string unitFrom, string unitTo, string valueToConvert, string converterType)
        {
            string url = @"https://localhost:44309/api/konwerter/przelicz?";

            NameValueCollection queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString.Add("unitFrom", unitFrom);
            queryString.Add("unitTo", unitTo);
            queryString.Add("valueToConvert", valueToConvert);
            queryString.Add("converterType", converterType);

            using (WebClient client = new WebClient())
            {
                string urlwithparameters = url + queryString.ToString();

                string valueString = client.DownloadString(urlwithparameters);

                return decimal.Parse(valueString);
            }
        }
    }

    public class Konwerter
    {
        public string Name { get; set; }
        public List<string> Units { get; set; }
    }
}

