using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unitconverter.Services;

namespace UnitConverter.Web.Controllers
{
    public class HomeController : Controller
    {
        private ConvServices conveterServices;
        private ILifetimeScope scope;
        public HomeController(ILifetimeScope scope, Unitconverter.IStatisticsRepository repo, ConvServices convserv)
        {
            this.scope = scope;
            conveterServices = convserv;
        }
        public ActionResult Index()
        {
            IEnumerable<IConverter> converters = this.conveterServices.GetConverters();
            return View(converters);
        }

        public decimal Convert(string unitfrom, string unitTo, string valuetoconvert, string converterType)
        {
            IConverter converter = this.scope.Resolve(Type.GetType(converterType)) as IConverter;
            decimal wynik = (decimal)converter.Convert(unitfrom, unitTo, int.Parse(valuetoconvert));
            return wynik;
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