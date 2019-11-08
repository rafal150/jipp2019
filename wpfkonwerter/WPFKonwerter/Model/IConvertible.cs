using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFKonwerter.Model
{
    public interface IConvertible
    {
        string Convert(int indexFrom, int indexTo, double value);
    }
}
