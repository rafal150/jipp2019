using System.Collections.Generic;

namespace KonwerterZSQLiAZURE
{
    public interface ADDStat
    {
        void AddStatistic(DBO statistic);
        IEnumerable<DBO> GetStatistics();

        
    }
}