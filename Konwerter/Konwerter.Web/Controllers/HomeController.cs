using Autofac;
using Konwerter.SDK;
using Konwerter.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Konwerter.Web.Controllers
{
    public class HomeController : Controller
    {
        private ConvertersService convertersService;
        private ILifetimeScope scope;

        public HomeController(ILifetimeScope scope, IRepo repo, ConvertersService konwertery)
        {
            this.convertersService = konwertery;
            this.scope = scope;
        }
        public ActionResult Index()
        {
            List<IKonwerter> konwertery = this.convertersService.GetConverters();

            return View(konwertery);
            //return View();
        }

        public double Przelicz(string fromType, string toType, string value, string converterType)
        {
            IKonwerter konwerter= this.scope.Resolve(Type.GetType(converterType)) as IKonwerter;

            double wynik = konwerter.Przelicz(fromType, toType, double.Parse(value));

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