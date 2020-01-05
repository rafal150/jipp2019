using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace UnitConversion.Web.Controllers
{
    public class HomeController : Controller
    {
        ConverterService converterService;

        public HomeController(ConverterService service)
        {
            this.converterService = service;
        }

        public ActionResult Index()
        {
            List<UnitConverter> converters = converterService.GetConverters();
            return View(converters);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult ConversionHistory()
        {
                string url = @"http://localhost:50189/api/conversionhistory";
                return View(new List<ConversionHistoryDTO>(GetObjectApiResponse<ConversionHistoryDTO[]>(url)));
    
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

    public string Convert(string unitFrom, string unitTo, string valueToConvert,
    string converterType)
        {
            string url = @"http://localhost:50189/api/converters/convert?";

            NameValueCollection queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString.Add("unitFrom", unitFrom);
            queryString.Add("unitTo", unitTo);
            queryString.Add("valueToConvert", valueToConvert);
            queryString.Add("converterType", converterType);

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string urlParam = url + queryString.ToString();
                    HttpResponseMessage message = client.GetAsync(urlParam).Result;
                    string value = message.Content.ReadAsStringAsync().Result;
                    return value;
                }
            }
            catch (HttpRequestException ex)
            {
                return ex.ToString();
            }
            //UnitConverter converter = converterService.UnitConverters[converterType];
            //decimal output = 0;
            //try
            //{
            //    converterService.Convert(converterType, unitFrom, unitTo, decimal.Parse(valueToConvert), out output);

            //}
            //catch
            //{
            //    return "Niepoprawny format wartości do przeliczenia"; 
            //}
            //return output.ToString();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Body(string converterType)
        {
            UnitConverter converter = converterService.UnitConverters[converterType];
            return PartialView("ConverterBody", converter);
        }
    }
}