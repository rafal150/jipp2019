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
    public class ConvertersApi
    {
        public List<Converter> GetConverters()
        {
            string url = @"http://localhost:50116/api/converters/";

            using (WebClient client = new WebClient())
            {
                byte[] jsonData = client.DownloadData(url);
                string json = Encoding.UTF8.GetString(jsonData);

                Converter[] converters = JsonConvert.DeserializeObject<Converter[]>(json);

                return new List<Converter>(converters);

            }
        }

        public double Convert(string fromUnit, string toUnit, string valueToConvert, string conversionType)
        {
            string url = @"http://localhost:50116/api/converters/convert?";

            NameValueCollection queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString.Add("fromUnit", fromUnit);
            queryString.Add("toUnit", toUnit);
            queryString.Add("valueToConvert", valueToConvert);
            queryString.Add("conversionType", conversionType);

            using (WebClient client = new WebClient())
            {
                string urlwithparameters = url + queryString.ToString();

                string valueString = client.DownloadString(urlwithparameters).Replace(".", ",");

                return double.Parse(valueString);
            }
        }

        public List<StatisticsDTO> GetStatistics()
        {
            string url = @"http://localhost:50116/api/converters/stats/";

            using (WebClient client = new WebClient())
            {
                byte[] jsonData = client.DownloadData(url);
                string json = Encoding.UTF8.GetString(jsonData);

                StatisticsDTO[] statistics = JsonConvert.DeserializeObject<StatisticsDTO[]>(json);

                return new List<StatisticsDTO>(statistics);
            }
        }
    }
    public class Converter
    {
        public string Name { get; set; }
        public List<string> Units { get; set; }
    }
}