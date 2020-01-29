using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UnitConverter;
using UnitConverter.Converters;
using System.Web.Mvc;
using UnitConverter.Statistics;

namespace UnitConverter.Web.Controllers
{



    public class HomeController : Controller
    {
        public Manager m;
        public HomeController()
        {
            m = new Manager();
        }

        public double Convert(string unitFrom, string unitTo, string valueToConvert, string converterType)
        {
                IConverter converter = m.GetConverter().GetConverter2(unitFrom);
                
                     double output = converter.Convert(unitFrom, unitTo, double.Parse(valueToConvert));
            StatisticDTO s = new StatisticDTO()
            {
                startValue = double.Parse(valueToConvert),
                finalValue = output,
                fromUnit = unitFrom,
                toUnit = unitTo,
                type = converter.Name,
                date = DateTime.Now
            };

            //zapis

            m.GetRepository().AddStatistic(s);
            return output;
        }
        public ActionResult Index()
        {
         
            
            List<IConverter> converters = m.GetConverter().converters;
            return View(converters);
        }

        public ActionResult About()
        {
         
            ViewBag.Message = "Your application description pag232e.";
            var item = m.GetRepository().GetStatistics();
            return View(item);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}