using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFConverterv2
{
   
    public interface IStatisticsRepository
    {
        void AddStatistic(Statistic statistic);

        IEnumerable<Statistic> GetStatistics();

        
    }
}

