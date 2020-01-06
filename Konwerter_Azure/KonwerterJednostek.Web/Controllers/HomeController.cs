using Autofac;
using Konwerter_Azure;
using Konwerter_Azure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KonwerterJednostek.Web.Controllers
{
    public class HomeController : Controller
    {
        private ConvertersService convertersService;
        private ILifetimeScope scope;
        public HomeController(ILifetimeScope scope, ConvertersService convertersService)
        {
            this.scope = scope;
            this.convertersService = convertersService;
        }



        //private IEnumerable<StatisticDTO> statisticsRepository;// pobranie statystyk
        //public HomeController(IStatisticsRepository statisticsRepository, ConvertersService convertersService) 
        //{
        //    this.statisticsRepository = statisticsRepository.GetStatistics();
        //}



        public ActionResult Index()
        {
            IEnumerable<IConverter> converters = this.convertersService.GetConverters(); // pobranie konwerterow

            return View(converters); // przekazanie do widoku
        }

        //Akcja do obslugi konwersji - bo uzywam home/convert
        public decimal Przelicz( string jednostkiZ, string jednostkiNa, string wartosc, string typKonwertera)
        // public decimal Convert( string jednostkiZ, string jednostkiNa, string wartosc, string typKonwertera)
        {
            
            IConverter converter = this.scope.Resolve(Type.GetType(typKonwertera)) as IConverter;
            decimal wynik = converter.Przelicz(jednostkiZ, jednostkiNa, decimal.Parse(wartosc));

            return wynik;
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