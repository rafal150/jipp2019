using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using applicationWpf;

namespace ConvLogicWeb.Controllers
{
    public class HomeController : Controller
    {
        private ConverterService convertersService;
        private ILifetimeScope scope;
        private IStatisticsRepository repo;

        public HomeController(ILifetimeScope scope, IStatisticsRepository statisticsRepository, ConverterService convertersService)
        {
            this.convertersService = convertersService;
            this.repo = statisticsRepository;
            this.scope = scope;
        }

        public ActionResult Index()
        {
            List<ConverterBase> converters = this.convertersService.GetConverters();

            return View(converters);
        }

        public decimal Convert(string unitFrom, string unitTo, string valueToConvert,
    string converterType)
        {
            ConverterBase converter = this.scope.Resolve(Type.GetType(converterType)) as ConverterBase;
            int from = Array.IndexOf(converter.indexes, unitFrom);
            int to = Array.IndexOf(converter.indexes, unitTo);
            if (string.IsNullOrWhiteSpace(valueToConvert))
                return decimal.Zero;
            double value = double.Parse(valueToConvert);
            decimal output = (decimal)converter.Convert(value,from, to );


            ConvSupply.pairData(converter.suffix, from, to, value, (double)output, converter.converterName);
            string resultString = ConvSupply.GetConvertedString();
            ConvSupply.AddDbEntry(repo);

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