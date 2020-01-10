using System.Collections.Generic;

namespace KonwerterJedn
{
    public interface IStatisticsRepository
    {
        void AddStatistic(StatisticDTO statistic);
        IEnumerable<StatisticDTO> GetStatistics();
    }
}
