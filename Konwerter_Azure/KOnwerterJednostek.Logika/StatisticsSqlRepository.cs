using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Konwerter_Azure.Model;

namespace Konwerter_Azure
{
    public class StatisticsSqlRepository : IStatisticsRepository
    {
        public void AddStatistic(StatisticDTO statystyki)
        {
            using (StatisticsModel context = new StatisticsModel())
            {
                context.Statystyki.Add(new Statystyki()
                {
                    id = statystyki.id,
                    czas = statystyki.czas,
                    grupa= statystyki.grupa,
                    przeliczZ= statystyki.przeliczZ,
                    dane = statystyki.dane,
                    przeliczNa= statystyki.przeliczNa,
                    wynik= statystyki.wynik
                });

                //context.SaveChanges();
            }
        }

        public IEnumerable<StatisticDTO> GetStatistics()
        {
            using (StatisticsModel context = new StatisticsModel())
            {
                return context.Statystyki.Select(obiekt => new StatisticDTO()
                {
                    id = obiekt.id,
                    czas = obiekt.czas,
                    grupa= obiekt.grupa,
                    przeliczZ= obiekt.przeliczZ,
                    dane = obiekt.dane,
                    przeliczNa = obiekt.przeliczNa,
                    wynik = obiekt.wynik
                }).
                    ToList();
            }
        }
    }
}