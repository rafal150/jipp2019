using System.Collections.Generic;

namespace UnitConvLogic
{
    public interface IAzureStats
    {
        void AddStatistic(DataGrid statistic);
        IEnumerable<DataGrid> GetStatistics();
    }
}