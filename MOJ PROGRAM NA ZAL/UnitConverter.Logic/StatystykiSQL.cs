using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KonwerterZSQLiAZUREiPLUGIN.Model;

namespace KonwerterZSQLiAZUREiPLUGIN
{
    public class StatystykiSQL : RepozytoriumStatystyk
    {
        public void AddStatistic(PolaDataGrid statistic)
        {
            using (StatisticsModel context = new StatisticsModel())
            {
                context.Statistics.Add(new Statistic()
                {
                    Type = statistic.Type,
                    DateTime = statistic.DateTime
                });

                context.SaveChanges();
            }
        }

        public IEnumerable<PolaDataGrid> GetStatistics()
        {
            using (StatisticsModel context = new StatisticsModel())
            {
                return context.Statistics.
                    Select(obj => new PolaDataGrid() { DateTime = obj.DateTime, Type = obj.Type }).
                    ToList();
            }
        }
    }
}
