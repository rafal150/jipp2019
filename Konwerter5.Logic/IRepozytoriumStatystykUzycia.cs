using System.Collections.Generic;

namespace Konwerter5.Logic
{
    public interface IRepozytoriumStatystykUzycia
    {
        void DodajStatystykiUzycia(StatystykiUzyciaDTO StatystykiUzycia);
        IEnumerable<StatystykiUzyciaDTO> PobierzStatystykiUzycia();
    }
}
