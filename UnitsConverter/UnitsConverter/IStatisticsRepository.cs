using System.Collections.Generic;

namespace UnitsConverter
{
    public interface IStatisticsRepository
    {
        void AddStatistic(StatisticDTO statistic);
        IEnumerable<StatisticDTO> GetStatistics();
    }
}
