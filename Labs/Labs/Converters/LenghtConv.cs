using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace Labs.Converters
{
    public class LenghtConv : IConverter
    {
        public string Name => "Dlugosci";

        public List<string> Units => new List<string>(new[] { "mm", "cm", "dcm", "m", "km" }); //"cal", "stopa", "jard", "mila", "mila morska", "kabel" });

        public double Convert(string from, string to, double value)
        {
            switch (from)
            {
                case "mm":

                    if (to == "mm")
                    {
                        //value = value;
                    }
                    else if (to == "cm")
                    {
                        value = value / 10;
                    }
                    else if (to == "dcm")
                    {
                        value = value / 100;
                    }
                    else if (to == "m")
                    {
                        value = value / 10000;
                    }
                    else if (to == "km")
                    {
                        value = value / 1000000;
                    }

                    break;

                case "cm":

                    if (to == "mm")
                    {
                        value = value * 10;
                    }
                    else if (to == "cm")
                    {
                        //value = value;
                    }
                    else if (to == "dcm")
                    {
                        value = value / 10;
                    }
                    else if (to == "m")
                    {
                        value = value / 100;
                    }
                    else if (to == "km")
                    {
                        value = value / 100000;
                    }

                    break;

                case "dcm":

                    if (to == "mm")
                    {
                        value = value * 100;
                    }
                    else if (to == "cm")
                    {
                        value = value * 10;
                    }
                    else if (to == "dcm")
                    {
                        //value = value;
                    }
                    else if (to == "m")
                    {
                        value = value / 10;
                    }
                    else if (to == "km")
                    {
                        value = value / 10000;
                    }
                    break;

                case "m":

                    if (to == "mm")
                    {
                        value = value * 1000;
                    }
                    else if (to == "cm")
                    {
                        value = value * 100;
                    }
                    else if (to == "dcm")
                    {
                        value = value * 10;
                    }
                    else if (to == "m")
                    {
                        //value = value;
                    }
                    else if (to == "km")
                    {
                        value = value / 1000;
                    }

                    break;

                case "km":

                    if (to == "mm")
                    {
                        value = value * 1000000;
                    }
                    else if (to == "cm")
                    {
                        value = value * 100000;
                    }
                    else if (to == "dcm")
                    {
                        value = value * 10000;
                    }
                    else if (to == "m")
                    {
                        value = value * 1000;
                    }
                    else if (to == "km")
                    {
                        //value = value;
                    }
                    break;

            }

            return value;
        }
    }
}
