using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter
{
    public interface InterfaceStatistic
    {

        void AddStatistic(StatisticRecord statistic);
        IEnumerable<StatisticRecord> GetStatistics();

    }
}
