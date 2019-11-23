using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Generic;

namespace KonwerterApp.Services
{
    public interface IConverter
    {
        string Nazwa { get; }
        List<string> Jednostki { get; }
        float Konwertuj(string JednostkaPoczatkowa, string JednostkaKoncowa, float wartosc);
    }
}