using Autofac;
using JIPP5.SDK;
using JIPP5_LAB;
using JIPP5_LAB.bazydanych;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JIPP5.WEB.Controllers
{
    public class HomeController : Controller
    {
        private ConvertersService convertersService;
        private ILifetimeScope scope;
        private IPobieranieDanych repo;

        public HomeController(ILifetimeScope scope, IPobieranieDanych statisticsRepository, ConvertersService convertersService)
        {
            this.convertersService = convertersService;
            this.scope = scope;
            this.repo = statisticsRepository;
        }

        public ActionResult Index()
        {
            List<IKonwerter> converters = this.convertersService.GetConverters();
            return View(converters);
        }

        public decimal Convert(string unitFrom, string unitTo, string valueToConvert, string converterType)
        {
            IKonwerter converter = this.scope.Resolve(Type.GetType(converterType)) as IKonwerter;
            var value = decimal.Parse(valueToConvert);
            decimal output = converter.Converter(unitFrom, value, unitTo);
            repo.AddStatistic(new StatisticDTO()
            {
                ConvertedValue = output,
                DateTime = DateTime.Now,
                RawValue = value,
                UnitFrom = unitFrom,
                UnitTo = unitTo
            });
            return output;
        }

        public ActionResult About()
        {
            var statiscits = repo.GetStatistics();
            return View(statiscits);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}