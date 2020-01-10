using Autofac;
using ConverterSDK;
using Logic.Commons;
using Logic.Convert;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;

namespace WWW.Controllers
{
    public class ConvertersController : ApiController
    {
        private ConverterService convertersService;
        private ILifetimeScope scope;
        List<ConverterInterface> converters;

        public ConvertersController(ILifetimeScope scope, ConverterService convertersService)
        {
            this.convertersService = convertersService;
            this.scope = scope;
        }

        public List<ConverterInterface> GetConverters()
        {
            this.converters = this.convertersService.GetConverters();

            return converters;
        }

        [Route("api/converters/convert")]
        [HttpGet]
        public decimal Convert(string unitFrom, string unitTo, string valueToConvert,
            string converterType)
        {
            Type type = null;
            foreach (ConverterInterface obj in GetConverters())
            {
                if (obj.GetType().Name == converterType)
                {
                    type = obj.GetType();
                    break;
                }
            }
            var varClasses = from t in Assembly.GetExecutingAssembly().GetTypes()
                             where t.IsClass
                             select t;
            List<Type> lstClasses = varClasses.ToList();
            Object classInstance = type.GetConstructor(new Type[] { }).Invoke(new object[] { });

            double convertFromValue = Double.Parse(valueToConvert.Replace(".", ","));
            decimal convertedValue;
            Type classType = classInstance.GetType();
            PropertyInfo set = classType.GetProperty(unitFrom);
            PropertyInfo get = classType.GetProperty(unitTo);
            if (set == null || get == null)
            {
                throw new MethodAccessException();
            }
            set.SetValue(classInstance, convertFromValue);
            convertedValue = Decimal.Parse(get.GetValue(classInstance).ToString());
            //DbLog(convertFromValue, fromUnit, toUnit, convertedValue);
            return convertedValue;
        }
    }
}
