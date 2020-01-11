using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Konwerter.Serwisy;
using KonwerterNS;

namespace KonwerterJednostek.Web.Controllers
{
    public class HomeController : Controller
    {
        private KonwerterSerwisy konwerterSerwisy;
        private ILifetimeScope scope;
        public HomeController(ILifetimeScope scope, IStatisticsRepository repo, KonwerterSerwisy konwerterSerwisy)
        {
            this.konwerterSerwisy = konwerterSerwisy;
            this.scope = scope;
        }
        public ActionResult Index()
        {
            IEnumerable<IKonwerter> konwerters = this.konwerterSerwisy.WczytajKonwertery();
            return View(konwerters);
        }

        public decimal Konwertuj(string jednostkaNa, string jednostkaZ, string input, string converterType)
        {
            IKonwerter konwerter = this.scope.Resolve(Type.GetType(converterType)) as IKonwerter;
            List<string> list = konwerter.Jednostki;
            var tmp = list.FindIndex(x => x.StartsWith(jednostkaNa));
            var tmp2 = list.FindIndex(x => x.StartsWith(jednostkaZ));
            var result = konwerter.Konwertuj(tmp, tmp2, Convert.ToDouble(input));
            return result;
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