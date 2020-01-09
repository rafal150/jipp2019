using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Autofac;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Labs.Converters;

namespace Labs.Web.Controllers
{
    public class ConvertersController : ApiController
    {
        private SConverters convertersService;
        private ILifetimeScope scope;
        private InterfaceRepository statisticsRepository;

        public ConvertersController(ILifetimeScope scope, SConverters convertersService, InterfaceRepository statisticsRepository)
        {
            this.convertersService = convertersService;
            this.scope = scope;
            this.statisticsRepository = statisticsRepository;
        }

        public List<IConverter> GetConverters()
        {
            List<IConverter> converters = this.convertersService.GetConverters();

            return converters;
        }

        [Route("api/converters/convert")]
        [HttpGet]

        public decimal Convert(string unitFrom, string unitTo, string valueToConvert, string converterType)
        {
            IConverter converter = this.convertersService.GetConverters()
                .Where(c => c.Name == converterType).FirstOrDefault();

            double result = converter.Convert(unitFrom, unitTo, System.Convert.ToDouble(valueToConvert));

            return System.Convert.ToDecimal(result);
        }


        [Route("api/converters/stats")]
        [HttpGet]
        public List<Values> Statstics()
        {
            return statisticsRepository.GetValues().ToList();
        }
    }
}