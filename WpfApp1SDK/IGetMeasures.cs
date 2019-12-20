using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.SDK
{
    public interface IGetMeasures
    {
        string Nam{ get; }
        List<String>Units { get; }
        double Convert(string from, string to, double amount);

    }
}
