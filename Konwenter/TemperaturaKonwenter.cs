using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwenter
{


    class TemperaturaKonwenter
    {

        public double C;
        public string Konwersja(double input, string unit1, string unit2)
        {

            
            double result;

            //convert to C

            switch (unit1)
            {
                case "C":
                    C = input;
                    break;
                case "F":
                    C = (input - 32) / 1.8;
                    break;
                case "R":
                    C = (input / 1.8) - 273.15;
                    break;
                case "K":
                    C = input - 273.15;
                    break;
            }




            //Convert C to unit2


            if (unit2 == unit1)
            {
                result = input;
            }
            else if (unit2 == "C")
            {
                result = C;
            }
            else if (unit2 == "K")
            {
                result = C + 273.15;
            }
            else if (unit2 == "R")
            {
                result = (C + 273.15) * 1.8;
            }
            else if (unit2 == "F")
            {
                result = (C * 1.8) + 32;
            }
            else
            {
                result = input;
            }


            return result + unit2;
        }

    }
}
