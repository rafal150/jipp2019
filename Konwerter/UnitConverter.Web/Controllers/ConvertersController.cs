using Autofac;
using Konwerter.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

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

        public List<IConverter> GetConverters()
        {
            List<IConverter> converters = this.convertersService.GetConverters();

            return converters;
        }

        [Route("api/converters/convert")]
        [HttpGet]
        public double Liczenie(string z, string na, string wartDoKonwersji,
            string converterType)
        {
            //IConverter converter = this.scope.Resolve(Type.GetType(converterType)) as IConverter;
            
            converterType = HttpUtility.UrlDecode(converterType);
            IConverter converter = this.convertersService.GetConverters()
                .Where(c => c.Name == converterType).FirstOrDefault();

            double output = converter.Liczenie(z, na, double.Parse(wartDoKonwersji));

            return output;
        }
    }
}
