using Autofac;
using System;
using System.Collections.Generic;
using System.Globalization;
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
        private IHistoryRepository historyRepository;
        private IStatisticsRepository statisticsRepository;

        public HomeController(
            ILifetimeScope scope,
            IHistoryRepository historyRepository,
            IStatisticsRepository statisticsRepository,
            ConvertersService convertersService)
        {
            this.convertersService = convertersService;
            this.scope = scope;
            this.historyRepository = historyRepository;
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

            HistoryDTO entry = new HistoryDTO()
            {
                DateTime = DateTime.Now,
                UnitFrom = fromConverter.Unit,
                UnitTo = toConverter.Unit,
                ConversionType = fromConverter.Type,
                ValueToConvert = fromValue,
                ConvertedValue = toValue
            };
            this.historyRepository.AddConversionItem(entry);
            this.statisticsRepository.AddStatistic(entry.ToStatisticDTO());

            return toValue;
        }

        private decimal ParseDecimal(string value)
        {
            if (decimal.TryParse(value, NumberStyles.Float, CultureInfo.InvariantCulture, out decimal result))
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

        public ActionResult History()
        {
            ViewBag.Message = "Last conversions.";

            var data = historyRepository.GetLastConversions();

            return View(data);
        }
    }
}