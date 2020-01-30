using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter.Services
{
    public class MiaryMorskieKonwerter : IKonwerter
    {
        public string Name => "Miary Morskie: kabel, mila morska";

        public List<string> Units => new List<string>(new[] { "kabel", "mila morska"});


        public double Convert(string unitFrom, string unitTo, double value)
        {
            if (unitFrom == "kabel" && unitTo == "mila morska")
            {
                return value * 0.1;
            }
            else if (unitFrom == "mila morska" && unitTo == "kabel")
            {
                return value * 10;
            }
                return value;
        }
    }

}
