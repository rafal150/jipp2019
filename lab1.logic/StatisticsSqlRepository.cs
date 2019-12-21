using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab1.Model;

namespace lab1
{
    public class StatisticsSqlRepository : IStatisticsRepository
    {
        public void AddStatistic(StatisticDTO statistic)
        {
            using (Model1 context = new Model1())
            {
                context.Tabela1.Add(new Tabela1()
                {
                    TypJednostki = statistic.TypJednostki,
                    Data = statistic.Data,
                    Id = statistic.Id,
                    JednostkaZ = statistic.JednostkaZ,
                    JednostkaDo=statistic.JednostkaDo,
                    IloscPrzed=statistic.IloscPrzed,
                    IloscPo=statistic.IloscPo
                }) ;

                context.SaveChanges();
            }
        }

        public IEnumerable<StatisticDTO> GetStatistics()
        {
            using (Model1 context = new Model1())
            {
                return context.Tabela1.
                    Select(obj => new StatisticDTO() {Id=obj.Id,  Data = obj.Data, TypJednostki = obj.TypJednostki, IloscPrzed = obj.IloscPrzed, IloscPo= obj.IloscPo, JednostkaZ=obj.JednostkaZ, JednostkaDo=obj.JednostkaDo  }).
                    ToList();
            }
        }
    }
}
