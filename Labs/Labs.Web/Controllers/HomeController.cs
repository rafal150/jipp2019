using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Labs.Converters;
using Labs.Databases;
using Autofac;

namespace Labs.Web.Controllers
{
    public class HomeController : Controller
    {
        private SConverters sconverters;
        private ILifetimeScope scope;
        private InterfaceRepository repo;
        public HomeController(ILifetimeScope scope, InterfaceRepository interfaceRepository, SConverters sconverters)
        {
            this.sconverters = sconverters;
            this.scope = scope;
            this.repo = interfaceRepository;
        }

        public decimal Convert(string unitFrom, string unitTo, string valueToConvert, string converterType)
        {
            IConverter converter = this.scope.Resolve(Type.GetType(converterType)) as IConverter;

            double result = converter.Convert(unitFrom, unitTo, System.Convert.ToDouble(valueToConvert));

            Values values = new Values()
            {
                DateTime = DateTime.Now,
                category = "WebApp",
                from = unitFrom,
                to = unitTo,
                initial = System.Convert.ToDouble(valueToConvert),
                converted = result
            };

            this.repo.AddCalcs(values);

            return System.Convert.ToDecimal(result);
        }

        public ActionResult Index()
        {
            IEnumerable<IConverter> converters = this.sconverters.GetConverters();


            return View(converters);
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