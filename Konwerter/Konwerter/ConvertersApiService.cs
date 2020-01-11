using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Konwerter
{
    public class ConvertersApiService
    {
        public List<Converter> GetConverters()
        {
            string url = @"https://localhost:44384/api/converters/";

            using (WebClient client = new WebClient())
            {
                byte[] jsonData = client.DownloadData(url);
                string json = Encoding.UTF8.GetString(jsonData);

                Converter[] converters = JsonConvert.DeserializeObject<Converter[]>(json);

                return new List<Converter>(converters);

            }
        }
        public double Liczenie(string z, string na, string wartDoKonwersji,
            string converterType)
        {
            string url = @"https://localhost:44384/api/converters/convert?";

            NameValueCollection queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString.Add("z", z);
            queryString.Add("na", na);
            queryString.Add("wartDoKonwersji", wartDoKonwersji);
            queryString.Add("converterType", converterType);

            using (WebClient client = new WebClient())
            {
                string urlwithparameters = url + queryString.ToString();

                string valueString = client.DownloadString(urlwithparameters);
                //return double.Parse(valueString);
                return double.Parse(valueString.Replace(".", ",")); 
            }
        }


        public class Converter
        {
            public string Name { get; set; }
            public List<string> Units { get; set; }
        }
    }
}
