using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnitConverter.Converters;

namespace UnitConverter.Web.Controllers {
    public class HomeController : Controller {
        ILifetimeScope scope;
        private IStatisticsRepository statisticsRepository;
        private Converters.Converters converters;
        public HomeController(ILifetimeScope scope, IStatisticsRepository statisticsRepository, Converters.Converters converters) {
            this.scope = scope;
            this.statisticsRepository = statisticsRepository;
            this.converters = converters;
        }
        public ActionResult Index() {
            List<Converters.IConverter> converters = this.converters.GetConverters();
            return View(converters);
        }

        public double Convert(string unitFrom, string unitTo, string valueFrom, string conversionType) {
            if (!double.TryParse(valueFrom.Replace(".", ","), out double value)) {
                throw new Exception("An error occured while trying to parse string to double");
            }
            IConverter converter = scope.Resolve(Type.GetType(conversionType)) as IConverter;
            return converter.Convert(unitFrom, unitTo, value);
        }

        public ActionResult About() {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact() {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}