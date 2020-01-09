using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Specialized;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Text;
using System.Web;
using Newtonsoft.Json;

namespace SEM5WPF_1
{
    class KonwertersApi
    {

        public List<Konwerter> GetConverters()
        {
            string url = @"https://localhost:44322/api/konwerters/konwert/";

            using (WebClient client = new WebClient())
            {
                byte[] jsonData = client.DownloadData(url);
                string json = Encoding.UTF8.GetString(jsonData);
                Konwerter[] konwerters = JsonConvert.DeserializeObject<Konwerter[]>(json);
                return new List<Konwerter>(konwerters);

            }
        }

        public decimal Konwerter(string jednostkaZ, string jednostkaDo, string wartosc,
       string konwerterType)
        {
            string url = @"https://localhost:44322/api/konwerters/konwert?";

            NameValueCollection queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString.Add("jednostkaZ", jednostkaZ);
            queryString.Add("jednostkaDo", jednostkaDo);
            queryString.Add("wartosc", wartosc);
            queryString.Add("konwerterType", konwerterType);

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
