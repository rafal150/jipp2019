using Autofac;
using ConverterSDK;
using Logic;
using Logic.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace WWW.Controllers
{
    public class HomeController : Controller
    {
        private ConverterService convertersService;
        private ILifetimeScope scope;

        public HomeController(ILifetimeScope scope, IStatisticsRepository statisticsRepository, ConverterService convertersService)
        {
            this.convertersService = convertersService;
            this.scope = scope;
        }

        public ActionResult Index()
        {
            List<ConverterInterface> converters = this.convertersService.GetConverters();
            return View(converters);
        }

        public decimal Convert(string fromUnit, string toUnit, string valueToConvert,
            string converterType)
        {
            Object converter = Type.GetType(converterType).GetConstructor(new Type[] { }).Invoke(new object[] { });

            Object classInstance = converter;
            double convertFromValue = Double.Parse(valueToConvert.Replace(".", ","));
            decimal convertedValue;
            Type classType = classInstance.GetType();
            PropertyInfo set = classType.GetProperty(fromUnit);
            PropertyInfo get = classType.GetProperty(toUnit);
            if (set == null || get == null)
            {
                throw new MethodAccessException();
            }
            set.SetValue(classInstance, convertFromValue);
            convertedValue = Decimal.Parse(get.GetValue(classInstance).ToString());
            //DbLog(convertFromValue, fromUnit, toUnit, convertedValue);
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