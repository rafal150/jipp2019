using Autofac;
using KonwerterSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using WpfApp7;
using WpfAppJIPP;

namespace Unitconverter.web.Controllers
{
    public class HomeController : Controller
    {
        private KonwerterService konwerterService;
        private ILifetimeScope scope;

        public HomeController(ILifetimeScope scope, IStatisticsRepository statisticsRepository, KonwerterService convertersService)
        {
            this.konwerterService = convertersService;
            this.scope = scope;
        }

        public ActionResult Index()
        {
           
            List<InterfejsKonwerter> converters = this.konwerterService.GetConverters();

            return View(converters);
           
        }

        public decimal Convert(string unitFrom, string unitTo, string valueToConvert,
            string converterType)
        {
            Object converter = Type.GetType(converterType)
                .GetConstructor(new Type[] { })
                    .Invoke(new object[] { });
            double convertFromValue = Double.Parse(
                valueToConvert.Replace(".", ","));
            decimal convertedValue;
            Type typeClass = converter.GetType();
            PropertyInfo set = typeClass.GetProperty(unitFrom);
            PropertyInfo get = typeClass.GetProperty(unitTo);
            set.SetValue(converter, convertFromValue);
            convertedValue = Decimal.Parse(get.GetValue(converter).ToString());
            return convertedValue;
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