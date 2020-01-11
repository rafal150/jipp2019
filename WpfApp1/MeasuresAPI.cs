using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using System.Collections.Specialized;
using System.Web;

namespace WpfApp1
{
    public class MeasuresAPI
    {
        public List<Measure> GetMeasures()
        {
            string url = @"https://localhost:44317/api/measures/";

            using (WebClient client = new WebClient())
            {
                byte[] jsonData = client.DownloadData(url);
                string json = Encoding.UTF8.GetString(jsonData);

               Measure[] measures = JsonConvert.DeserializeObject<Measure[]>(json);

                return new List<Measure>(measures);

            }
        }
        public double Convert(string unitFrom, string unitTo, string valueToConvert,
             string converterType)
        {
            string url = @"https://localhost:44317/api/measures/convert?";

            NameValueCollection queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString.Add("unitFrom", unitFrom);
            queryString.Add("unitTo", unitTo);
            queryString.Add("valueToConvert", valueToConvert);
            queryString.Add("converterType", converterType);

            using (WebClient client = new WebClient())
            {
                string urlwithparameters = url + queryString.ToString();

                string valueString = client.DownloadString(urlwithparameters);

                return double.Parse((valueString), System.Globalization.CultureInfo.InvariantCulture);
            }
        }
    }

    public class Measure
    {
        public string Nam { get; set; }
        public List<string> Units { get; set; }
    }
}
