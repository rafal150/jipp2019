using Autofac;
using converter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ConverterWeb.Controllers
{
    public class ConvertersController : ApiController
    {
        private ConvertersService convertersService;        private ILifetimeScope scope;
        private ITelemetryRepository telemetryRepository;
        public ConvertersController(ILifetimeScope scope, ITelemetryRepository telemetryRepository, ConvertersService convertersService)        {            this.convertersService = convertersService;            this.scope = scope;            this.telemetryRepository = telemetryRepository;
        }
        public List<IConverter> GetConverters()        {            List<IConverter> converters = this.convertersService.GetConverters();
            return converters;        }

        [Route("api/converters/telemetry")]        [HttpGet]
        public List<TelemetryDTO> Telemetry()        {            return telemetryRepository.GetTelemetries().ToList();        }
        [Route("api/converters/convert")]        [HttpGet]        public double Convert(string unitFrom, string unitTo, string valueToConvert, string converterType)        {            IConverter converter = this.convertersService.GetConverters()                .Where(c => c.Name == converterType).FirstOrDefault();
            double output = converter.Convert(unitFrom, unitTo, double.Parse(valueToConvert));

            telemetryRepository.AddTelemetry(new TelemetryDTO()
            {
                Date = DateTime.Now,
                Type = converter.Name,
                UnitFrom = unitFrom,
                UnitTo = unitTo,
                ValueFrom = double.Parse(valueToConvert),
                ValueTo = output
            });

            return output;
        }
    }
}