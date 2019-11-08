

using System.Collections.Generic;
using System.Linq;

namespace applicationWpf
{
    public class StatisticsSqlRepository : IStatisticsRepository
    {
        public void AddStatistic(StatisticsDTO stats)
        {
            using (UnitConvertContext context = new UnitConvertContext())
            {
                context.statistics.Add(new Statistics()
                {
                    Id = stats.Id,
                    Type = stats.Type,
                    SourceValue = stats.SourceValue,
                    SourceUnit = stats.SourceUnit,
                    Date = stats.Date,
                    ConvertedUnit = stats.ConvertedUnit,
                    ConvertedValue = stats.ConvertedValue
                });
                context.SaveChanges();
            }
        }

        public IEnumerable<StatisticsDTO> GetStatistics()
        {

            using (UnitConvertContext context = new UnitConvertContext())
            {
                if (context.statistics.Count() == 0) 
                    return null;

                var query = context.statistics.Select(dupa => new StatisticsDTO()
                {
                    Id = dupa.Id,
                    ConvertedUnit = dupa.ConvertedUnit,
                    ConvertedValue = dupa.ConvertedValue,
                    Date = dupa.Date,
                    SourceUnit = dupa.SourceUnit,
                    SourceValue = dupa.SourceValue,
                    Type = dupa.Type
                }).ToList();//  from stat in context.statistics select new { stat.Id, stat.Date, stat.Type, stat.SourceUnit, stat.SourceValue, stat.ConvertedUnit, stat.ConvertedValue };
                return query;
            }
        }
    }
}