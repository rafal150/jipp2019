using System.Collections.Generic;

namespace Konwerter5
{
    public interface IRepozytoriumStatystykUzycia
    {
        void DodajStatystykiUzycia(StatystykiUzyciaDTO StatystykiUzycia);
        IEnumerable<StatystykiUzyciaDTO> PobierzStatystykiUzycia();
    }
}
