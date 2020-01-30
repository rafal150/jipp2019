using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter.Services
{
    public class MiaryAnglosaskieKonwerter : IKonwerter
    {
        public string Name => "Miary Anglosaskie: cal, stopa, jard, mila";

        public List<string> Units => new List<string>(new[] { "cal", "stopa", "jard", "mila"});

        public double Convert(string unitFrom, string unitTo, double value)
        {
            if (unitFrom == "cal" && unitTo == "stop")
            {
                return value * 0.08;
            }
            else if (unitFrom == "cal" && unitTo == "jard")
            {
                return value * 0.03;
            }
            else if (unitFrom == "cal" && unitTo == "mila")
            {
                return value * 1500;
            }
            else if (unitFrom == "stopa" && unitTo == "cal")
            {
                return value * 12;
            }
            else if (unitFrom == "stopa" && unitTo == "jard")
            {
                return value * 0.33;
            }
            else if (unitFrom == "stopa" && unitTo == "mila")
            {
                return value * 18400;
            }
            else if (unitFrom == "jard" && unitTo == "mila")
            {
                return value * 586;
            }
            else if (unitFrom == "jard" && unitTo == "cal")
            {
                return value * 36;
            }
            else if (unitFrom == "jard" && unitTo == "stopa")
            {
                return value * 3;
            }
            else if (unitFrom == "mila" && unitTo == "jard")
            {
                return value * 1760;
            }
            else if (unitFrom == "mila" && unitTo == "cal")
            {
                return value * 63360;
            }
            else if (unitFrom == "mila" && unitTo == "stopa")
            {
                return value * 5280;
            }
            else
                return value;
        }
    }
}

