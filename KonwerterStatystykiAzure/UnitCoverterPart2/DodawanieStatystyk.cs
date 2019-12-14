using System.Collections.Generic;

namespace KonwerterAzure
{
    public interface DodawanieStatystyk
    {
        void AddStatistic(StatystykiDBO statistic);
        IEnumerable<StatystykiDBO> GetStatistics();

        
    }
}