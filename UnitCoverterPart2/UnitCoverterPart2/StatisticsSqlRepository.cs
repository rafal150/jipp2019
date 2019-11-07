using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitCoverterPart2.Model;

namespace UnitCoverterPart2
{
    public class StatisticsSqlRepository: IStatisticsRepository
    {
        public void AddStatistic(StatisticDTO statistic)
        {
            using (StatisticsModel context = new StatisticsModel())
            {
                context.Statistics.Add(new Statistic()
                {
                    Type = statistic.Type,
                    DateTime = statistic.DateTime,
                    UnitFrom = statistic.UnitFrom,
                    UnitTo = statistic.UnitTo,
                    RawValue = statistic.RawValue,
                    ConvertedValue = statistic.ConvertedValue
                });

                context.SaveChanges();
            }
        }

        public IEnumerable<StatisticDTO> GetStatistics()
        {
            using (StatisticsModel context = new StatisticsModel())
            {
                return context.Statistics.
                    Select(obj => new StatisticDTO() { Id = obj.Id, DateTime = obj.DateTime, Type = obj.Type, UnitFrom = obj.UnitFrom, UnitTo = obj.UnitTo, RawValue = obj.RawValue, ConvertedValue = obj.ConvertedValue }).
                    ToList();
            }
        }
    }
}
