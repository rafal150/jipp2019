using System.Collections.Generic;

namespace Konwerter_Azure.Services
{
    public interface IConverter // interfejs do konwertreow
    {
        string Nazwa { get; }
        List<string> Jednostki { get; }
        decimal Przelicz(string jednostkiZ, string jednostkiNa, decimal wartosc); //decimal Convert(string unitFrom, string unitTo, decimal value);
    }
}