using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwenter
{
    public interface IKonwersja
    {
        string nazwaKonwersji { get; }
        List<string> jednostki { get; }
        double obliczenia(double wartoscWej, int indexJednostkiWej, int indextJednostkiWyjsc);       
    }
}
