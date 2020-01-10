using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace WpfApp1
{
    class ConverterApi
    {
        private Dictionary<string, List<string>> properties;
        public List<string> GetConverters()
        {
        string url = "http://localhost:49264/api/converters/";

            using (WebClient client = new WebClient())
            {
                byte[] jsonData = client.DownloadData(url);
                string json = Encoding.UTF8.GetString(jsonData);
                this.properties = new Dictionary<string, List<string>>();
                List<string> converters = new List<string>();
                JArray jsonObject = JArray.Parse(json);
                int i = 0;
                string name;
                List<string> units;
                foreach (JObject jObject in jsonObject.Children<JObject>())
                {
                    name = "";
                    units = new List<string>();
                    foreach (JProperty jProperty in jObject.Properties())
                    {
                        if(jProperty.Name == "name")
                        {
                            name = jProperty.Value.ToString();
                            converters.Add(name);
                        }
                        else
                        {
                            units.Add(jProperty.Name.ToString());
                        }
                    }
                    this.properties.Add(name, units);
                }
                
                return converters;

            }
        }

        public List<string> GetUnits(string className)
        {
            return this.properties[className];
        }

        public static decimal Convert(string unitFrom, string unitTo, string valueToConvert,
             string converterType)
        {
            string url = @"http://localhost:49264/api/converters/convert?";

            NameValueCollection queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString.Add("unitFrom", unitFrom);
            queryString.Add("unitTo", unitTo);
            queryString.Add("valueToConvert", valueToConvert);
            queryString.Add("converterType", converterType);

            using (WebClient client = new WebClient())
            {
                string urlwithparameters = url + queryString.ToString();

                string valueString = client.DownloadString(urlwithparameters);

                return decimal.Parse(valueString.Replace('.', ','));
            }
        }
    }
}
