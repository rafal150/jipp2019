using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unitconverter
{
    public interface IStatisticsRepository
    {
        void AddStatistic(StatDTO statistic);
        IEnumerable<StatDTO> GetStatistics();
    }
}
