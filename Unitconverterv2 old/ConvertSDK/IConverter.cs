using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unitconverter.Services
{
    public interface IConverter
    {
        string Name { get; }
        List<string> Units { get; }
        double Convert(string nazwa1, string nazwa2, double wartosc);
    }
}
