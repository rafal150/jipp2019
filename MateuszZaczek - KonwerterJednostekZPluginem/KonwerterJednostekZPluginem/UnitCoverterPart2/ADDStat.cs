using System.Collections.Generic;

namespace KonwerterZSQLiAZUREiPLUGIN
{
    public interface ADDStat
    {
        void AddStatistic(DBO statistic);
        IEnumerable<DBO> GetStatistics();
    }
}