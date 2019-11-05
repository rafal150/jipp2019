using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwenter
{
    class DlugoscKonwenter
    {

        public double M;
        public string Konwersja(double input, string unit1, string unit2)
        {


            double result;

            //convert to M

            switch (unit1)
            {
                case "mm":
                    M = 0.001 * input;
                    break;
                case "cm":
                    M = 0.01 * input;
                    break;
                case "dcm":
                    M = 0.1 * input;
                    break;
                case "m":
                    M = input;
                    break;
                case "km":
                    M = 1000 * input;
                    break;
                case "cal":
                    M = 0.0254 * input;
                    break;
                case "stop":
                    M = 0.3048 * input;
                    break;
                case "jard":
                    M = 0.9144 * input;
                    break;
                case "mila":
                    M = 1609.344 * input;
                    break;
                case "kabel":
                    M = 185.2 * input;
                    break;
                case "mila morska":
                    M = 1852 * input;
                    break;
            }




            //Convert M  to unit2


            if (unit2 == unit1)
            {
                result = input;
            }

            else if (unit2 == "mm")
            {
                result = M * 1000;
            }
            else if (unit2 == "cm")
            {
                result = M * 100;
            }
            else if (unit2 == "dcm")
            {
                result = M * 10;
            }
            else if (unit2 == "m")
            {
                result = M;
            }
            else if (unit2 == "km")
            {
                result = M * 0.001;
            }
            else if (unit2 == "cal")
            {
                result = M * 39.3701;
            }
            else if (unit2 == "stop")
            {
                result = M * 3.2808;
            }
            else if (unit2 == "jard")
            {
                result = M * 1.0936;
            }
            else if (unit2 == "mila")
            {
                result = M * 0.0006;
            }
            else if (unit2 == "kabel")
            {
                result = M * 0.0054;
            }
            else if (unit2 == "mila morska")
            {
                result = M * 0.0005;
            }
            else
            {
                result = input;
            }


            return result + unit2;
        }


    }
}
