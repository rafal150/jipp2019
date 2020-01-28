using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UnitCoverterPart2;
using UnitCoverterPart2.Services;

namespace UnitConverter.Web.Controllers
{
    public class ConvertersController : ApiController
    {
        private ConvertersService convertersService;
        private ILifetimeScope scope;
        private IStatisticsRepository repo;

        public ConvertersController(ILifetimeScope scope, ConvertersService convertersService, IStatisticsRepository statisticsRepository)
        {
            this.convertersService = convertersService;
            this.scope = scope;
            this.repo = statisticsRepository;
        }

        public List<IConverter> GetConverters()
        {
            List<IConverter> converters = this.convertersService.GetConverters();

            return converters;
        }

        [Route("api/converters/convert")]
        [HttpGet]
        public decimal Convert(string unitFrom, string unitTo, string valueToConvert,
            string converterType)
        {
            //IConverter converter = this.scope.Resolve(Type.GetType(converterType)) as IConverter;
            IConverter converter = this.convertersService.GetConverters()
                .Where(c => c.Name == converterType).FirstOrDefault();

            valueToConvert = valueToConvert.Replace(".", ",");
            decimal value;
            try
            {
                value = decimal.Parse(valueToConvert);
            }
            catch (FormatException e)
            {
                value = 0;
            }
            decimal output = converter.Convert(unitFrom, unitTo, value);

            StatisticDTO rekord = new StatisticDTO();
            rekord.DateTime = DateTime.Now;
            rekord.Type = converterType;
            rekord.UnitFrom = unitFrom;
            rekord.UnitTo = unitTo;
            rekord.RawValue = value;
            rekord.ConvertedValue = output;
            this.repo.AddStatistic(rekord);

            //decimal output = converter.Convert(unitFrom, unitTo, decimal.Parse(valueToConvert));

            return output;
        }

        [Route("api/converters/show")]
        [HttpGet]
        public IEnumerable<StatisticDTO> getRecords(string repo)
        {
            if (repo == "Azure")
                this.repo = new StatisticsAzureStorageRepository();
            else this.repo = new StatisticsSqlRepository();
            //IConverter converter = this.scope.Resolve(Type.GetType(converterType)) as IConverter;
            IEnumerable<StatisticDTO> records = this.repo.GetStatistics();
            return records;
        }
    }
}
