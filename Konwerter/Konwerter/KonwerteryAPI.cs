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
    public class KonwerteryAPI
    {
        public List<KonwerterCs> GetConverters()
        {
            string url = @"https://localhost:44309/api/konwerter/";

            using (WebClient client = new WebClient())
            {
                byte[] jsonData = client.DownloadData(url);
                string json = Encoding.UTF8.GetString(jsonData);

                KonwerterCs[] konwertery = JsonConvert.DeserializeObject<KonwerterCs[]>(json);

                return new List<KonwerterCs>(konwertery);

            }
        }

        public double Przelicz(string FromUnit, string ToUnit, string valueToConvert, string converterType, string repo)
        {
            string url = @"https://localhost:44309/api/konwerter/przelicz?";

            NameValueCollection queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString.Add("FromUnit", FromUnit);
            queryString.Add("ToUnit", ToUnit);
            queryString.Add("valueToConvert", valueToConvert);
            queryString.Add("converterType", converterType);
            queryString.Add("repo", repo);

            using (WebClient client = new WebClient())
            {
                string urlwithparameters = url + queryString.ToString();

                string valueString = client.DownloadString(urlwithparameters);

                return double.Parse(valueString, CultureInfo.InvariantCulture);
            }
        }
        public List<Rekord> pobierzRekordy(string repo)
        {
            string url = @"https://localhost:44309/api/konwerter/pokaz?";
            NameValueCollection queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString.Add("Repo", repo);

            using (WebClient client = new WebClient())
            {
                string urlwithparameters = url + queryString.ToString();
                byte[] jsonData = client.DownloadData(urlwithparameters);
                string json = Encoding.UTF8.GetString(jsonData);

                Rekord[] rekordy = JsonConvert.DeserializeObject<Rekord[]>(json);

                return new List<Rekord>(rekordy);
            }
        }
    }
    public class Rekord
    {
        //public int Id { get; set; }

        public DateTime? DateTime { get; set; }

        public string Type { get; set; }

        public string FromUnit { get; set; }

        public string ToUnit { get; set; }

        public string RawValue { get; set; }

        public string ConvertedValue { get; set; }
    }
    public class KonwerterCs
    {
        public string Typ { get; set; }
        public List<string> Jednostki { get; set; }
    }
}

