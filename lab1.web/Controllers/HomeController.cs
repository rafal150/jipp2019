using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using lab1;


namespace lab1.Web.Controllers
{
    public class HomeController : Controller
    {
        private Wybor_konwertera convertersService;
        private ILifetimeScope scope;

        public HomeController(ILifetimeScope scope, IStatisticsRepository statisticsRepository, Wybor_konwertera convertersService)
        {
            this.convertersService = convertersService;
            this.scope = scope;
        }

        public ActionResult Index()
        {
            List<IKonwersja> converters = this.convertersService.GetConverters();

            return View(converters);
        }

        public double Konwertuj(string z, string na, string wartosc,
            string converterType)
        {
            IKonwersja converter = this.scope.Resolve(Type.GetType(converterType)) as IKonwersja;

            double  output = converter.Konwertuj(z, na, double.Parse(wartosc));

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