using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterJedn
{
    class StatisticsSqlRepository : IStatisticsRepository
    {

        public void AddStatistic(StatisticDTO statistic)
        {
            using (StatystykiSQL context = new StatystykiSQL())
            {
                context.StatsBaza3.Add(new StatsBaza3()
                {
                    UnitFrom = statistic.UnitFrom,
                    UnitTo = statistic.UnitTo,
                    ValueFrom = statistic.ValueFrom,
                    ValueTo = statistic.ValueTo,
                    Type = statistic.Type,
                    DateTime = statistic.DateTime
                });

                context.SaveChanges();
            }
        }

        public IEnumerable<StatisticDTO> GetStatistics()
        {
            using (StatystykiSQL context = new StatystykiSQL())
            {
                return context.StatsBaza3.
                    Select(obj => new StatisticDTO() { UnitFrom = obj.UnitFrom, UnitTo = obj. UnitTo, ValueFrom = obj. ValueFrom, ValueTo = obj. ValueTo,Type = obj.Type, DateTime = obj.DateTime, }).
                    ToList();
            }
        }
    }
}
