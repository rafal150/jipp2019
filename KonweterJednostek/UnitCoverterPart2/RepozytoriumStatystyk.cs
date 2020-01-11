using System.Collections.Generic;

namespace Konwerter
{
    public interface RepozytoriumStatystyk
    {
        void AddStatistic(PolaDataGrid statistic);
        IEnumerable<PolaDataGrid> GetStatistics();
    }
}