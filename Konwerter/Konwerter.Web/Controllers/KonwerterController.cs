using Autofac;
using Konwerter.SDK;
using Konwerter.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Konwerter.Web.Controllers
{
    public class KonwerterController : ApiController
    {
        private ConvertersService convertersService;
        private ILifetimeScope scope;

        public KonwerterController(ILifetimeScope scope, ConvertersService convertersService)
        {
            this.convertersService = convertersService;
            this.scope = scope;
        }

        public List<IKonwerter> GetConverters()
        {
            List<IKonwerter> konwertery = this.convertersService.GetConverters();

            return konwertery;
        }

        [Route("api/konwerter/przelicz")]
        [HttpGet]
        public double Przelicz(string unitFrom, string unitTo, string valueToConvert, string converterType)
        {
            //IConverter converter = this.scope.Resolve(Type.GetType(converterType)) as IConverter;
            IKonwerter konwerter = this.convertersService.GetConverters()
                .Where(c => c.Typ == converterType).FirstOrDefault();

            double output = konwerter.Przelicz(unitFrom, unitTo, double.Parse(valueToConvert));

            return output;
        }
    }
}