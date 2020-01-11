using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugins
{
    public class General
    {
        public static string temperature = "Temperatura";
        public static string distance = "Dystans";
        public static string weight = "Cięzar";
        public static string voltage = "Napięcie";



        /*public static List<string> GetGeneralDictionary()
        {
            List<string> generalList = new List<string>();
            generalList.Add(General.temperature);
            generalList.Add(General.distance);
            generalList.Add(General.weight);
            generalList.Add(General.voltage);
            return generalList;
        }*/

        public static IEnumerable<string> GetGeneralDictionary()
        {
            List<string> generalList = new List<string>();
            generalList.Add(General.temperature);
            generalList.Add(General.distance);
            generalList.Add(General.weight);
            generalList.Add(General.voltage);
            return generalList;
        }

    }
}
