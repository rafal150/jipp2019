using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterJedn
{
    public interface IConverter
    {
        string Nazwa { get; }
        List<string> Jednostki { get; }
        //metoda do konwersji
        double Convert(string unitFrom, string unitTo, double Wartosc);
    }
}
