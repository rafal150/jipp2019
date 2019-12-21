using System.Collections.Generic;

namespace lab1
{
    public interface IKonwersja
    {
        string Nazwa { get; }
        List<string> Jednostki { get; }
       
        int Konwertuj(string z, string na, double wartosc);
    }
}