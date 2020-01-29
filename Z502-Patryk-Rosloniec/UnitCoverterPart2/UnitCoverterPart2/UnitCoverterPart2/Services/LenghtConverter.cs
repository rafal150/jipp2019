using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitCoverterPart2.Services
{
    public class LenghtConverter : IConverter
    {
        public string Name => "Długości";

        public List<string> Units => new List<string>(new[] { "mm", "cm", "dcm", "m", "km", "cali", "stóp", "jardów", "mil", "kabli", "mil morskich" });

        public static double[] lMultiplier = new double[] { 1000, 100, 10, 1, 0.001, 39.37, 3.28, 1.09, 0.0006, 0.0054, 0.0005 };

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
