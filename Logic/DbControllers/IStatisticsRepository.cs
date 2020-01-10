using System.Collections.Generic;

namespace Logic
{
    public interface IStatisticsRepository
    {
        voId AddStatistic(StatisticsObject statistic);
        IEnumerable<StatisticsObject> GetStatistics();
    }
}