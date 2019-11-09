using Converter.Program;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Converter;
using Converter.DataBaseConnection;

namespace Converter.Model
{
    public class StatisticsSqlRepository
    {
        public void AddStatistic(BaseConverter converter)
        {
            using (DataBaseConnection.DataBaseConnection context = new DataBaseConnection.DataBaseConnection())
            {
                context.Converters.Add(converter);
                context.SaveChanges();
            }
        }

        public IEnumerable<StatisticDTO> GetStatistics()
        {
            using (DataBaseConnection.DataBaseConnection context = new DataBaseConnection.DataBaseConnection())
            {
                return context.Converters.
                    Select(obj => new StatisticDTO() { ConvertingTime = obj.ConvertingTime, PhysicalProperty = obj.PhysicalProperty }).
                    ToList();
            }
        }
    }
}