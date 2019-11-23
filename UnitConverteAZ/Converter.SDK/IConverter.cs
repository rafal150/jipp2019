using System;
using System.Collections.Generic;

namespace Converter.SDK
{
    public interface IConverter
       
    {
        string Name { get; }
        List<string> Units { get; }
        double Convert(string unitFrom, string unitTo, double value);

    }
}
