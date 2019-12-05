using System.Collections.Generic;

namespace applicationWpf
{
    public interface IStatisticsRepository
    {
        void AddStatistic(StatisticsDTO statistic);
        IEnumerable<StatisticsDTO> GetStatistics();
    }
}
