using System;
using System.Collections.Generic;
using System.Text;

namespace Plugins
{
    public class Voltage
    {
        public static string mv = "mv";
        public static string v = "v";
        public static string kv = "kv";

        public static IEnumerable<string> GetDictionary()
        {
            List<string> list = new List<string>();
            list.Add(Voltage.mv);
            list.Add(Voltage.v);
            list.Add(Voltage.kv);

            return list;
        }
    }
}
