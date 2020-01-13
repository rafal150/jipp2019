using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitConverter.Model;

namespace UnitConverter
{
    public class StatystykiSQL : InterfejsStatystyki
    {
        public void AddStatistic(Statystyki statistic)
        {
            using (StatisticsModel context = new StatisticsModel())
            {
                context.Statistics.Add(new Statistic()
                {
                    Type = statistic.Tresc,
                    DateTime = statistic.DataLogu
                });

                context.SaveChanges();
            }
        }

        public void AddStatistic(InterfejsStatystyki statistic)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Statystyki> GetStatistics()
        {
            using (StatisticsModel context = new StatisticsModel())
            {
                return context.Statistics.
            Select(obj => new Statystyki() { DataLogu = obj.DateTime, Tresc = obj.Type }).
                    ToList();
            }
        }


    }
}
