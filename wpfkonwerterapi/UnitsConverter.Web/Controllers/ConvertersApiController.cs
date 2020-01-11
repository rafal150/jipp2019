using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WPFKonwerter.Services;

namespace UnitsConverter.Web.Controllers
{
    public class ConvertersApiController : ApiController
    {
        // GET: ConvertersApi
        private KonwerterService konwerterSrv;
        private ILifetimeScope scope;
        public ConvertersApiController(ILifetimeScope scp, KonwerterService konwerterService)
        {
            scope = scp;
            konwerterSrv = konwerterService;
        }
        public List<ConverterSDK.IConvertible> GetConverters() => konwerterSrv.GetConverters();
      
        [Route("api/convertersApi/convert")]
        [HttpGet]
        public decimal Convert(string unitFrom, string unitTo, string valueFrom,
            string converterType)
        {
            ConverterSDK.IConvertible converter = this.konwerterSrv.GetConverters()
                .Where(c => c.ConverterName == converterType).FirstOrDefault();

            return decimal.Parse(converter.Convert(unitFrom, unitTo, double.Parse(valueFrom)));
                

        }
    }
}