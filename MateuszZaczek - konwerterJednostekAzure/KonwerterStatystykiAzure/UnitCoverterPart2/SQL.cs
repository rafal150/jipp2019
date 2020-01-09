using System.Collections.Generic;
using System.Linq;
using KonwerterZSQLiAZURE.Model;

namespace KonwerterZSQLiAZURE
{
    public class SQL: ADDStat
    {
        public void AddStatistic(DBO statistic)
        {
            
            using (StatisticsModel context = new StatisticsModel())
            { 
                context.Statistics.Add(new Statistic()
                {
                    Type = statistic.LogKonwersji,
                    DateTime = statistic.DataGenerowania,
               
                });

                context.SaveChanges();
            }
        }

        public IEnumerable<DBO> GetStatistics()
        {
            using (StatisticsModel context = new StatisticsModel())
            {
                return context.Statistics.
                    Select(obj => new DBO() { DataGenerowania = obj.DateTime, LogKonwersji = obj.Type  }).ToList();
            }
        }
    }
}
