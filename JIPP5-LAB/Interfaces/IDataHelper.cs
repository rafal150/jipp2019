using JIPP5_LAB.Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JIPP5_LAB.Interfaces
{
    public interface IDataHelper
    {
        void AddRecord(StatisticModel modelToSave);
        IEnumerable<StatisticModel> GetRecords();
    }
}
