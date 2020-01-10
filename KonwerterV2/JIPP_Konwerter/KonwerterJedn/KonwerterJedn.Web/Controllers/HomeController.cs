using Autofac;
using KonwerterJedn.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KonwerterJedn.Web.Controllers
{
    public class HomeController : Controller
    {
        private KonwerterJednostek konwerterJednostek;
        private ILifetimeScope scope;

        public HomeController(ILifetimeScope scope, KonwerterJednostek konwerterJednostek)
        {
            this.konwerterJednostek = konwerterJednostek;
            this.scope = scope;

        }


        public ActionResult Index()
        {
            List<IConverter> konwertery = this.konwerterJednostek.GetConverters();

            return View(konwertery);
        }

        public double Convert(string unitFrom, string unitTo, string valueFrom, string converterType)
        {
            IConverter converter = this.scope.Resolve(Type.GetType(converterType)) as IConverter;

            double output = converter.Convert(unitFrom, unitTo, double.Parse(valueFrom));

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