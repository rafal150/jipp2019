using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterNS
{
    public interface IStatisticsRepository
    {
        void ZapiszDoDB(string rodzaj, string Zjednostka, string Dojednostka, double WartoscZ, double WartoscNa);
        List<StatisticDTO> WczytajStaty();
    }
}
