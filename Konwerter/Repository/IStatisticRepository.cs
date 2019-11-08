using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter
{
    public interface IStatisticRepository
    {
        void AddStatistic(StatisticDTO statistic);
        IEnumerable<StatisticDTO> GetStatistics();
    }
}
