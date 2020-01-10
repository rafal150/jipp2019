using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace UnitConverter.Desktop
{
    public class UnitConverterApi
    {
        public UnitConverterApi()
        {
            //Trust all certificates
            ServicePointManager.ServerCertificateValidationCallback =
                ((sender, certificate, chain, sslPolicyErrors) => true);
        }

        public List<Converter> GetConverters()
        {
            try
            {
                var getConvertersRequest = "https://localhost:44373/api/converters/";

                using (WebClient client = new WebClient())
                {
                    byte[] jsonData = client.DownloadData(getConvertersRequest);
                    string json = Encoding.UTF8.GetString(jsonData);

                    Converter[] converters = JsonConvert.DeserializeObject<Converter[]>(json);

                    return new List<Converter>(converters);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Converter>();
            }
        }

        public decimal Convert(string unitFrom, string unitTo, string valueToConvert, string converterType)
        {
            try
            {
                var converterUnitRequest = "https://localhost:44373/api/converters/convert?";

                NameValueCollection queryString = HttpUtility.ParseQueryString(string.Empty);
                queryString.Add("unitFrom", unitFrom);
                queryString.Add("unitTo", unitTo);
                queryString.Add("valueToConvert", valueToConvert);
                queryString.Add("converterType", converterType);

                using (WebClient client = new WebClient())
                {
                    string urlwithparameters = converterUnitRequest + queryString.ToString();

                    string valueString = client.DownloadString(urlwithparameters);

                    return decimal.Parse(valueString, CultureInfo.InvariantCulture);
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public List<StatisticItem> GetStatistics()
        {
            try
            {
                var getStatisticsRequest = "https://localhost:44373/api/converters/statistics";

                using (WebClient client = new WebClient())
                {
                    byte[] jsonData = client.DownloadData(getStatisticsRequest);
                    string json = Encoding.UTF8.GetString(jsonData);

                    StatisticItem[] converters = JsonConvert.DeserializeObject<StatisticItem[]>(json);

                    return new List<StatisticItem>(converters);
                }
            }
            catch (Exception)
            {
                return new List<StatisticItem>();
            }
        }

        public List<HistoryItem> GetHistory()
        {
            try
            {
                var getStatisticsRequest = "https://localhost:44373/api/converters/history";

                using (WebClient client = new WebClient())
                {
                    byte[] jsonData = client.DownloadData(getStatisticsRequest);
                    string json = Encoding.UTF8.GetString(jsonData);

                    HistoryItem[] converters = JsonConvert.DeserializeObject<HistoryItem[]>(json);

                    return new List<HistoryItem>(converters);
                }
            }
            catch (Exception)
            {
                return new List<HistoryItem>();
            }
        }
    }
}
