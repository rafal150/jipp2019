using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    interface IStatisticsSource
    {
        void AddStatistic(StatisticsDTO statistic);
        IEnumerable<StatisticsDTO> GetStatistics();
    }
}
