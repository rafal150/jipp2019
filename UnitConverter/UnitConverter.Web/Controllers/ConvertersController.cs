using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;

namespace UnitConversion.Web.Controllers
{
    public class ConvertersController : ApiController
    {
        private ConverterService converterService;

        public ConvertersController(ConverterService service)
        {
            converterService = service;
        }

        public List<UnitConverter> GetConverters()
        {
            List<UnitConverter> converters = this.converterService.GetConverters();
            return converters;
        }

        [Route("api/converters/convert")]
        [HttpGet]
        public decimal Convert(string unitFrom, string unitTo, string valueToConvert,
    string converterType)
        {
            ValidateConvertData(unitFrom, unitTo, valueToConvert, converterType);

            UnitConverter converter = converterService.UnitConverters[converterType];
            decimal valueToConvertDecimal = decimal.Parse(valueToConvert);

            decimal output = 0;
            converterService.Convert(converterType, unitFrom, unitTo, valueToConvertDecimal, out output);
            return output; 
        }

        private void ValidateConvertData(string unitFrom, string unitTo, string valueToConvert,
    string converterType)
        {
            if (converterService.UnitConverters.ContainsKey(converterType) == false)
            {
                throw GetResponseException(System.Net.HttpStatusCode.BadRequest, "No unit converter found: " + converterType, "Unit converter not founded");
            }
            decimal valueToConvertDecimal = 0;

            if (decimal.TryParse(valueToConvert, out valueToConvertDecimal) == false)
            {
                throw GetResponseException(System.Net.HttpStatusCode.BadRequest, "Invalid value to convert. Value: " + valueToConvert, "Invalid value");
            }
            if (converterService.UnitConverters[converterType].Units.Contains(unitFrom) == false)
            {
                throw GetResponseException(System.Net.HttpStatusCode.BadRequest, "No unit found in converter: Unit: " + unitFrom + " Converter: " + converterType, "Invalid unit from");
            }
            if (converterService.UnitConverters[converterType].Units.Contains(unitTo) == false)
            {
                throw GetResponseException(System.Net.HttpStatusCode.BadRequest, "No unit found in converter: Unit: " + unitTo + " Converter: " + converterType, "Invalid unit to");
            }
        }

        private HttpResponseException GetResponseException(System.Net.HttpStatusCode statusCode, string content, string reasonPhrase)
        {
            return new HttpResponseException(GetResponseMessage(statusCode, content, reasonPhrase));
        }

        private HttpResponseMessage GetResponseMessage(System.Net.HttpStatusCode statusCode, string content, string reasonPhrase)
        {
            return new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest)
            {
                Content = new StringContent(content),
                ReasonPhrase = reasonPhrase
            };
        }
    }
}
