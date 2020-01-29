using System.Collections.Generic;

namespace KonwerterZSQLiAZUREiPLUGIN
{
    public interface DodajStatystyki
    {
        void AddStatistic(Logi statistic);
        IEnumerable<Logi> GetStatistics();
    }
}