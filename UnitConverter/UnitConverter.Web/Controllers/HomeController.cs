using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace UnitConversion.Web.Controllers
{
    public class HomeController : Controller
    {
        ConverterService converterService;
        IServiceRepository serviceRepository;

        public HomeController(ConverterService service, IServiceRepository repository)
        {
            this.converterService = service;
            this.serviceRepository = repository;
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

        public ActionResult Converters()
        {
            return View(serviceRepository.GetConverters());
        }

        public ActionResult AddEditConverter(string converterType)
        {
            if (string.IsNullOrEmpty(converterType))
                return PartialView();
            else
                return PartialView(serviceRepository.GetConverters().FirstOrDefault(x => x.Name == converterType));
        }

        public ActionResult SaveConverter(string converterType, string Name)
        {
            serviceRepository.SaveConverter(converterType, Name);
            return View("Converters", serviceRepository.GetConverters());
        }

        public ActionResult DeleteConverter(string converterType)
        {
            serviceRepository.DeleteConverter(converterType);
            return View("Converters", serviceRepository.GetConverters());
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
        }

        public ActionResult ConverterUnits(string converterType)
        {
            return PartialView(serviceRepository.GetConverters().FirstOrDefault(x => x.Name == converterType));
        }

        public ActionResult AddEditConverterUnit(string converterType, string unitName)
        {
            if (string.IsNullOrEmpty(unitName))
                return PartialView(new ConverterUnitDTO() { Converter = serviceRepository.GetConverters().FirstOrDefault(x => x.Name == converterType) });
            else
                return PartialView(serviceRepository.GetConverters().FirstOrDefault(x => x.Name == converterType).Units.FirstOrDefault(y => y.Name == unitName));
        }

        public ActionResult SaveConverterUnit(string converterType, string converterUnitName, string Name, string ConversionToBaseValueFormula, string ConversionFromBaseValueFormula)
        {
            serviceRepository.SaveConverterUnit(converterType, converterUnitName, Name, ConversionToBaseValueFormula, ConversionFromBaseValueFormula);
            return PartialView("ConverterUnits", serviceRepository.GetConverters().FirstOrDefault(x => x.Name == converterType));
        }

        public ActionResult DeleteConverterUnit(string converterType, string unitName)
        {
            serviceRepository.DeleteConverterUnit(converterType, unitName);
            return PartialView("ConverterUnits", serviceRepository.GetConverters().FirstOrDefault(x => x.Name == converterType));
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

        public ActionResult RemoveMyView()
        {
            return Content("");
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
}