using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Mvc;
using Unitconverter.Services;

namespace UnitConverter.Web.Controllers
{

    public class ConvertersController : ApiController
    {

        private ConvServices converterServices;
        private ILifetimeScope scope;

        public ConvertersController(ILifetimeScope scope, Unitconverter.IStatisticsRepository repo, ConvServices convserv)
        {
            this.scope = scope;
            converterServices = convserv;
        }
        public List<IConverter> GetConverters()
        {
            List<IConverter> converters = this.converterServices.GetConverters();

            return converters;
        }

        [System.Web.Http.Route("api/Converters/convert")]
        [System.Web.Http.HttpGet]
        public double Convert(string unitfrom, string unitTo, string valuetoconvert, string converterType)
        {
            IConverter converter = this.scope.Resolve(Type.GetType(converterType)) as IConverter;
            //IConverter converter = this.converterServices.GetConverters().Where(c => c.Name == converterType).FirstOrDefault(); // this.scope.Resolve(Type.GetType(converterType)) as IConverter;
            double wynik = converter.Convert(unitfrom, unitTo, double.Parse(valuetoconvert));
            return wynik;
        }
    }
}
