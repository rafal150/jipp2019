using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Konwerter
{
    public interface IStatystykiRepo
    {
        void Dodaj_do_bazy(StatystykiObiekt stats);
        IEnumerable<StatystykiObiekt> GetStatistics();
    }
}
