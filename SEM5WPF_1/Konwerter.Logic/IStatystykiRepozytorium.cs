using System.Collections.Generic;


namespace SEM5WPF_1
{
    public interface IStatystykiRepozytorium
    {
        void DodajStatystyki(StatystykiDTO statystyki);

        IEnumerable<StatystykiDTO> GetStatystykis();
    }
}
