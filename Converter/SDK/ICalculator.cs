using System;
using System.Collections.Generic;
using System.Text;

namespace Converter.Calculator
{
    public interface ICalculator
    {
        string Name { get; }
        List<string> Units { get; }
        decimal Convert(string unitFrom, string unitTo, decimal value);
    }
}
