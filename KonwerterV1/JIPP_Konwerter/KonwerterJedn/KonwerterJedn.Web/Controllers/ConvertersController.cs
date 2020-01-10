using Autofac;
using KonwerterJedn.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace KonwerterJedn.Web.Controllers
{
    public class ConvertersController : ApiController
    {

        private KonwerterJednostek konwerterJednostek;
        private ILifetimeScope scope;

        public ConvertersController(ILifetimeScope scope, KonwerterJednostek konwerterJednostek)
        {
            this.konwerterJednostek = konwerterJednostek;
            this.scope = scope;

        }

        public List<IConverter> GeConverters()
        {
            List<IConverter> konwertery = this.konwerterJednostek.GetConverters();

            return konwertery;
        }

        [Route("api/converters/convert")]
        [HttpGet]
        public double Convert(string unitFrom, string unitTo, string valueFrom, string converterType)
        {
            //IConverter converter = this.scope.Resolve(Type.GetType(converterType)) as IConverter;
            IConverter converter = this.konwerterJednostek.GetConverters()
                .Where(c => c.Nazwa == converterType).FirstOrDefault();

            double output = converter.Convert(unitFrom, unitTo, double.Parse(valueFrom));

            return output;
        }
    }
}
