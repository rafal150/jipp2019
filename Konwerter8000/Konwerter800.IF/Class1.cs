using System.Collections.Generic;

namespace Konwerter8000.Konwersje
{
    public interface IKonwerter8000
    {
        string NazwaKategorii { get; }
        List<string> Jednostki { get; }

        double Konwertuj(string zJednostki, string doJednostki, double wartosc);
    }
}
