using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter
{
    public interface IRepository
    {
        void AddStatistic(StatisticJZDTO statistic);
        IEnumerable<StatisticJZDTO> GetStatistics();
    }
}
