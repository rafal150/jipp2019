using System.Collections.Generic;

namespace JIPP5.SDK
{
    public interface IKonwerter
    {
        string Nazwa { get; }
        List<string> JakieJednostki { get; }

        decimal Converter(string UnitType, decimal Result, string UnitTo);
    }
}