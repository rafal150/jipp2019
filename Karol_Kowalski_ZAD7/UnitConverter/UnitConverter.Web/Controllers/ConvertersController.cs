using Autofac;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Http;
using UnitConverter.Logic;
using UnitConverter.Logic.UnitConverters;

namespace UnitConverter.Web.Controllers
{
    public class ConvertersController : ApiController
    {
        private ConvertersService convertersService;
        private ILifetimeScope scope;
        private IHistoryRepository historyRepository;
        private IStatisticsRepository statisticsRepository;

        public ConvertersController(
            ILifetimeScope scope,
            IHistoryRepository historyRepository,
            IStatisticsRepository statisticsRepository,
            ConvertersService convertersService)
        {
            this.convertersService = convertersService;
            this.scope = scope;
            this.historyRepository = historyRepository;
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
                .Where(c => c.Type == HttpUtility.UrlDecode(converterType))
                .FirstOrDefault();

            var fromConverter = converter.GetUnitConverterForUnit(HttpUtility.UrlDecode(unitFrom));
            var toConverter = converter.GetUnitConverterForUnit(HttpUtility.UrlDecode(unitTo));
            var fromValue = ParseDecimal(HttpUtility.UrlDecode(valueToConvert));
            var toValue = toConverter.ConvertFromSI(fromConverter.ConvertToSI(fromValue));

            HistoryDTO entry = new HistoryDTO()
            {
                DateTime = DateTime.Now,
                UnitFrom = fromConverter.Unit,
                UnitTo = toConverter.Unit,
                ConversionType = fromConverter.Type,
                ValueToConvert = fromValue,
                ConvertedValue = toValue
            };
            this.historyRepository.AddConversionItem(entry);
            this.statisticsRepository.AddStatistic(entry.ToStatisticDTO());

            return toValue;
        }

        [Route("api/converters/statistics")]
        [HttpGet]
        public IEnumerable<StatisticDTO> Statistics()
        {
            return statisticsRepository.GetStatistics();
        }

        [Route("api/converters/history")]
        [HttpGet]
        public IEnumerable<HistoryDTO> History()
        {
            return historyRepository.GetLastConversions();
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
