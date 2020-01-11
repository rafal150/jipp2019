using Autofac;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Konwerter;
using Konwerter.Services;

namespace Konwerter.Web.Controllers
{
    public class HomeController : Controller
    {
        private ConvertersService convertersService;
        private ILifetimeScope scope;
        private IStatisticRepository repository;

        public HomeController(ILifetimeScope scope, IStatisticRepository repository, ConvertersService convertersService)
        {
            this.convertersService = convertersService;
            this.scope = scope;
            this.repository = repository;
        }

        public ActionResult Index()
        {
            List<IConverting> converters = this.convertersService.GetConverters();

            return View(converters);
        }

        public double Convert(string unitFrom, string unitTo, string valueToConvert, string converterType, string comment)
        {
            IConverting converter = this.scope.Resolve(Type.GetType(converterType)) as IConverting;
            double amount = double.Parse(valueToConvert);

            double output = converter.Convert(unitFrom, unitTo, amount);

            StatisticDTO statystyki = new StatisticDTO
            {
                UnitFrom = unitFrom,
                UnitTo = unitTo,
                DateTime = DateTime.Now,
                Type = converter.Nazwa,
                ValueFrom = amount,
                ValueTo = output,
                Comment = comment
            };
            repository.AddStatistic(statystyki);

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