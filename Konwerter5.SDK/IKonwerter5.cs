using System.Collections.Generic;

namespace Konwerter5
    public interface IKonwerter5
    {
        string NazwaKategorii { get; }
        List<string> Jednostki { get; }

        double Konwertuj(string zJednostki, string doJednostki, double wartosc);
    }
}
