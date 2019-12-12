using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;

namespace UnitsConverter.Services
{
    class WebApiController
    {
        static public void Main(String[] args)
        {

            string url = @"http://api.nbp.pl/api/exchangerates/rates/A/EUR/today/?format=json";

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);

                object[] tables = JsonConvert.DeserializeObject<object[]>(json);

               
                    
                        Console.WriteLine(tables);
                    
                
            }
        }

        public class TableObject
        {
            public string Table { get; set; }
            public DateTime? EffectiveDate { get; set; }
            public RateObject[] Rates { get; set; }
        }

        public class RateObject
        {
            public string Currency { get; set; }
            public string Code { get; set; }
            public string Mid { get; set; }
        }
    }
}



  