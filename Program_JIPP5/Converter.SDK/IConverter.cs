
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Converter
{
    public interface IConverter
    {
        string Name { get; }
        List<string> Units { get; }

        decimal Convert(string unitFrom, string unitTo, decimal value);
    }
}