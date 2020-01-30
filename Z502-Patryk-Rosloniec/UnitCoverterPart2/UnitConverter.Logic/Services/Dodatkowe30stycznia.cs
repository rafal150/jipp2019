using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitCoverterPart2.Services
{
    class Dodatkowe30stycznia : IConverter
    {

        public string Name => "Powierzchnia";

        public List<string> Units => new List<string>(new[] { "metrkwadrat", "kilometrkwadrat"});

        public static double[] lMultiplier = new double[] { 1, 0.000001 };

        public double Convert(string unitFrom, string unitTo, double value)
        {
            double k1 = 0.0, k2 = 0.0;

            int i = 0;

            foreach (string s in Units)
            {
                if (unitFrom == s)
                    k1 = lMultiplier[i];
                if (unitTo == s)
                    k2 = lMultiplier[i];

                i += 1;

            }


            return k2 * value / k1;

        }

    }
}
