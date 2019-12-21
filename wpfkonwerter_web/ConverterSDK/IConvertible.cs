using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterSDK
{
    public interface IConvertible
    {
        string ConverterName { get; }
        List<string> Units { get; }
        string Convert(int indexFrom, int indexTo, double value);
    }
}
