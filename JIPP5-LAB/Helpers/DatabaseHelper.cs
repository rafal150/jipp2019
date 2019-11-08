using JIPP5_LAB.Database;
using JIPP5_LAB.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JIPP5_LAB.Helpers
{
    public class DatabaseHelper : IDataHelper
    {
        public void AddRecord(StatisticModel modelToSave)
        {
            using (var context = new StatisticsContext())
            {
                context.Statistics.Add(modelToSave);
                context.SaveChanges();
            }
        }

        public IEnumerable<StatisticModel> GetRecords()
        {
            ObservableCollection<StatisticModel> statisticModels = new ObservableCollection<StatisticModel>();
            using (var context = new StatisticsContext())
            {
                foreach (var item in context.Statistics)
                {
                    statisticModels.Add(item);
                }
            }
            return statisticModels;
        }
    }
}
