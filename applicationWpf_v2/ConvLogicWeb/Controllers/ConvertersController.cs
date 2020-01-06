using Autofac;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using applicationWpf;
using System;

namespace ConvLogicWeb.Controllers
{
    public class ConvertersController : ApiController
    {
        private ConverterService convertersService;
        private ILifetimeScope scope;
        private IStatisticsRepository repo;

        public ConvertersController(ILifetimeScope scope, IStatisticsRepository statisticsRepository, ConverterService convertersService)
        {
            this.convertersService = convertersService;
            this.scope = scope;
            this.repo = statisticsRepository;
        }

        public List<ConverterBase> GetConverters()
        {
            List<ConverterBase> converters = this.convertersService.GetConverters();
            return converters;
        }

        [Route("api/converters/convert")]
        [HttpGet]
        public decimal Convert(string unitFrom, string unitTo, string valueToConvert,
            string converterType)
        {
            ConverterBase converter = this.convertersService.GetConverters()
                .Where(c => c.converterName == converterType).FirstOrDefault();

            int from = Array.IndexOf(converter.suffix, unitFrom);
            int to = Array.IndexOf(converter.suffix, unitTo);
            if (string.IsNullOrWhiteSpace(valueToConvert))
                return decimal.Zero;

            double value = double.Parse(valueToConvert);
            decimal output = (decimal)converter.Convert(value, from, to);


            ConvSupply.pairData(converter.suffix, from, to, value, (double)output, converter.converterName);
            ConvSupply.AddDbEntry(repo);
            string resultString = ConvSupply.GetConvertedString();
            return output;
        }

        [Route("api/converters/getstatistics")]
        [HttpGet]
        public StatisticsDTO[] GetStats()
        {
            return repo.GetStatistics().ToArray();
        }
    }
}