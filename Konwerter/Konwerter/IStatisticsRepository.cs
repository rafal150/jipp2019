using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter
{
    public interface IStatisticsRepository
    {
        void AddStatistics(StatisticsDTO statistics);
        IEnumerable<StatisticsDTO> GetStatistics();
    }
}
