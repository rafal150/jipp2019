using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitCoverterPart2.Services;

namespace IloscPlugin
{
    class IloscConverter : IConverter
    {
        public string Name => "Ilości";

        public List<string> Units => new List<string>(new[] { "sztuka", "tuzin", "mendel" });

        public double Convert(string unitFrom, string unitTo, double value)
        {
            if (unitFrom == "sztuka" && unitTo == "tuzin")        //kg na tone
            {
                value = value / 12;

            }
            if (unitFrom == "sztuka" && unitTo == "mendel")        //kg na tone
            {
                value = value / 15;

            }
            if (unitFrom == "tuzin" && unitTo == "sztuka")        //kg na tone
            {
                value = value * 12;

            }
            if (unitFrom == "tuzin" && unitTo == "mendel")        //kg na tone
            {
                value = value * 8 / 10;

            }
            if (unitFrom == "mendel" && unitTo == "sztuka")        //kg na tone
            {
                value = value * 15;

            }
            if (unitFrom == "mendel" && unitTo == "tuzin")        //kg na tone
            {
                value = value * 5 / 4;

            }
            return value;
        }
        }

}
