using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterLogic
{
    public interface IConverter
    {
        List<string> GetKeysFrom();
        List<string> GetKeysTo(string from);
        void AddConvertion(string from, string to, Func<double, double> func);
        double Convert(String from, String to, double value);
    }
}
