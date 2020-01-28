using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace UnitCoverterPart2
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
                valueString = valueString.Replace('.', ',');
                double temp;
                try
                {
                    temp = double.Parse(valueString);
                }
                catch(FormatException)
                {
                    temp = 0;
                }
                return (decimal)(temp);
            }
        }

        public List<Record> getRecords(string repo)
        {
            string url = @"https://localhost:44373/api/konwerter/show?";
            NameValueCollection queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString.Add("Repo", repo);

            using (WebClient client = new WebClient())
            {
                string urlwithparameters = url + queryString.ToString();
                byte[] jsonData = client.DownloadData(urlwithparameters);
                string json = Encoding.UTF8.GetString(jsonData);

                Record[] records = JsonConvert.DeserializeObject<Record[]>(json);

                return new List<Record>(records);
            }
        }
    }

    public class Converter
    {
        public string Name { get; set; }
        public List<string> Units { get; set; }
    }

    public class Record
    {
        //public int Id { get; set; }

        public DateTime? DateTime { get; set; }

        public string Type { get; set; }

        public string UnitFrom { get; set; }

        public string UnitTo { get; set; }

        public string RawValue { get; set; }

        public string ConvertedValue { get; set; }
    }
}
