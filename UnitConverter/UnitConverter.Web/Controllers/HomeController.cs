using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

        public decimal Convert(string unitFrom, string unitTo, string valueToConvert,
    string converterType)
        {
            UnitConverter converter = converterService.UnitConverters[converterType];
            decimal output = 0;
            converterService.Convert(converterType, unitFrom, unitTo, decimal.Parse(valueToConvert), out output);

            return output;
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}