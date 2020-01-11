using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unitconverter;
using Unitconverter.Services;

namespace UnitConverter.Web.Controllers
{
    public class HomeController : Controller
    {
        private ConvServices converterServices;
        private IStatisticsRepository repository;
        private ILifetimeScope scope;
        public HomeController(ILifetimeScope scope, Unitconverter.IStatisticsRepository repo, ConvServices convserv)
        {
            this.scope = scope;
            converterServices = convserv;
            this.repository = repo;

        }
        public ActionResult Index()
        {
            IEnumerable<IConverter> converters = this.converterServices.GetConverters();

            return View(converters);
        }

        public double Convert(string unitfrom, string unitTo, string valuetoconvert, string converterType)
        {
            IConverter converter = this.scope.Resolve(Type.GetType(converterType)) as IConverter;
            double wynik = converter.Convert(unitfrom, unitTo, double.Parse(valuetoconvert));
            /*
            StatDTO units = new StatDTO()
            {
                DateTime = DateTime.Now,
                Type = converterType,
                FromUnit = unitfrom,
                ToUnit = unitTo,
                RawValue = int.Parse(valuetoconvert),
                ConvertedValue = (int)wynik
            };


            StatisticsSQLRepo baza = new StatisticsSQLRepo();
            repository.AddStatistic(units);
            */
            return wynik;
        }
        public ActionResult About()
        {
            StatisticsSQLRepo baza = new StatisticsSQLRepo();
            IEnumerable<StatDTO> list;
            list = baza.GetStatistics(); return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}