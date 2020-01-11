using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KonwerterNS.Modell;

namespace KonwerterNS
{
    public class StatisticsSqlRepository : IStatisticsRepository
    {
        public void ZapiszDoDB(string rodzaj, string Zjednostka, string Dojednostka, double WartoscZ, double WartoscNa)
        {
            using (StatisticModel context = new StatisticModel())
            {
                Statistic st = new Statistic()
                {
                    DateTime = DateTime.Now,
                    FromUnit = Zjednostka,
                    FromTo = Dojednostka,
                    RawValue = Convert.ToDecimal(WartoscZ),
                    ConvertedValue = Convert.ToDecimal(WartoscNa),
                    Type = rodzaj
                };

                context.Statistics.Add(st);
                context.SaveChanges();
            }
        }

        public List<StatisticDTO> WczytajStaty()
        {
            List<StatisticDTO> statistics;

            using (StatisticModel context = new StatisticModel())
            {
                statistics = context.Statistics.Select(obj => new StatisticDTO() {
                    DateTime = obj.DateTime,
                    Type = obj.Type,
                    FromTo = obj.FromTo,
                    FromUnit = obj.FromUnit,
                    RawValue = obj.RawValue,
                    Id = obj.Id,
                    ConvertedValue = obj.ConvertedValue
                }).
                    ToList();
            }

            return statistics;
        }
    }
}
