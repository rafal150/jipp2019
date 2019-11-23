using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitCoverterPart2.Model;

namespace UnitCoverterPart2
{
    public class StatisticsSqlRepository : IStatisticsRepository
    {
        public void AddStatistic(StatisticDTO statistic)
        {
            using (EntityModel context = new EntityModel())
            {
                context.MyStatistics2.Add(new MyStatistics2()
                {
                    id = statistic.id,
                    DateTime = statistic.DateTime,
                    UnitFrom = statistic.UnitFrom,
                    UnitTo = statistic.UnitTo,
                    RawValue = statistic.RawValue,
                    ConvertedValue = statistic.ConvertedValue,
                    Type = statistic.Type
                });

                context.SaveChanges();
            }
        }

        public IEnumerable<StatisticDTO> GetStatistics()
        {
            using (EntityModel context = new EntityModel())
            {
                return context.MyStatistics2.
                    Select(obj => new StatisticDTO() { id = obj.id, DateTime = obj.DateTime, UnitFrom = obj.UnitFrom, UnitTo = obj.UnitTo, RawValue = obj.RawValue, ConvertedValue = obj.ConvertedValue, Type = obj.Type }).
                    ToList();
            }
        }


    }
}
