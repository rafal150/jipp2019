using Autofac;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Konwerter;
using Konwerter.Services;

namespace Konwerter.Web.Controllers
{
    public class HomeController : Controller
    {
        private ConvertersService convertersService;
        private ILifetimeScope scope;

        public HomeController(ILifetimeScope scope, IStatisticRepository repoistory, ConvertersService convertersService)
        {
            this.convertersService = convertersService;
            this.scope = scope;
        }

        public ActionResult Index()
        {
            List<IConverting> converters = this.convertersService.GetConverters();

            return View(converters);
        }

        public double Convert(string unitFrom, string unitTo, string valueToConvert, string converterType)
        {
            IConverting converter = this.scope.Resolve(Type.GetType(converterType)) as IConverting;

            double output = converter.Convert(unitFrom, unitTo, double.Parse(valueToConvert));

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