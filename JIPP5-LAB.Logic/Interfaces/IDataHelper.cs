using JIPP5_LAB.DataProviders;
using JIPP5_LAB.SDK;
using System.Collections.Generic;

namespace JIPP5_LAB.Interfaces
{
    public interface IDataHelper
    {
        void AddRecord(StatisticsDTO modelToSave);

        IEnumerable<StatisticsDTO> GetRecords();
    }
}