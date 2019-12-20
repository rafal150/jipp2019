using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Units_Converter.Statistics;

namespace Units_Converter
{
    public class StatisticsSqlRepository : IStatisticsRepository
    {
        public void AddStatistic(StatisticsDTO statistic)
        {
            using (StatisticsModel context = new StatisticsModel())
            {
                context.Statistics.Add(new Statistic()
                {
                    Type = statistic.Type,
                    DateTime = statistic.DateTime
                });

                context.SaveChanges();
            }
        }

        public IEnumerable<StatisticsDTO> GetStatistics()
        {
            using (StatisticsModel context = new StatisticsModel())
            {
                return context.Statistics.
                    Select(obj => new StatisticsDTO() { DateTime = obj.DateTime, Type = obj.Type }).
                    ToList();
            }
        }
    }
}
