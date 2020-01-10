using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UnitConverteAZ;
using UnitConverteAZ.Services;

namespace UnitConverter.Web.Controllers
{
    public class ConvertersController : ApiController
    {
        private ConverterService convertersService;
        private ILifetimeScope scope;
        private StatisticStorageAzureRepository statsql;

        public ConvertersController(ILifetimeScope scope, ConverterService convertersService)
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
        public double Convert(string unitFrom, string unitTo, string valueToConvert,
            string converterType)
        {
            //IConverter converter = this.scope.Resolve(Type.GetType(converterType)) as IConverter;
            IConverter converter = this.convertersService.GetConverters()
                .Where(c => c.Name == converterType).FirstOrDefault();

            double output = converter.Convert(unitFrom, unitTo, double.Parse(valueToConvert));

            return output;
        }



    }
}
