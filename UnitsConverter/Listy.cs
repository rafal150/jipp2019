using CommonMark.Syntax;
using DocumentFormat.OpenXml.Office2010.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitsConverter
{
   static  class Listy

    {
        public static List<string>TypeList = new List<string>(new[] { "temperatura", "długość", "masa" });

        public static List<string>TempList = new List<string>(new[] { "C", "K", "F", "R" });
        public static List<string>Longlist = new List<string>(new[] { "mm","cm","dm","m","km","cal","stopa","jard","mila","kabel","mila morska" });
        public static List<string> WageList = new List<string>(new[] { "mg","g","dg","kg","T","uncja","funt","karat","kwintal" });

    }
}
