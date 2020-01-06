using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnitConverter.Logic;
using UnitConverter.Logic.UnitConverters;
using UnitConverter.SDK;

namespace UnitConverter.Web.Controllers
{
    public class HomeController : Controller
    {
        private ConvertersService convertersService;
        private ILifetimeScope scope;
        private IStatisticsRepository statisticsRepository;

        public HomeController(ILifetimeScope scope, IStatisticsRepository statisticsRepository, ConvertersService convertersService)
        {
            this.convertersService = convertersService;
            this.scope = scope;
            this.statisticsRepository = statisticsRepository;
        }

        public ActionResult Index()
        {
            return View(convertersService);
        }

        public decimal Convert(string unitFrom, string unitTo, string valueToConvert)
        {
            var fromConverter = this.scope.Resolve(Type.GetType(unitFrom)) as IUnitConverter;
            var toConverter = this.scope.Resolve(Type.GetType(unitTo)) as IUnitConverter;
            var fromValue = ParseDecimal(valueToConvert);
            var toValue = toConverter.ConvertFromSI(fromConverter.ConvertToSI(fromValue));

            StatisticDTO st = new StatisticDTO()
            {
                DateTime = DateTime.Now,
                UnitFrom = fromConverter.Unit,
                UnitTo = toConverter.Unit,
                Type = fromConverter.Type,
                RawValue = fromValue,
                ConvertedValue = toValue
            };
            this.statisticsRepository.AddStatistic(st);

            return toValue;
        }

        private decimal ParseDecimal(string value)
        {
            if(decimal.TryParse(value, out decimal result))
            {
                return result;
            }

            return 0m;
        }

        public ActionResult Statistics()
        {
            ViewBag.Message = "Usage statistics.";

            var data = statisticsRepository.GetStatistics();

            return View(data);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}