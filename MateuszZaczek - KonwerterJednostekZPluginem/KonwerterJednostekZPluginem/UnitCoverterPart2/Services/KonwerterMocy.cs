using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterZSQLiAZUREiPLUGIN.Services
{
    public class KonwerterMocy : KonwerterInterfejs
    {
        public string Name => "MocPlugin";

        public List<string> Units => new List<string>(new[] { "kW", "KM" });

        public decimal Konwerter(string unitFrom, string unitTo, decimal value)
        {
            return value * 2;
        }
    }
}
