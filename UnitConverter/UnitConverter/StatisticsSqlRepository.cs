using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter {
    class StatisticsSqlRepository : IStatisticsRepository {
        public void AddStatistic(StatisticDTO statistic) {
            using (Converter context = new Converter()) {
                context.Statistics.Add(new Statistic() {
                    DateTime = statistic.DateTime,
                    ConversionType = statistic.ConversionType,
                    UnitFrom = statistic.UnitFrom,
                    UnitTo = statistic.UnitTo,
                    ValueFrom = statistic.ValueFrom,
                    ValueTo = statistic.ValueTo
                });
                context.SaveChanges();
            }
        }
        public IEnumerable<StatisticDTO> GetStatistics() {
            using (Converter context = new Converter()) {
                return context.Statistics.Select(obj => new StatisticDTO() {
                    Id = obj.Id,
                    DateTime = obj.DateTime,
                    ConversionType = obj.ConversionType,
                    UnitFrom = obj.UnitFrom,
                    UnitTo = obj.UnitTo,
                    ValueFrom = obj.ValueFrom,
                    ValueTo = obj.ValueTo
                }).ToList();
            }
        }
    }
}
