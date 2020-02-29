using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Przelicznik_Jednostek.Services;

namespace Przelicznik_Jednostek.web.Controllers
{
    public class HomeController : Controller
    {
        
        
            private ConvertersService convertersService;
            private ILifetimeScope scope;

            public HomeController(ILifetimeScope scope, IStatisticsRepository statisticsRepository, ConvertersService convertersService)
            {
                this.convertersService = convertersService;
                this.scope = scope;
            }

            public ActionResult Index()
            {
                List<iKonwerter> converters = this.convertersService.GetConverters();

                return View(converters);
            }

            public decimal Convert(string unitFrom, string unitTo, string valueToConvert,
                string converterType)
            {
                iKonwerter converter = this.scope.Resolve(Type.GetType(converterType)) as iKonwerter;

                decimal output = converter.Convert(unitFrom, unitTo, decimal.Parse(valueToConvert));

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