using System.Collections.Generic;

namespace KonwerterZSQLiAZUREiPLUGIN.Services
{
    public interface IKonwerter
    {
        string Name { get; }
        List<string> Units { get; }
        decimal Convert(string unitFrom, string unitTo, decimal value);
    }
}