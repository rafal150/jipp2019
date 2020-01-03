using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterApp
{
    public class StatisticsSQLRepository : IStatisticsRepository
    {
        public void DodajStatystyke(StatisticDTO statistic)
        {
            using (Model1 context = new Model1())
            {
                context.TabelaKonwerteras.Add(new TabelaKonwertera()
                {
                    ID = statistic.ID,
                    DateTime = statistic.DateTime,
                    Type = statistic.Type,
                    FromUnit = statistic.FromUnit,
                    ToUnit = statistic.ToUnit,
                    RawValue = statistic.RawValue,
                    Converted = statistic.Converted,
                });
                context.SaveChanges();
            }
        }

        public IEnumerable<StatisticDTO> GetStatistic()
        {
            using (Model1 context = new Model1())
            {
                return context.TabelaKonwerteras.
                    Select(obj => new StatisticDTO() {
                        ID = obj.ID,
                        DateTime = obj.DateTime,
                        Type = obj.Type,
                        FromUnit = obj.FromUnit,
                        ToUnit = obj.ToUnit,
                        RawValue = obj.RawValue,
                        Converted = obj.Converted,
                    }).
                    ToList();
            }
        }
    }
}
