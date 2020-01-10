using JIPP5_LAB.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Unity;

namespace JIPP5_LAB.WebApp.Controllers
{
    public class ConvertersController : ApiController
    {
        private readonly IUnityContainer container;

        public ConvertersController(IUnityContainer unityContainer)
        {
            container = unityContainer;
        }

        [Route("api/converters/convert")]
        [HttpGet]
        public decimal Convert(string unitFrom, string valueToConvert, string unitTo,
            string converterType)
        {
            IConverterHelper converter = container.Resolve<IConverterHelper>(converterType);

            converter.Convert(unitFrom, decimal.Parse(valueToConvert), unitTo, out decimal convertedVal);

            return convertedVal;
        }
    }
}