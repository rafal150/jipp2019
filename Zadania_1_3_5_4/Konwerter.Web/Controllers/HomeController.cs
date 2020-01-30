using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Konwerter;
using Konwerter.Services;

namespace Konwerter.Web.Controllers
{
    public class HomeController : Controller
    {
        private KonwerterServices convertersService;
        private ILifetimeScope scope;

        public HomeController(ILifetimeScope scope, KonwerterServices convertersService)
        {
            this.convertersService = convertersService;
            this.scope = scope;
        }

        public ActionResult Index()
        {
            List<IKonwerter> converters = this.convertersService.GetConverters();

            return View(converters);
        }

        public double Convert(string unitFrom, string unitTo, string valueToConvert,
            string converterType)
        {
            IKonwerter converter = this.scope.Resolve(Type.GetType(converterType)) as IKonwerter;

            double output = converter.Convert(unitFrom, unitTo, double.Parse(valueToConvert));

            using (Model db = new Model())
            {
                Kalkulator st = new Kalkulator()
                {
                    Wartosc = (double.Parse(valueToConvert)),
                    Przekonwertowane = (float)output,
                    JednostkaWyjsciowa = unitFrom,
                    JednostkaDocelowa = unitTo,
                    Data = DateTime.Now,
                    Rodzaj = converter.Name.ToString()
                };

                db.Kalkulator.Add(st);
                db.SaveChanges();
            }


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