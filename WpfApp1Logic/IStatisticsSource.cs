using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.SDK;

namespace WpfApp1.Logic
{
    public interface IStatisticsSource
    {
        void AddStatistic(StatisticsDTO statistic);
        IEnumerable<StatisticsDTO> GetStatistics();
    }
}
