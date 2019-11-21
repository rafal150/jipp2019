using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter_jednostek
{
    public interface IKonwertuj
    {
        List<Miara> Lista_Miar { get; }
        List<Przeliczanie_miar> Lista_Przeliczanie_miar { get; }

        string Pobierz_nazwe_typu(int id_typu);
    }
}
