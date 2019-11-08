using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppJIPP;

namespace WpfAppJIPP
{
    public class StatisticsSqlRepository : IStatisticsRepository
    {
        public void AddStatistic(StatisticDTO statistics)
        {
            using (Converter context = new Converter())
            {
                context.Stats.Add(new Statistics()
                {
                    Id = statistics.Id,
                    Czas = statistics.Czas,
                    Typ = statistics.Typ,
                    Konwersja_z = statistics.Konwersja_z,
                    Konwersja_na = statistics.Konwersja_na,
                    Wartosc_wprowadzona = statistics.Wartosc_wprowadzona,
                    Wynik = statistics.Wynik,
                });

                context.SaveChanges();
            }
        }

        public IEnumerable<StatisticDTO> GetStatistics()
        {
            using (Converter context = new Converter())
            {
                return context.Stats.
                    Select(obj => new StatisticDTO() {
                        Id = obj.Id,
                        Czas = obj.Czas,
                        Typ = obj.Typ,
                        Konwersja_z = obj.Konwersja_z,
                        Konwersja_na = obj.Konwersja_na,
                        Wartosc_wprowadzona = obj.Wartosc_wprowadzona,
                        Wynik = obj.Wynik,


                    }).
                    ToList();
            }
        }
    }
}
