using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace konwerter
{
    public interface IUsageStatisticsRepo
    {
        void AddStatistic(StatisticDTO statistic);
        string GetStatistics();
    }
}
