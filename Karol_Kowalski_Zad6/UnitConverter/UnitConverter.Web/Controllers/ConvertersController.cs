using Autofac;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Http;
using UnitConverter.Logic;
using UnitConverter.Logic.UnitConverters;

namespace UnitConverter.Web.Controllers
{
    public class ConvertersController : ApiController
    {
        private ConvertersService convertersService;
        private ILifetimeScope scope;
        private IStatisticsRepository statisticsRepository;

        public ConvertersController(ILifetimeScope scope, IStatisticsRepository statisticsRepository, ConvertersService convertersService)
        {
            this.convertersService = convertersService;
            this.scope = scope;
            this.statisticsRepository = statisticsRepository;
        }

        public List<Converter> GetConverters()
        {
            return convertersService.GetConverters();
        }

        [Route("api/converters/convert")]
        [HttpGet]
        public decimal Convert(string unitFrom, string unitTo, string valueToConvert, string converterType)
        {
            var converters = this.convertersService.GetConverters();
            var converter = this.convertersService.GetConverters()
                .Where(c => c.Type == converterType)
                .FirstOrDefault();

            var fromConverter = converter.GetUnitConverterForUnit(unitFrom);
            var toConverter = converter.GetUnitConverterForUnit(unitTo);
            var fromValue = ParseDecimal(valueToConvert);
            var toValue = toConverter.ConvertFromSI(fromConverter.ConvertToSI(fromValue));

            StatisticDTO st = new StatisticDTO()
            {
                DateTime = DateTime.Now,
                UnitFrom = fromConverter.Unit,
                UnitTo = toConverter.Unit,
                Type = fromConverter.Type,
                RawValue = fromValue,
                ConvertedValue = toValue
            };
            this.statisticsRepository.AddStatistic(st);

            return toValue;
        }

        [Route("api/converters/statistics")]
        [HttpGet]
        public IEnumerable<StatisticDTO> Statistics()
        {
            return statisticsRepository.GetStatistics();
        }

        private decimal ParseDecimal(string value)
        {
            if (decimal.TryParse(value, NumberStyles.Float, CultureInfo.InvariantCulture, out decimal result))
            {
                return result;
            }

            return 0m;
        }
    }
}
