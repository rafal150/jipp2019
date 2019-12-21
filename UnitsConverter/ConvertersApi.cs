using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace UnitsConverter
{
   public class ConvertersApi
    {
        public List<Converter> GetConverters()
        {
            string url = @"https://localhost:44373/api/converters/";

            using (WebClient client = new WebClient())
            {
                byte[] jsonData = client.DownloadData(url);
                string json = Encoding.UTF8.GetString(jsonData);

                Converter[] converters = JsonConvert.DeserializeObject<Converter[]>(json);

                return new List<Converter>(converters);

            }
        }
        public decimal Convert(string unitFrom, string unitTo, string valueToConvert,
             string converterType)
        {
            string url = @"https://localhost:44373/api/converters/convert?";

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
    public class Converter
    {
      public  string Name { get; set; }
       public List<string> Units { get; set; }
    }
}
