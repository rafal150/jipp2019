using Autofac;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace applicationWpf
{
    public class ConverterService
    {
        ILifetimeScope scope;

        public ConverterService(ILifetimeScope scope)
        {
            this.scope = scope;
        }

        public List<Converter> GetConverters()
        {
            string url = @"https://localhost:44320/api/converters/";

            using (WebClient client = new WebClient())
            {
                byte[] jsonData = client.DownloadData(url);
                string json = Encoding.UTF8.GetString(jsonData);

                Converter[] converters = JsonConvert.DeserializeObject<Converter[]>(json, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore, MissingMemberHandling = MissingMemberHandling.Ignore }) ;

                return new List<Converter>(converters);

            }

            //List<ConverterBase> converters = new List<ConverterBase>();

            //converters.AddRange(this.scope.Resolve<IEnumerable<ConverterBase>>());
            //return converters;
        }

        public double Convert(string unitFrom, string unitTo, string valueToConvert,
     string converterType)
        {
            string url = @"https://localhost:44320/api/converters/convert?";

            NameValueCollection queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString.Add("unitFrom", unitFrom);
            queryString.Add("unitTo", unitTo);
            queryString.Add("valueToConvert", valueToConvert);
            queryString.Add("converterType", converterType);

            using (WebClient client = new WebClient())
            {
                string urlwithparameters = url + queryString.ToString();

                string valueString = client.DownloadString(urlwithparameters);

                return double.Parse(valueString.Replace(".", ","));
            }
        }

        public class Converter
        {
            public List<string> suffix { get; set; }
            public List<string> indexes { get; set; }
            public string converterName { get; set; }
        }
    }
}
