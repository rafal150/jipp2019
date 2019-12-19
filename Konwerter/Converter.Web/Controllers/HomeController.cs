using Autofac;
using Konwerter;
using Konwerter.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Converter.SDK;

namespace Converter.Web.Controllers
{
    public class HomeController : Controller
    {
        private ConvertersService convertersService;
        private ILifetimeScope scope;
        private IStatisticsRepository repository;

        public HomeController(ILifetimeScope scope, IStatisticsRepository statisticRepository, ConvertersService convertersService)
        {
            this.convertersService = convertersService;
            this.scope = scope;
            this.repository = statisticRepository;
        }

        public ActionResult Index()
        {
            List<IConverter> converters = this.convertersService.GetConverters();
            return View(converters);
        }

        public double Convert(string fromUnit, string toUnit, string valueToConvert, string conversionType)
        {
            IConverter converter = this.scope.Resolve(Type.GetType(conversionType)) as IConverter;

            double output = converter.Convert(fromUnit, toUnit, double.Parse(valueToConvert));

            StatisticsDTO stats = new StatisticsDTO()
            {
                conversionType = converter.Name,
                fromUnit = fromUnit,
                toUnit = toUnit,
                valueToConvert = valueToConvert,
                convertedValue = output.ToString(),
                dateTime = DateTime.Now
            };

            repository.AddStatistics(stats);
            return output;
        }

        public ActionResult Stats()
        {
            var getStat = repository.GetStatistics();

            return View(getStat);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Hello it's me. I was wondering if after all these years you'd like to meet.";

            return View();
        }
    }
}