using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter
{
    public interface IRepo
    {
        void dodajRekord(RekordDTO rekord);
        IEnumerable<RekordDTO> pobierzRekordy();
        void wyczyscHistorie();
    }
}
