using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Przelicznik_Jednostek.Services
{
    public class LenghtConverter : iKonwerter
    {
        public string Name => "Długości";

        public List<string> Units => new List<string>(new[] { "mm", "cm", "dcm", "m", "km", "cali", "stóp", "jardów", "mil", "kabli", "mil morskich" });

        public static decimal[] lMultiplier = new decimal[] { 1000, 100, 10, 1, 0.001M, 39.37M, 3.28M, 1.09M, 0.0006M, 0.0054M, 0.0005M };

        public decimal Convert(string unitFrom, string unitTo, decimal value)
        {
            decimal k1 = 0.0M, k2 = 0.0M;

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

