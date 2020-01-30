using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnitCoverterPart2;
using UnitCoverterPart2.Services;

namespace AdamWebKonwerter.Controllers
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
            List<IConverter> converters = this.convertersService.GetConverters();

            return View(converters);
        }

        public double Convert(string unitFrom, string unitTo, string valueToConvert,
            string converterType)
        {
            IConverter converter = this.scope.Resolve(Type.GetType(converterType)) as IConverter;

            //double output = converter.Convert(unitFrom, unitTo, double.Parse(valueToConvert));
            double _input = 0.0;


            bool input_res = Double.TryParse(valueToConvert, out _input);
            double? input= (input_res) ? _input : (double?)null;
            double? output = (input_res) ? converter.Convert(unitFrom, unitTo, double.Parse(valueToConvert)) : (double?)null;

            var stats_repo = scope.Resolve<IStatisticsRepository>();

            stats_repo.AddStatistic(new StatisticDTO()
            {
                ConvertedValue = output,
                DateTime = DateTime.Now,
                RawValue = input,
                Type = converter.Name,
                UnitFrom = unitFrom,
                UnitTo = unitTo,
                id = new Random().Next()
            });
            

            return (output.HasValue) ? output.Value : double.NaN;
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