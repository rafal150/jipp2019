using System.Collections.Generic;

namespace KonwerterPLUGIN
{
    public interface DodajStatystyki
    {
        void AddStatistic(Logi statistic);
        IEnumerable<Logi> GetStatistics();
    }
}