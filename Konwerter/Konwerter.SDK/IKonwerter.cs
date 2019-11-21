using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter.SDK
{
    public interface IKonwerter
    {
        string Typ { get; }
        List<string> Jednostki { get; }
        double Przelicz(string fromType, string toType, double value);
    }
}
