using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KonwerterZSQLiAZUREiPLUGIN;
using KonwerterZSQLiAZUREiPLUGIN.Services;

namespace UnitConverter.Web.Controllers
{
    public class HomeController : Controller
    {
        private ConvertersService convertersService;
        private ILifetimeScope scope;

        public HomeController(ILifetimeScope scope, ADDStat statisticsRepository, ConvertersService convertersService)
        {
            this.convertersService = convertersService;
            this.scope = scope;
        }

        public ActionResult Index()
        {
            List<KonwerterInterfejs> converters = this.convertersService.GetConverters();

            return View(converters);
        }

        public decimal Convert(string unitFrom, string unitTo, string valueToConvert,
            string converterType)
        {
            KonwerterInterfejs converter = this.scope.Resolve(Type.GetType(converterType)) as KonwerterInterfejs;

            decimal output = converter.Convert(unitFrom, unitTo, decimal.Parse(valueToConvert));

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