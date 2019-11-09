using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter
{
    class StatisticToSql: InterfaceStatistic
    {

        public void AddStatistic(StatisticRecord statistic)
        {
            using (UnitConverterDB_Entities database = new UnitConverterDB_Entities())
            {
                Statistics new_record = new Statistics();

                new_record.Date = statistic.DateTime;
                new_record.ValueFrom = statistic.ValueFrom;
                new_record.UnitFrom = statistic.UnitFrom;
                new_record.ValueTo = statistic.ValueTo;
                new_record.UnitTo = statistic.UnitTo;

                database.Statistics.Add(new_record);
                database.SaveChanges();


            }
        }

        public IEnumerable<StatisticRecord> GetStatistics()
        {
            using (UnitConverterDB_Entities database = new UnitConverterDB_Entities())
            {
                return database.Statistics.
                    Select(obj => new StatisticRecord() { DateTime = obj.Date, ValueFrom = obj.ValueFrom, UnitFrom = obj.UnitFrom, ValueTo = obj.ValueTo, UnitTo = obj.UnitTo }).
                    ToList();
            }
        }
    }
}
