using System.Collections.Generic;

namespace UnitConvLogic
{
    public interface IStatictics
    {
        void AddStatistic(DataGrid statistic);
        IEnumerable<DataGrid> GetStatistics();
    }
}