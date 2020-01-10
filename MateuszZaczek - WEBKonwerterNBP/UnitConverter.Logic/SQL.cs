using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KonwerterZSQLiAZUREiPLUGIN.Model;

namespace KonwerterZSQLiAZUREiPLUGIN
{
    public class SQL: ADDStat
    {
        public void AddStatistic(DBO statistic)
        {
            using (StatisticsModel context = new StatisticsModel())
            {
                context.Statistics.Add(new Statistic()
                {
                    Type = statistic.Type,
                    DateTime = statistic.DateTime
                });

                context.SaveChanges();
            }
        }

        public IEnumerable<DBO> GetStatistics()
        {
            using (StatisticsModel context = new StatisticsModel())
            {
                return context.Statistics.
                    Select(obj => new DBO() { DateTime = obj.DateTime, Type = obj.Type }).
                    ToList();
            }
        }
    }
}
