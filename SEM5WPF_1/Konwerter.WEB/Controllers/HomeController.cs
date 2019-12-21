using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SEM5WPF_1;
using Autofac;
using SEM5WPF_1.Services;
using Newtonsoft.Json;

namespace Konwerter.WEB.Controllers
{
    public class HomeController : Controller
    {

        private KonwerterServices konwerterServices;
        private ILifetimeScope scope;

        public HomeController(ILifetimeScope scope, IStatystykiRepozytorium statystykiRepozytorium, KonwerterServices konwerterServices)
        {
            this.konwerterServices = konwerterServices;
            this.scope = scope;
        }


        public ActionResult Index()
        {
            List<IKonwerter> konwerters = this.konwerterServices.GetKonwerters();


            return View(konwerters);
        }

        public decimal Konwerter(string jednostkaZ, string jednostkaDo, string wartosc,
           string konwerterType)
        {
            IKonwerter konwerter = this.scope.Resolve(Type.GetType(konwerterType)) as IKonwerter;
            decimal output = konwerter.Konwerter(jednostkaZ, jednostkaDo, decimal.Parse(wartosc));
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