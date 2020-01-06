using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net;

namespace CurrencyConverterPlugin.CurrencyWebApi.Rates
{
    public class RatesService
    {
        private const string LastRateForCodeRequest = "http://api.nbp.pl/api/exchangerates/rates/A/{0}/last/1/?format=json";
        
        public static decimal? GetLastRate(string code)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    var request = string.Format(LastRateForCodeRequest, code.ToUpperInvariant());
                    string jsonResponse = client.DownloadString(request);

                    RatesResponse response = JsonConvert.DeserializeObject<RatesResponse>(jsonResponse);
                    var entry = response.Rates.FirstOrDefault();

                    return entry.Mid;
                }
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}
