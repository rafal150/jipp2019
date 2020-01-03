using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterApp
{
    public interface IStatisticsRepository
    {
        void DodajStatystyke(StatisticDTO statistic);
        IEnumerable<StatisticDTO> GetStatistic();
    }
}
