using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Konwerter5;
using Konwerter5.Logic.Uslugi;
using Autofac;

namespace Konwerter5.Web.Controllers
{
    public class HomeController : Controller
    {
        private Konwerter5Usluga _usluga;
        private ILifetimeScope _scope;
        public HomeController(ILifetimeScope scope, Konwerter5Usluga usluga)
        {
            _usluga = usluga;
            _scope = scope;

        }
        public ActionResult Index()
        {
            List<IKonwerter5> konwertery = _usluga.PobierzKonwertery();
            return View(konwertery);
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