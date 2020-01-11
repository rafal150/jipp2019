using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Units_Converter.Services
{
    public interface IConverter
    {
        string Name { get; }
        List<string> Units { get; }
        decimal Convert(string unitFromS, string unitTo, decimal value);
    }
}
