using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter
{
    public class StatisticsSqlRepository : IStatisticRepository
    {
        public void AddStatistic(StatisticDTO statistic)
        {
            using (StatisticContext context = new StatisticContext())
            {
                context.Statystykis.Add(new Statystyki()
                {
                    ID = statistic.Id,
                    Rodzaj = statistic.Type,
                    Czas = statistic.DateTime,
                    JednostkaZ = statistic.UnitFrom,
                    WartośćPrzed = statistic.ValueFrom,
                    JednostkaDo = statistic.UnitTo,
                    WartośćPo = statistic.ValueTo
                });

                context.SaveChanges();
            }
        }

        public IEnumerable<StatisticDTO> GetStatistics()
        {
            using (StatisticContext context = new StatisticContext())
            {
                return context.Statystykis.Select(obj => new StatisticDTO() {
                    Id = obj.ID,
                    DateTime = obj.Czas,
                    Type = obj.Rodzaj,
                    ValueFrom = obj.WartośćPrzed,
                    UnitFrom = obj.JednostkaZ,
                    UnitTo = obj.JednostkaDo,
                    ValueTo = obj.WartośćPo
                }).ToList();
            }
        }
    }
}
