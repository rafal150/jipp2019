using System.Collections.Generic;

namespace KonwerterZSQLiAZUREiPLUGIN
{
    public interface RepozytoriumStatystyk
    {
        void AddStatistic(PolaDataGrid statistic);
        IEnumerable<PolaDataGrid> GetStatistics();
    }
}