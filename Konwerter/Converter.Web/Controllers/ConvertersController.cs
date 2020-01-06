using Autofac;
using Converter.SDK;
using Konwerter;
using Konwerter.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Converter.Web.Controllers
{
    public class ConvertersController : ApiController
    {
        private ConvertersService convertersService;
        private IStatisticsRepository statisticsRepository;
        private ILifetimeScope scope;

        public ConvertersController(ILifetimeScope scope, ConvertersService convertersService, IStatisticsRepository statisticsRepository)
        {
            this.convertersService = convertersService;
            this.statisticsRepository = statisticsRepository;
            this.scope = scope;
        }

        public List<IConverter> GetConverters()
        {
            List<IConverter> converters = this.convertersService.GetConverters();

            return converters;
        }

        [Route("api/converters/convert")]
        [HttpGet]
        public double Convert(string fromUnit, string toUnit, string valueToConvert,
            string conversionType)
        {
            //IConverter converter = this.scope.Resolve(Type.GetType(converterType)) as IConverter;
            IConverter converter = this.convertersService.GetConverters()
                .Where(c => c.Name == conversionType).FirstOrDefault();

            double output = converter.Convert(fromUnit, toUnit, double.Parse(valueToConvert));

            StatisticsDTO stats = new StatisticsDTO()
            {
                conversionType = converter.Name,
                fromUnit = fromUnit,
                toUnit = toUnit,
                valueToConvert = valueToConvert,
                convertedValue = output.ToString(),
                dateTime = DateTime.Now
            };

            statisticsRepository.AddStatistics(stats);

            return output;
        }

        [Route("api/converters/stats")]
        [HttpGet]
        public List<StatisticsDTO> Statistics()
        {
            return statisticsRepository.GetStatistics().ToList();
        }
    }
}