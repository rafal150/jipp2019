using System.Collections.Generic;

namespace UnitConverter
{
    public interface InterfejsStatystyki
    {
        void AddStatistic(Statystyki statistic);
        IEnumerable<Statystyki> GetStatistics();
    }
}