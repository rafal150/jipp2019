using JIPP5_LAB.Models;
using System.Collections.Generic;

namespace JIPP5_LAB.Data
{
    public interface IGetData
    {
        void AddStatistic(StatisticDTO statistic);

        IEnumerable<StatisticDTO> GetStatistics();
    }
}