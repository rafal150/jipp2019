using System.Collections.Generic;

namespace Przelicznik_Jednostek
{
    public interface IStatisticsRepository
    {
        void AddStatistic(StatisticDTO statistic);
        IEnumerable<StatisticDTO> GetStatistics();
    }
}