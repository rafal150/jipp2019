using Autofac;
using JIPP5.SDK;
using JIPP5_LAB;
using JIPP5_LAB.Data;
using JIPP5_LAB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JIPP5.web.Controllers
{
    public class HomeController : Controller
    {
        private ConvertersService convertersService;
        private ILifetimeScope scope;
        private IGetData repo;

        public HomeController(ILifetimeScope scope, IGetData statisticsRepository, ConvertersService convertersService)
        {
            this.convertersService = convertersService;
            this.scope = scope;
            this.repo = statisticsRepository;
        }

        public ActionResult Index()
        {
            List<IConverter> converters = this.convertersService.GetConverters();

            return View(converters);
        }

        public decimal Convert(string unitFrom, string unitTo, string valueToConvert, string converterType)
        {
            IConverter converter = this.scope.Resolve(Type.GetType(converterType)) as IConverter;
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