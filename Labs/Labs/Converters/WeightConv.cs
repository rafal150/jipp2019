using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Labs.Converters
{
    public class WeightConv : IConverter
    {
        public string Name => "Waga";

        public List<string> Units => new List<string>(new[] { "mg", "g", "dkg", "kg", "T" }); //, "uncja", "funt", "karat", "kwintal" });

        public double Convert(string from, string to, double value)
        {
            switch (from)
            {
                case "mg":

                    if (to == "mg")
                    {
                        //value = value;
                    }
                    else if (to == "g")
                    {
                        value = value / 1000;
                    }
                    else if (to == "dkg")
                    {
                        value = value / 10000;
                    }
                    else if (to == "kg")
                    {
                        value = value / 1000000;
                    }
                    else if (to == "T")
                    {
                        value = value / 1000000000;
                    }

                    break;

                case "g":

                    if (to == "mg")
                    {
                        value = value * 1000;
                    }
                    else if (to == "g")
                    {
                        //value = value;
                    }
                    else if (to == "dkg")
                    {
                        value = value / 10;
                    }
                    else if (to == "kg")
                    {
                        value = value / 1000;
                    }
                    else if (to == "T")
                    {
                        value = value / 100000;
                    }

                    break;

                case "dkg":

                    if (to == "mg")
                    {
                        value = value * 10000;
                    }
                    else if (to == "g")
                    {
                        value = value * 10;
                    }
                    else if (to == "dkg")
                    {
                        //value = value;
                    }
                    else if (to == "kg")
                    {
                        value = value / 10;
                    }
                    else if (to == "T")
                    {
                        value = value / 10000;
                    }

                    break;

                case "kg":

                    if (to == "mg")
                    {
                        value = value * 1000000;
                    }
                    else if (to == "g")
                    {
                        value = value * 1000;
                    }
                    else if (to == "dkg")
                    {
                        value = value * 100;
                    }
                    else if (to == "kg")
                    {
                        //value = value;
                    }
                    else if (to == "T")
                    {
                        value = value / 1000;
                    }

                    break;

                case "T":

                    if (to == "mg")
                    {
                        value = value * 1000000000;
                    }
                    else if (to == "g")
                    {
                        value = value * 1000000;
                    }
                    else if (to == "dkg")
                    {
                        value = value * 100000;
                    }
                    else if (to == "kg")
                    {
                        value = value * 1000;
                    }
                    else if (to == "T")
                    {
                        //value = value;
                    }

                    break;

            }


            return value;
        }
    }
}
