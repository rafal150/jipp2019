using Microsoft.WindowsAzure.Storage.Table;
using System.Collections.Generic;

namespace UnitsConverter
{
    public interface IStatisticsRepository
    {


 void AddStatistic(StatisticDTO st);
        IEnumerable<StatisticDTO> GetStatistics();
       
    }
}