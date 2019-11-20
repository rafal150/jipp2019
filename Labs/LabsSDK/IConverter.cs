using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Labs.Converters
{
    public interface IConverter
    {
        string Name { get; }
        List<string> Units { get; }
        double Convert(string from, string to, double value);
    }
}
