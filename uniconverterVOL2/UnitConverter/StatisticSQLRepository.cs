using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter
{
    class StatisticSQLRepository : IRepository
    {
        public void AddStatistic(StatisticJZDTO statistic)
        {
            using (Statistic context = new Statistic())
            {
                context.StatisticJZs.Add(new StatisticJZ()
                {
                    DateTime = DateTime.Now,
                    UnitFrom = statistic.UnitFrom,
                    UnitTo = statistic.UnitTo,
                    Type = statistic.Type,
                    RawValue = statistic.RawValue,
                    ConvertedValue = statistic.ConvertedValue
                }); 
                context.SaveChanges();
            }
        }

        public IEnumerable<StatisticJZDTO> GetStatistics()
        {
            using (Statistic context = new Statistic())
            {
                return context.StatisticJZs.
                     Select(obj => new StatisticJZDTO() 
                     { 
                         DateTime = obj.DateTime, 
                         UnitFrom = obj.UnitFrom,
                         UnitTo = obj.UnitTo,
                         Type = obj.Type,
                         RawValue = obj.RawValue,
                         ConvertedValue =obj.ConvertedValue }).
                     ToList();
            }
        }
    }
}
