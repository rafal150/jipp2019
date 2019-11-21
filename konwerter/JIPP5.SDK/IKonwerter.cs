using System.Collections.Generic;

namespace JIPP5.SDK
{
    public interface IKonwerter
    {
        string Nazwa { get; }
        List<string> JakieJednostki { get; }

        decimal Converter(string zJednostki, decimal wartosc, string doJednostki);
    }
}