using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter.Services
{
    public class InneKonwerter : IKonwerter
    {
        public string Name => "Inne: karat, kwintal";

        public List<string> Units => new List<string>(new[] { "karat", "kwintal" });


        public double Convert(string unitFrom, string unitTo, double value)
        {
            if (unitFrom == "karat" && unitTo == "kwintal")
            {
                return value / 20000;
            }
            else if (unitFrom == "kwintal" && unitTo == "karat")
            {
                return value * 50000;
            }
            return value;
        }
    }

}
