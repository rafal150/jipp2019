using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;

namespace WpfApp1.SDK
{
    public static class Nbp_curr_web_srv
    {
        static string url = @"http://api.nbp.pl/api/exchangerates/tables/a/?format=json";
        static WebClient client = new WebClient();
        static string json = client.DownloadString(url);
        static TableObject[] tables = JsonConvert.DeserializeObject<TableObject[]>(json);
        public static string Getcourse()
        {
            string eu = "";
            if (tables.Length > 0)
            {
                RateObject rate = tables[0].Rates.Where(r => r.Code == "EUR").FirstOrDefault();

                if (rate != null)
                {

                    eu =(rate.Mid);
                }
            }
            return eu;
        }

    }
}
