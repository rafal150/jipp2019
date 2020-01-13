using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnitConverter;
using UnitConverter.Services;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Data.SqlClient;

namespace UnitConverter.Web.Controllers
{
    public class HomeController : Controller
    {
        private ConvertersService convertersService;
        private ILifetimeScope scope;

        public HomeController(ILifetimeScope scope, InterfejsStatystyki statisticsRepository, ConvertersService convertersService)
        {
            this.convertersService = convertersService;
            this.scope = scope;
        }

        public ActionResult Index()
        {
            List<InterfejsKonwerter> converters = this.convertersService.GetConverters();

            return View(converters);
        }

        public decimal Convert(string unitFrom, string unitTo, string valueToConvert,
            string converterType)
        {
            InterfejsKonwerter converter = this.scope.Resolve(Type.GetType(converterType)) as InterfejsKonwerter;

            decimal output = converter.Convert(unitFrom, unitTo, decimal.Parse(valueToConvert));

            return output;
        }

        public ActionResult About()
        {
            ViewBag.Message = "Informacje szczegółowe o twoim konwerterze jednostek";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Strona z kontaktami. ";

            return View();
        }

    }
}