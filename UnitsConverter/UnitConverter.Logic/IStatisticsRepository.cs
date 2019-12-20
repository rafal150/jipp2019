using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Units_Converter
{
    public interface IStatisticsRepository
    {
         void AddStatistic(StatisticsDTO statistic);
         IEnumerable<StatisticsDTO> GetStatistics();
    }
    
}
