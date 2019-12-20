using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.SDK;

namespace WpfApp1.Logic
{
    class WeightMeasure : IGetMeasures
    {
        private string nam => "weight";
        public string Nam { get => nam; }
        public List<string> Units => new List<string>(new[] { "kilogram", "gram" , "decagram" , "tonne" , "ounce" , "pound" 
            , "carat", "quintal"});
        public double Convert(string from, string to, double value_from)
        {
            switch (from)
            {
                case "kilogram":
                    //value_from *= 1;
                    break;
                case "gram":
                    value_from *= 0.001;
                    break;
                case "decagram":
                    value_from *= 0.01;
                    break;
                case "tonne":
                    value_from *= 1000;
                    break;
                case "ounce":
                    value_from *= 0.02834952981;
                    break;
                case "pound":
                    value_from *= 0.45359237;
                    break;
                case "carat":
                    value_from *= 0.0002;
                    break;
                case "quintal":
                    value_from *= 100;
                    break;
            }
            switch (to)
            {
                case "kilogram":
                    //value_from /= 1;
                    break;
                case "gram":
                    value_from /= 0.001;
                    break;
                case "decagram":
                    value_from /= 0.01;
                    break;
                case "tonne":
                    value_from /= 1000;
                    break;
                case "ounce":
                    value_from /= 0.02834952981;
                    break;
                case "pound":
                    value_from /= 0.45359237;
                    break;
                case "carat":
                    value_from /= 0.0002;
                    break;
                case "quintal":
                    value_from /= 100;
                    break;
            }

            return value_from;
        }
    }
}
