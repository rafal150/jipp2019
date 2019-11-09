using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MójKonwerterJednostek.Dane;

namespace MójKonwerterJednostek.Konwertery
{
    public class StatisticsSqlRepository : IStatisticsRepository
    {
        public void AddStatistic(StatisticDTO statistic)
        {
            using (StatisticModel context = new StatisticModel())
            {
                context.Statistic.Add(new Statistic()
                {
                    
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
            using (StatisticModel context = new StatisticModel())
            {
                return context.Statistic.
                    Select(obj => new StatisticDTO() {ID = obj.ID, DateTime = obj.DateTime, UnitFrom = obj.UnitFrom, UnitTo = obj.UnitTo, RawValue = obj.RawValue, ConvertedValue =obj.ConvertedValue, Type = obj.Type }).
                    ToList();
            }
        }
    }
}
