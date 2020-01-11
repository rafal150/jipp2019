using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace WPFKonwerter
{
    public class Converter
    {
        public string ConverterName { get; set; }
        public List<string> Units { get; set; }
    }
    public class ApiConverters
    {
        string baseUrl = "https://localhost:44381/api/convertersApi/";
        public List<Converter> GetConverters()
        {
            using (WebClient webClient= new WebClient())
            {
                string json = Encoding.UTF8.GetString(webClient.DownloadData(baseUrl));
                List<Converter> converters = JsonConvert.DeserializeObject<List<Converter>>(json);//<Converter[]>(json);
                return converters;
            }
        }
        public string Convert(string unitFrom, string unitTo, 
                               double valueFrom, string converterType)
        {
            //string url = @"https://localhost:44373/api/convertersApi/convert?";

            NameValueCollection queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString.Add("unitFrom", unitFrom);
            queryString.Add("unitTo", unitTo);
            queryString.Add("valueFrom", valueFrom.ToString());
            queryString.Add("converterType", converterType);

            using (WebClient client = new WebClient())
            {
                string urlwithparameters = baseUrl+ "convert?" + queryString.ToString();
                string valueString = client.DownloadString(urlwithparameters);

                return valueString;
            }
        }
    }
}
