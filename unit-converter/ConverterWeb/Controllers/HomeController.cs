using Autofac;
using converter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConverterWeb.Controllers
{
    public class HomeController : Controller
    {
        private ConvertersService convertersService;
        private ILifetimeScope scope;
        private ITelemetryRepository telemetryRepository;

        public HomeController(ILifetimeScope scope, ITelemetryRepository telemetryRepository, ConvertersService convertersService)
        {
            this.convertersService = convertersService;
            this.scope = scope;
            this.telemetryRepository = telemetryRepository;
        }

        public ActionResult Index()
        {
            var converters = convertersService.GetConverters();

            return View(converters);
        }

        public ActionResult History()
        {
            var history = telemetryRepository.GetTelemetries();

            return View(history);
        }

        public double Convert(string unitFrom, string unitTo, string valueToConvert, string converterType)
        {
            //try
            {
                var converter = scope.Resolve(Type.GetType(converterType)) as IConverter;
                var from = double.Parse(valueToConvert);
                var output = converter.Convert(unitFrom, unitTo, from);

                telemetryRepository.AddTelemetry(new TelemetryDTO()
                {
                    Date = DateTime.Now,
                    Type = converter.Name,
                    UnitFrom = unitFrom,
                    UnitTo = unitTo,
                    ValueFrom = from,
                    ValueTo = output
                });

                return output;
            }
            /* catch
            {
                return double.NaN;
            }*/
        }
    }
}