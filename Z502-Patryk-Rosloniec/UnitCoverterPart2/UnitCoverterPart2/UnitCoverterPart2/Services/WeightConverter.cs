using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitCoverterPart2.Services
{
    public class WeightConverter : IConverter
    {
        public string Name => "Masy";

        public List<string> Units => new List<string>(new[] { "mg", "g", "dkg", "kg", "T", "uncji", "funtów", "karatów", "kwintali" });

        public static double[] wMultiplier = new double[] { 1000000, 1000, 100, 1, 0.001, 35.27, 2.20, 5000, 0.01 };

        public double Convert(string unitFrom, string unitTo, double value)
        {

            double k1 = 0.0, k2 = 0.0;

            int i = 0;

            foreach (string s in Units)
            {
                if (unitFrom == s)
                   k1 = wMultiplier[i];
                if (unitTo == s)
                    k2 = wMultiplier[i];

                i += 1;

            }


            return k2 * value / k1;
            


           
        }
    }
}
