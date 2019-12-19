using JIPP5_LAB.Interfaces;
using JIPP5_LAB.SDK;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace JIPP5_LAB.DataProviders
{
    public class DatabaseHelper : IDataHelper
    {
        public void AddRecord(StatisticsDTO modelToSave)
        {
            using (var context = new StatisticsContext())
            {
                context.Statistics.Add(new StatisticModel(modelToSave));
                context.SaveChanges();
            }
        }

        public IEnumerable<StatisticsDTO> GetRecords()
        {
            ObservableCollection<StatisticsDTO> statisticModels = new ObservableCollection<StatisticsDTO>();
            using (var context = new StatisticsContext())
            {
                foreach (var item in context.Statistics)
                {
                    statisticModels.Add(new StatisticsDTO() {
                        Converted = item.Converted,
                        Date = item.Date,
                        FromUnit = item.FromUnit,
                        RawData = item.RawData,
                        ToUnit = item.ToUnit
                    });
                }
            }
            return statisticModels;
        }
    }
}