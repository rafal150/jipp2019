using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Net;
using System.Text;
using System.Web;

namespace UnitConversion
{
    public class ConvertersApi
    {
        public List<UnitConverter> GetConverters()
        {
            string url = @"http://localhost:50189/api/converters";
            return new List<UnitConverter>(GetObjectApiResponse<UnitConverter[]>(url));
        }

        public decimal Convert(string unitFrom, string unitTo, string valueToConvert, string converterType)
        {
            string url = @"http://localhost:50189/api/converters/convert?";

            NameValueCollection queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString.Add("unitFrom", unitFrom);
            queryString.Add("unitTo", unitTo);
            queryString.Add("valueToConvert", valueToConvert);
            queryString.Add("converterType", converterType);

            using (WebClient client = new WebClient())
            {
                string urlParam = url + queryString.ToString();
                string value = client.DownloadString(urlParam);
                return decimal.Parse(value, CultureInfo.InvariantCulture);
            }
        }

        public List<ConversionHistory> GetConversionHistory()
        {
            string url = @"http://localhost:50189/api/conversionhistory";
            return new List<ConversionHistory>(GetObjectApiResponse<ConversionHistory[]>(url));
        }

        private T GetObjectApiResponse<T>(string url)
        {
            using (WebClient client = new WebClient())
            {
                byte[] jsonData = client.DownloadData(url);
                string json = Encoding.UTF8.GetString(jsonData);

                return JsonConvert.DeserializeObject<T>(json);
            }
        }

    }

    public class UnitConverter
    {
        public string Name { get; set; }
        public List<string> Units { get; set; }

        public string SourceUnit { get; set; }

        public string TargetUnit { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }

    public class ConversionHistory
    {
        public int Id { get; set; }

        public DateTime? Created { get; set; }

        public string ConversionType { get; set; }

        public string BaseUnit { get; set; }

        public decimal BaseValue { get; set; }

        public string TargetUnit { get; set; }

        public decimal TargetValue { get; set; }
    }
}
