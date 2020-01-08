using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitCoverterPart2
{
    class StatisticsEmptyRepository : IStatisticsRepository
    {
        public void AddStatistic(StatisticDTO statistic)
        {
            
        }

        public IEnumerable<StatisticDTO> GetStatistics()
        {
            return null;
        }
    }
}
