using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class StatisticsSqlRepository : IStatisticsSource
    {
        public void AddStatistic(StatisticsDTO statistics)
        {
            using (StatisticsDatabase context = new StatisticsDatabase())
            {
                context.StatisticsSqlSource.Add(new Statistics()
                {
                   //Id = statistics.Id,
                    Time = statistics.Time,
                    From = statistics.From,
                    To = statistics.To,
                    OryginalValue = statistics.OryginalValue,
                    CalculatedValue = statistics.CalculatedValue,
                }); ;
                context.SaveChanges();
            }
        }
        public IEnumerable<StatisticsDTO> GetStatistics()
        {
            using (StatisticsDatabase context = new StatisticsDatabase())
            {
                return context.StatisticsSqlSource.
                    Select(obj => new StatisticsDTO()
                    {
                        Id = obj.Id,
                        Time = obj.Time,
                        From = obj.From,
                        To = obj.To,
                        OryginalValue = obj.OryginalValue,
                        CalculatedValue = obj.CalculatedValue,


                    }).ToList();
            }
        }
    }
}
