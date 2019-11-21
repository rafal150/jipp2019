using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter_jednostek
{
    public interface IPolaczenie
    {
        void Dodaj_statystyke(Statystyka statystyka);
        IEnumerable<Statystyka> PobierzStatystyki();
    }
}
