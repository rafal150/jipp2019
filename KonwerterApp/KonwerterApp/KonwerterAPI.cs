using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace KonwerterApp.Services
{
    public class KonwerterAPI
    {
        public List<Converter> GetConverters()
        {
            string url = @"https://localhost:44399/api/konwerter/";

            using (WebClient client = new WebClient())
            {
                byte[] jsonData = client.DownloadData(url);
                string json = Encoding.UTF8.GetString(jsonData);

                Converter[] converters = JsonConvert.DeserializeObject<Converter[]>(json);

                return new List<Converter>(converters);

            }
        }

        public float Convert(string unitFrom, string unitTo, string valueToConvert,
             string converterType)
        {
            string url = @"https://localhost:44399/api/konwerter/convert?";

            NameValueCollection queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString.Add("unitFrom", unitFrom);
            queryString.Add("unitTo", unitTo);
            queryString.Add("valueToConvert", valueToConvert);
            queryString.Add("converterType", converterType);

            using (WebClient client = new WebClient())
            {
                string urlwithparameters = url + queryString.ToString();

                string valueString = client.DownloadString(urlwithparameters);

                return (float)Double.Parse(valueString);
            }
        }
    }

    public class Converter
    {
        public string Nazwa { get; set; }
        public List<string> Jednostki { get; set; }
    }
}
