using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter.Logic
{
    class CurrencyConverterApi
    {

        string url = @"http://api.nbp.pl/api/exchangerates/tables/A/?format=json";


        public decimal Currency(string a)
        {
            using WebClient client = new WebClient();
            string json = client.DownloadString(url);

            TableObject[] tables = JsonConvert.DeserializeObject<TableObject[]>(json);


            RateObject rate = tables[0].Rates.Where(r => r.Code == a).FirstOrDefault();



            return rate.Mid;
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
            public decimal Mid { get; set; }
        }
    }
}

