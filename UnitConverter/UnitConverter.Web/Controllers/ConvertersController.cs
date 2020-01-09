﻿using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Web.Http;

namespace UnitConversion.Web.Controllers
{
    public class ConvertersController : ApiController
    {
        private ConverterService converterService;
        private IServiceRepository serviceRepository;

        public ConvertersController(ConverterService service, IServiceRepository repository)
        {
            converterService = service;
            serviceRepository = repository;
        }

        [Route("api/converters")]
        [HttpGet]
        public List<UnitConverter> GetConverters()
        {
            List<UnitConverter> converters = this.converterService.GetConverters();
            return converters;
        }


        [Route("api/converters/userconverters")]
        [HttpGet]
        public List<ConverterDTO> GetUserConverters()
        {
            return serviceRepository.GetConverters().ToList();
        }

        [Route("api/converters/convert")]
        [HttpGet]
        public decimal Convert(string unitFrom, string unitTo, string valueToConvert,
            string converterType)
        {
            ValidateConvertData(unitFrom, unitTo, valueToConvert, converterType);

            UnitConverter converter = converterService.UnitConverters[converterType];
            decimal valueToConvertDecimal = decimal.Parse(valueToConvert.Replace(',', '.'), CultureInfo.InvariantCulture);

            decimal output = 0;
            converterService.Convert(converterType, unitFrom, unitTo, valueToConvertDecimal, out output);
            return output; 
        }

        [Route("api/converters/saveconverter")]
        [HttpGet]
        public bool SaveConverter(string converterType, string Name)
        {
            serviceRepository.SaveConverter(converterType, Name);
            return true;
        }

        [Route("api/converters/deleteconverter")]
        [HttpGet]
        public bool DeleteConverter(string converterType)
        {
            serviceRepository.DeleteConverter(converterType);
            return true;
        }

        [Route("api/converters/saveconverterunit")]
        [HttpGet]
        public bool SaveConverterUnit(string converterType, string ConverterUnitName, string Name, string ConversionToBaseValueFormula, string ConversionFromBaseValueFormula)
        {
            serviceRepository.SaveConverterUnit(converterType, ConverterUnitName, Name, ConversionToBaseValueFormula, ConversionFromBaseValueFormula);
            return true;
        }

        [Route("api/converters/deleteconverterunit")]
        [HttpGet]
        public bool DeleteConverterUnit(string converterType, string unitName)
        {
            serviceRepository.DeleteConverterUnit(converterType, unitName);
            return true;
        }


        private void ValidateConvertData(string unitFrom, string unitTo, string valueToConvert,
            string converterType)
        {
            if (converterService.UnitConverters.ContainsKey(converterType) == false)
            {
                throw GetResponseException(System.Net.HttpStatusCode.BadRequest, "No unit converter found: " + converterType, "Unit converter not founded");
            }
            decimal valueToConvertDecimal = 0;

            if (decimal.TryParse(valueToConvert.Replace(',','.'), NumberStyles.Any, CultureInfo.InvariantCulture, out valueToConvertDecimal) == false)
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
