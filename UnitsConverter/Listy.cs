using CommonMark.Syntax;
using DocumentFormat.OpenXml.Office2010.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitsConverter
{
     class Listy

    {
        public static List<string>TypeList = new List<string>(new[] { "temperatura", "długość", "masa" });

        public static List<string>TempList = new List<string>(new[] { "C", "K", "F", "R" });
        public static List<string>Longlist = new List<string>(new[] { "mm","cm","dm","m","km","cal","stopa","jard","mila","kabel","mila morska" });
        public static List<string> WageList = new List<string>(new[] { "mg","g","dg","kg","T","uncja","funt","karat","kwintal" });
       protected static string[]  lengthUnits = new string[] { "mm", "cm", "dm", "m", "km", "cal", "stopa", "jard", "mila", "kabel", "mila morska" };
       protected static decimal[]  length = new decimal[] { 1000, 100, 10, 1, 0.001M, 39.3701M, 3.2808M, 1.0936M, 0.0006M, 0.0054M, 0.0006M };
        protected static string[] weightUnits = new string[] { "mg", "g", "dkg", "kg", "T", "uncja", "funt", "karat", "kwintal" };
        protected static decimal[] weight = new decimal[] { 1000000, 1000, 100, 1, 0.001M, 35.273962M, 2.204623M, 4999.999985M, 0.01M };
    }
    
}
