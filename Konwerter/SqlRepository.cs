using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Konwerter.Model;

namespace Konwerter
{
    public class SqlRepository: InterfaceStatisticsRepository
    {
        public void AddStatistics(StatisticsDTO statistics)
        {
            using (Db context = new Db())
            {
                context.Statistics.Add(new DbSql()
                {
                    conversionType = statistics.conversionType,
                    fromUnit = statistics.fromUnit,
                    valueToConvert = statistics.valueToConvert,
                    toUnit = statistics.toUnit,
                    convertedValue = statistics.convertedValue,
                    dateTime = statistics.dateTime
                });

                context.SaveChanges();
            }
        }

        public IEnumerable<StatisticsDTO> GetStatistics()
        {
            using (Db context = new Db())
            {
                return context.Statistics.Select(obj => new StatisticsDTO()
                {
                    conversionType = obj.conversionType,
                    fromUnit = obj.fromUnit,
                    valueToConvert = obj.valueToConvert,
                    toUnit = obj.toUnit,
                    convertedValue = obj.convertedValue,
                    dateTime = obj.dateTime
                }).ToList();
            }
        }
    }
}
