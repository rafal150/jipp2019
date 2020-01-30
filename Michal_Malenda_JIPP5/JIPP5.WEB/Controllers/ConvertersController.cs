using Autofac;
using JIPP5.SDK;
using JIPP5_LAB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace UnitConverter.Web.Controllers
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

        public List<IKonwerter> GetConverters()
        {
            return this.convertersService.GetConverters();
        }

        [System.Web.Http.Route("api/converters/convert")]
        [System.Web.Http.HttpGet]
        public decimal Convert(string unitFrom, string unitTo, string valueToConvert,
            string converterType)
        {
            //IConverter converter = this.scope.Resolve(Type.GetType(converterType)) as IConverter;
            IKonwerter converter = this.convertersService.GetConverters()
                .Where(c => c.Nazwa == converterType).FirstOrDefault();

            return converter.Converter(unitFrom, decimal.Parse(valueToConvert), unitTo);
        }
    }
}
