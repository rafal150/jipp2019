using System;
using System.Collections.Generic;

namespace Konwerter.Serwisy
{
    public interface IKonwerter
    {
        string Nazwa { get; }
        List<string> Jednostki { get; }
        decimal Konwertuj(int unitFrom, int unitTo, double value);
    }
}
