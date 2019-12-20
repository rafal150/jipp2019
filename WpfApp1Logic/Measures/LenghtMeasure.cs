using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.SDK;

namespace WpfApp1.Logic
{
    public class LenghtMeasure : IGetMeasures
    {
        public string Nam => "lenght";
        public List<string> Units => new List<string>(new[] { "metre", "decymetre", "centymetre" , "milimetre" 
            , "kilometre" , "nautical mile" , "cable" , "inch", "foot", "yard","mile"});
        public double Convert( string from, string to, double value_from)
        {
            switch (from)
            {
                case "metre":
                    //value_from *= 1;
                    break;
                case "decymetre":
                    value_from *= 0.1;
                    break;
                case "centymetre":
                    value_from *= 0.01;
                    break;
                case "milimetre":
                    value_from *= 0.001;
                    break;
                case "kilometre":
                    value_from *= 1000;
                    break;
                case "nautical mile":
                    value_from *= 1852;
                    break;
                case "cable":
                    value_from *= 185.2;
                    break;
                case "inch":
                    value_from *= 0.0254;
                    break;
                case "foot":
                    value_from *= 0.30480;
                    break;
                case "yard":
                    value_from *= 0.9144;
                    break;
                case "mile":
                    value_from *= 1609.344;
                    break;
            }
            switch (to)
            {
                case "metre":
                    //value_from /= 1;
                    break;
                case "decymetre":
                    value_from /= 0.1;
                    break;
                case "centymetre":
                    value_from /= 0.01;
                    break;
                case "milimetre":
                    value_from /= 0.001;
                    break;
                case "kilometre":
                    value_from /= 1000;
                    break;
                case "nautical mile":
                    value_from /= 1852;
                    break;
                case "cable":
                    value_from /= 185.2;
                    break;
                case "inch":
                    value_from /= 0.0254;
                    break;
                case "foot":
                    value_from /= 0.30480;
                    break;
                case "yard":
                    value_from /= 0.9144;
                    break;
                case "mile":
                    value_from /= 1609.344;
                    break;
            }

            return value_from;
        }
    }
}
