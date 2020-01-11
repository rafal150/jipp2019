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
        //private IStatisticsSource repositoryService;
        public HomeController(ILifetimeScope scope, IStatisticsSource repositoryService, GetMeasuresObj convertersService)
        {
            this.convertersService = convertersService;
            //this.repositoryService = repositoryService;
            this.scope = scope;
        }
        public ActionResult Index() //tak samo dla statystyk
        {   // lista miar
            List<IGetMeasures> converters = this.convertersService.GetMesasures();
            return View(converters);
        }

        public double Convert(string unitFrom, string unitTo, string valueToConvert, //submit łaczy się z tym
            string converterType)
        {
            //pobieram dane z widoku
            IGetMeasures converter = this.scope.Resolve(Type.GetType(converterType)) as IGetMeasures;

            double output = converter.Convert(unitFrom, unitTo, double.Parse(valueToConvert));

            // przekazuje dane do widoku rezultat
            return output;
        }



        /*private ActionResult Statistics()
        {
            IEnumerable<StatisticsDTO> statistics = this.repositoryService.GetStatistics();
            return View(statistics);
        }*/

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