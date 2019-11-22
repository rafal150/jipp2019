using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwenter
{
    public interface IBazyDanych
    {
        void zapisDoBazy(ZapisBazaDTO stat);
        IEnumerable<ZapisBazaDTO> wyswietlStatystyki();
    }
}
