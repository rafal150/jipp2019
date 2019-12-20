using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace konwerter
{
    public class UsageStatisticsSqlRepo : IUsageStatisticsRepo
    {
        public void AddStatistic(StatisticDTO statistic)
        {
            using (Model1 context = new Model1())
            {
                context.UsageStatistics.Add(new UsageStatistics()
                {
                    DateTime = statistic.DateTime,
                    UnitType = statistic.UnitType,
                    InputUnit = statistic.InputUnit,
                    OutputUnit = statistic.OutputUnit,
                    Value = statistic.Value
                });

                context.SaveChanges();
            }
        }

        public string GetStatistics()
        {
            using (Model1 context = new Model1())
            {
                int conversionsNumber = context.Database.SqlQuery<int>("select max(ID) from UsageStatistics").Single();

                return conversionsNumber.ToString();
            }
        }

    }
}
