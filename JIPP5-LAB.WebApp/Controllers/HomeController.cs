using JIPP5_LAB.Interfaces;
using JIPP5_LAB.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity;

namespace JIPP5_LAB.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private IDataHelper repo;
        private IUnityContainer unityContainer;
        public HomeController(IDataHelper statisticsRepository, IUnityContainer unityContainer)
        {
            this.unityContainer = unityContainer;
            this.repo = statisticsRepository;
        }

        public ActionResult Index()
        {
            var converters = this.unityContainer.ResolveAll<IConverterHelper>();

            return View(converters);
        }

        public decimal Convert(string unitFrom, string unitTo, string valueToConvert, string converterType)
        {
            IConverterHelper converter = this.unityContainer.Resolve(Type.GetType(converterType)) as IConverterHelper;
            var value = decimal.Parse(valueToConvert);
            string output = converter.Convert(unitFrom, value, unitTo, out decimal convertedValue);
            repo.AddRecord(new StatisticsDTO()
            {
                Converted = convertedValue,
                Date = DateTime.Now,
                RawData= value,
                FromUnit = unitFrom,
                ToUnit = unitTo
            });
            return convertedValue;
        }

        public ActionResult About()
        {
            var statiscits = repo.GetRecords();
            return View(statiscits);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}