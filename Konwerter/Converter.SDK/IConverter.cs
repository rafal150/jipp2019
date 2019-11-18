using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter.Services
{
    public interface IConverter
    {
        string Name { get;}
        List<string> Units { get; }
        double Liczenie(string z, string na, double wartosc);
    }
}
