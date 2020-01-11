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
    public class RepositoryApiService
    {
        public List<Record> GetStatistics()
        {
            string url = @"https://localhost:44384/api/converters/show?";
            NameValueCollection queryString = HttpUtility.ParseQueryString(string.Empty);

            using (WebClient client = new WebClient())
            {
                string urlwithparameters = url + queryString.ToString();
                byte[] jsonData = client.DownloadData(urlwithparameters);
                string json = Encoding.UTF8.GetString(jsonData);

                Record[] rekordy = JsonConvert.DeserializeObject<Record[]>(json);

                return new List<Record>(rekordy);
            }
        }

        public class Record
        {
            // public int Id { get; set; }

            public DateTime? DateTime { get; set; }

            public string UnitFrom { get; set; }

            public string UnitTo { get; set; }

            public double? RawValue { get; set; }

            public double? ConvertedValue { get; set; }

            public string Type { get; set; }
        }
    }
}
