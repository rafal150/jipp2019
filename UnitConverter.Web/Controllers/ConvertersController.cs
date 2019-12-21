using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UnitsConverter;
using UnitsConverter.Services;

namespace UnitConverter.Web.Controllers
{
    public class ConvertersController : ApiController
    {
        private ConverterService convertersService;
        private ILifetimeScope scope;

        public ConvertersController(ILifetimeScope scope, IStatisticsRepository statisticsRepository, ConverterService convertersService)
        {
            this.convertersService = convertersService;
            this.scope = scope;
        }
        public List<IConverter> GetConverters()
        {

            List<IConverter> converters = this.convertersService.GetConverters();

            return converters;
        }
        [Route ("Api/Converters/convert")]
        [HttpGet]
        public decimal Convert(string unitFrom, string unitTo, string valueToConvert,
         string converterType)
        {
            IConverter converter = this.convertersService.GetConverters().Where(c=>c.Name==converterType).First();

            decimal output = converter.Convert(unitFrom, unitTo, decimal.Parse(valueToConvert));

            return output;
        }
    }
}
