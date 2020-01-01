using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Autofac;
using Konwerter.Services;

namespace Konwerter.Web.Controllers
{
    public class ConvertersController : ApiController
    {
        private ConvertersService convertersService;
        private ILifetimeScope scope;

        public ConvertersController(ILifetimeScope scope, ConvertersService convertersService)
        {
            this.convertersService = convertersService;
            this.scope = scope;
        }

        public List<IConverting> GetConverters()
        {
            List<IConverting> converters = this.convertersService.GetConverters();

            return converters;
        }

        [Route("api/converters/convert")]
        [HttpGet]
        public double Convert(string unitFrom, string unitTo, string valueToConvert,
            string converterType)
        {
            IConverting converter = this.convertersService.GetConverters()
                .Where(c => c.Nazwa == converterType).FirstOrDefault();

            double output = converter.Convert(unitFrom, unitTo, double.Parse(valueToConvert));

            return output;
        }
    }
}
