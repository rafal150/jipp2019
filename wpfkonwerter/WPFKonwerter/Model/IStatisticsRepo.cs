using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFKonwerter.Model
{
    public interface IStatisticsRepo
    {
        void SaveStats(Statistics stats);

        List<Statistics> GetStats();
        
    }
}
