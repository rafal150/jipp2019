using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter.Services
{
    public interface IConverting
    {
        string Nazwa { get; }
        List<String> ListaJednostek { get; }
        float Convert(string from, string to, double amount);
    }
}
