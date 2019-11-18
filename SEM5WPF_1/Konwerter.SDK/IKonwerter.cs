using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter.SDK
{
    public interface IKonwerter
    {
        string Name { get; }
        List<string> Units { get; }
        decimal Konwerter(string jednostkaZ, string jednostkaDo, decimal wartosc);
    }
}
