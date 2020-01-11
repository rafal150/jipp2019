using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugins
{
    public class Weight
    {
        public static string mg = "mg";
        public static string g = "g";
        public static string dkg = "dkg";
        public static string kg = "kg";
        public static string T = "tona";
        public static string lbs = "funt";
        public static string oz = "uncja";
        public static string ct = "karat";
        public static string q = "kwintal";

        public static IEnumerable<string> GetDictionary()
        {
            List<string> list = new List<string>();
            list.Add(Weight.mg);
            list.Add(Weight.g);
            list.Add(Weight.dkg);
            list.Add(Weight.kg);
            list.Add(Weight.T);
            list.Add(Weight.lbs);
            list.Add(Weight.oz);
            list.Add(Weight.ct);
            list.Add(Weight.q);

            return list;
        }
    }
}
