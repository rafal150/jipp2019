using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugins
{
    public class Distance
    {
        public static string mm = "mm";
        public static string cm = "cm";
        public static string dm = "dm";
        public static string m = "m";
        public static string km = "km";
        public static string inch = "cal";
        public static string ft = "stopa";
        public static string yard = "jard";
        public static string mile = "mila";
        public static string cabel = "kabel";
        public static string nauticalMile= "mila morska";

        public static IEnumerable<string> GetDictionary()
        {
            List<string> list = new List<string>();
            list.Add(Distance.mm);
            list.Add(Distance.cm);
            list.Add(Distance.dm);
            list.Add(Distance.m);
            list.Add(Distance.km);
            list.Add(Distance.inch);
            list.Add(Distance.ft);
            list.Add(Distance.yard);
            list.Add(Distance.mile);
            list.Add(Distance.cabel);
            list.Add(Distance.nauticalMile);

            return list;
        }

    }
}
