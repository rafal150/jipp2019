using JIPP5_LAB.Models;
using System.Collections.Generic;
using System.Linq;

namespace JIPP5_LAB.Data
{
    public class Database : IGetData
    {
        public void AddStatistic(StatisticDTO statistic)
        {
            using (StatisticsContext context = new StatisticsContext())
            {
                context.Statistics.Add(new StatisticModel()
                {
                    Type = statistic.Type,
                    DateTime = statistic.DateTime,
                    ConvertedValue = statistic.ConvertedValue,
                    RawValue = statistic.RawValue,
                    UnitFrom = statistic.UnitFrom,
                    UnitTo = statistic.UnitTo,
                });

                context.SaveChanges();
            }
        }

        public IEnumerable<StatisticDTO> GetStatistics()
        {
            using (StatisticsContext context = new StatisticsContext())
            {
                return context.Statistics.
                    Select(obj => new StatisticDTO() { DateTime = obj.DateTime, Type = obj.Type, ConvertedValue = obj.ConvertedValue, UnitTo = obj.UnitTo, UnitFrom = obj.UnitFrom, RawValue = obj.RawValue }).
                    ToList();
            }
        }
    }
}