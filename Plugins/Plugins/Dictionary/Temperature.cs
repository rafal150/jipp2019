using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugins
{
    public class Temperature
    {
        public static string C = "C";
        public static string F = "F";
        public static string K = "K";
        public static string R = "R";

        public static IEnumerable<string> GetDictionary()
        {
            List<string> list = new List<string>();
            list.Add(Temperature.C);
            list.Add(Temperature.F);
            list.Add(Temperature.K);
            list.Add(Temperature.R);

            return list;
        }
    }
}
