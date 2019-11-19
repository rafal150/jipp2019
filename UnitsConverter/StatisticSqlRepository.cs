using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitsConverter.Model;
namespace UnitsConverter
{
    class StatisticSqlRepository
    {
        public class StatisticsSqlRepository : IStatisticsRepository
        {
            public void AddStatistic(StatisticDTO statistic)
            {
                using (StatisticsModel context = new StatisticsModel())
                {
                    context.Statistics.Add(new Statistic()
                    {
                        Type = statistic.Type,
                        DateTime = statistic.DateTime,
                        FromUnit = statistic.FromUnit,
                        FromTo = statistic.FromTo,
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
                        Select(obj => new StatisticDTO() { DateTime = obj.DateTime, Type = obj.Type, FromUnit = obj.FromUnit,FromTo = obj.FromTo, ConvertedValue= obj.ConvertedValue }).
                        ToList();
                }



            }
        }
    }
}