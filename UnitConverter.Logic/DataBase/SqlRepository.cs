using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitConverter.Statistics;
using UnitConverter.DataBase;

namespace UnitConverter.DateBase
{
    public class SqlRepository : IStatisticsRepository
    {
        private DatabaseContext context;

        public SqlRepository()
        {
             context = new DatabaseContext();
        }

        public void AddStatistic(StatisticDTO statistic)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                context.Statistics.Add(new Statistic()
                {
                type = statistic.type,
                date = statistic.date,
                toUnit = statistic.toUnit,
                fromUnit = statistic.fromUnit,
                startValue = statistic.startValue,
                finalValue = statistic.finalValue
            });

                context.SaveChanges();
            }
        }
    

        public DatabaseContext GetDatabaseContext()
        {
            return context;
        }
        public IEnumerable<StatisticDTO> GetStatistics()
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                return context.Statistics.
                    Select(obj => new StatisticDTO() {
                        Id = obj.Id,
                        type = obj.type,       
                        date = obj.date,
                        finalValue = obj.finalValue,
                        startValue = obj.startValue,
                        fromUnit = obj.fromUnit,
                        toUnit = obj.toUnit
                      
                    }).
                    ToList();
            }
        }
    }
}
