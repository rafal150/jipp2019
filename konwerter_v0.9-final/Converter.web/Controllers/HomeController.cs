using Autofac;
using konwerter;
using konwerter.services;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Converter.web.Controllers
{
    public class HomeController : Controller
    {
        private ConvertersService converters;

        private ILifetimeScope scope;

        public HomeController(ILifetimeScope scope, IUsageStatisticsRepo repo, ConvertersService converters)
        {
            this.converters = converters;
            this.scope = scope;
        }

        public ActionResult Index()
        {
            List<IConverter> converters = this.converters.GetConverters();

            return View(converters);
        }

        public decimal Convert(string unitFrom, string unitTo, string valueToConvert,
            string converterType)
        {
            IConverter converters = this.scope.Resolve(Type.GetType(converterType)) as IConverter;

            decimal output = converters.Convert(unitFrom, unitTo, decimal.Parse(valueToConvert));

            return output;
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}