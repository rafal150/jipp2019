using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autofac;
using WpfApp1.SDK;
using WpfApp1.Logic;


namespace WpfApp1.Web.Controllers
{
    public class HomeController : Controller
    {
        private GetMeasuresObj convertersService;
        private ILifetimeScope scope;
        private IStatisticsSource repository;
        public HomeController(ILifetimeScope scope, IStatisticsSource statisticsRepository, GetMeasuresObj convertersService)
        {
            this.convertersService = convertersService;
            this.scope = scope;
        }
        public ActionResult Index()
        {
            List<IGetMeasures> converters = this.convertersService.GetMesasures();
            return View(converters);
        }
        public double Convert(string unitFrom, string unitTo, string valueToConvert,
            string converterType)
        {
            IGetMeasures converter = this.scope.Resolve(Type.GetType(converterType)) as IGetMeasures;

            double output = converter.Convert(unitFrom, unitTo, double.Parse(valueToConvert));

            return output;
        }

        private void LoadStatistics(IStatisticsSource r)
        {
            IEnumerable<StatisticsDTO> data_from_ = r.GetStatistics();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description pagea.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}