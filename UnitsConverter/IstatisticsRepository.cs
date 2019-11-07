using Microsoft.WindowsAzure.Storage.Table;
using System.Collections.Generic;

namespace UnitsConverter
{
    public interface IStatisticsRepository
    {



        IEnumerable<StatisticDTO> GetStatistics();
        void AddStatistic(StatisticDTO st);
    }
}