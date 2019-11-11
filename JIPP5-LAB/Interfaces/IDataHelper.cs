using JIPP5_LAB.DataProviders;
using System.Collections.Generic;

namespace JIPP5_LAB.Interfaces
{
    public interface IDataHelper
    {
        void AddRecord(StatisticModel modelToSave);

        IEnumerable<StatisticModel> GetRecords();
    }
}