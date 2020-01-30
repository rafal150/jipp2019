using System.Collections.Generic;

namespace JIPP5_LAB.bazydanych
{
    public interface IPobieranieDanych
    {
        void AddStatistic(StatisticDTO statistic);

        IEnumerable<StatisticDTO> GetStatistics();
    }
}