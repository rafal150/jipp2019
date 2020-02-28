
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter
{

    public class StatisticsSqlRepository : IStatisticsRepository
    {
        public void AddStatistic(StatDTO statistic)
        {
            using (StatisticsContext context = new StatisticsContext())
            {
                context.Statistics.Add(new StatisticsDB()
                {
                   
                    DateTime = statistic.DateTime,
                    UnitFrom = statistic.UnitFrom,
                    UnitTo = statistic.UnitTo,
                   
                });

                context.SaveChanges();
            }
        }



        public IEnumerable<StatDTO> GetStatistics()
        {
            using (StatisticsContext context = new StatisticsContext())
            {
                return context.Statistics.
                    Select(obj => new StatDTO() { DateTime = obj.DateTime, UnitFrom = obj.UnitFrom, UnitTo = obj.UnitTo }).
                    ToList();
            }



        }
    }
}
