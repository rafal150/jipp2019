using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitCoverterPart2
{
    static class AppData
    {
        public static string[] types = new string[] { "temperatura", "długość", "masa" };

        public static string[] tUnits = new string[] { "°C", "°F", "K", "°R" };

        public static string[] lUnits = new string[] { "mm", "cm", "dcm", "m", "km", "cali", "stóp", "jardów", "mil", "kabli", "mil morskich" };

        public static double[] lMultiplier = new double[] { 1000, 100, 10, 1, 0.001, 39.3700787, 3.2808399, 1.093613, 0.000621371192, 0.0054, 0.0005399999568000035 };

        public static string[] wUnits = new string[] { "mg", "g", "dkg", "kg", "T", "uncji", "funtów", "karatów", "kwintali" };

        public static double[] wMultiplier = new double[] { 1000000, 1000, 100, 1, 0.001, 35.273962, 2.204623, 4999.999985, 0.01 };
    }
}
