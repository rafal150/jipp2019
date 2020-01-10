using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebKonwerter;
using KonwerterApp;
using KonwerterApp.Services;
using Newtonsoft.Json;

namespace WebKonwerter.Controllers
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

        public List<IConverter> GetConverters()
        {
            List<IConverter> converters = this.convertersService.GetConverters();

            return converters;
        }

        [Route("api/konwerter/convert")]
        [HttpGet]
        public float Convert(string unitFrom, string unitTo, string valueToConvert,
            string converterType)
        {
            //IConverter converter = this.scope.Resolve(Type.GetType(converterType)) as IConverter;
            IConverter converter = this.convertersService.GetConverters()
                .Where(c => c.Nazwa == converterType).FirstOrDefault();

            float wartosc = (float)System.Convert.ToDouble(valueToConvert);

            float output = converter.Konwertuj(unitFrom, unitTo, wartosc);

            return output;
        }
    }
}
