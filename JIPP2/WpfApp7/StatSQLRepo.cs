using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  WpfAppJIPP

{
    public class StatSQLRepo : IStatRepo
    {
        public void AddStatistic(StatDTO statistic)
        {
            using (Converter context = new Converter())
            {
                context.Statistics.Add(new Statistics()
                {
                    Type = statistic.Type,
                    DateTime = statistic.DateTime
                });

                context.SaveChanges();
            }
        }

        public IEnumerable<StatDTO> GetStatistics()
        {
            using (Converter context = new Converter())
            {
                return context.Statistics.
                    Select(obj => new StatDTO() { DateTime = obj.DateTime, Type = obj.Type }).
                    ToList();
            }
        }
    }
}