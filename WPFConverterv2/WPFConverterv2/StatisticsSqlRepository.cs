using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFConverterv2.Model;

namespace WPFConverterv2
{
    public class StatisticsSqlRepository : IStatisticsRepository
    {
        public void AddStatistic(Statistic statistic)
        {
            using (StatisticsModel context = new StatisticsModel())
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

        public IEnumerable<Statistic> GetStatistics()
        {
            using (StatisticsModel context = new StatisticsModel())
            {
                return context.MyStatistics2.
                    Select(obj => new Statistic() { id = obj.id , DateTime = obj.DateTime, UnitFrom = obj.UnitFrom, UnitTo = obj.UnitTo, RawValue = obj.RawValue, ConvertedValue = obj.ConvertedValue, Type = obj.Type }).
                    ToList();
            }
        }

        public void DeleteStatistic(Statistic statistic)
        {
            using (StatisticsModel context = new StatisticsModel())
            {


            }
        }
    }
}
