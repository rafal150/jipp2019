using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter.Services
{
    public class PredkoscKonwerter : IKonwerter
    {
        public string Name => "Predkosc: m/s, fps";

        public List<string> Units => new List<string>(new[] { "m/s", "fps" });


        public double Convert(string unitFrom, string unitTo, double value)
        {
            if (unitFrom == "m/s" && unitTo == "fps")
            {
                return value * 3.2808;
            }
            else if (unitFrom == "fps" && unitTo == "m/s")
            {
                return value * 0.3048;
            }
            else
                return value;
        }
    }

}
