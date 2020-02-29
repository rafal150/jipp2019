using System.Collections.Generic;

namespace Przelicznik_Jednostek.Services
{
    public interface iKonwerter
    {
        string Name { get; }
        List<string> Units { get; }
        decimal Convert(string unitFrom, string unitTo, decimal value);
    }
}