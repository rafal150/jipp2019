using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KonwerterPLUGIN.Model;

namespace KonwerterPLUGIN
{
    public class BazaDanych : DodajStatystyki
    {
        public void AddStatistic(Logi statistic)
        {
            using (StatisticsModel context = new StatisticsModel())
            {
                context.Statistics.Add(new Statistic()
                {
                    Type = statistic.LogiKonwersjiDanych,
                    DateTime = statistic.Data,

                });

                context.SaveChanges();
            }
        }

        public IEnumerable<Logi> GetStatistics()
        {
            using (StatisticsModel context = new StatisticsModel())
            {
                return context.Statistics.
                  Select(obj => new Logi() { Data = obj.DateTime, LogiKonwersjiDanych = obj.Type }).ToList();

            }
        }
    }
}
