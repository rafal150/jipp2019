using System.Collections.Generic;
using System.Linq;
using KonwerterAzure.Model;

namespace KonwerterAzure
{
    public class StatystykiSQL: DodawanieStatystyk
    {
        public void AddStatistic(StatystykiDBO statistic)
        {
            
            using (StatisticsModel context = new StatisticsModel())
            { 
                context.Statistics.Add(new Statistic()
                {
                    Type = statistic.TrescLogu,
                    DateTime = statistic.DataLogu,
               
                });

                context.SaveChanges();
            }
        }

        public IEnumerable<StatystykiDBO> GetStatistics()
        {
            using (StatisticsModel context = new StatisticsModel())
            {
                return context.Statistics.
                    Select(obj => new StatystykiDBO() { DataLogu = obj.DateTime,  TrescLogu = obj.Type  }).ToList();
            }
        }
    }
}
