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
                    ConvertedValue = statistic.ConvertedValue,
                    RawValue = statistic.RawValue
                });

                context.SaveChanges();
            }
        }

        public IEnumerable<StatisticDTO> GetStatistics()
        {
            using (StatisticsModel context = new StatisticsModel())
            {
                return context.Statistics.
                    Select(obj => new StatisticDTO() { DateTime = obj.DateTime,
                                                       Type = obj.Type,
                                                       UnitFrom = obj.UnitFrom,
                                                       UnitTo = obj.UnitTo,
                                                       RawValue = (obj.RawValue),
                                                       ConvertedValue = obj.ConvertedValue.ToString()}).ToList();
            }
        }

        public void Clean()
        {
            using (StatisticsModel context = new StatisticsModel())
            {
                IEnumerable<Statistic> toDelete = context.Statistics.Where(x => x.Id > 0);
                context.Statistics.RemoveRange(toDelete);
                context.SaveChanges();
            }
        }

        private int getDateInt()
        {
            var x = DateTime.Now;
            var temp = x.ToString("mmss");
            return int.Parse(temp);
        }
    }
}
