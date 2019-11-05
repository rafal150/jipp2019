using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwenter
{
    class MasaKonwenter
    {

        public double kg;
        public string Konwersja(double input, string unit1, string unit2)
        {


            double result;

            //convert to kg 

            switch (unit1)
            {
                case "mg":
                    kg = input * 0.000001;
                    break;
                case "g":
                    kg = input * 0.001;
                    break;
                case "dkg":
                    kg = input * 0.01;
                    break;
                case "kg":
                    kg = input;
                    break;
                case "T":
                    kg = input * 1000;
                    break;
                case "uncja":
                    kg = input * 0.028349523;
                    break;
                case "funt":
                    kg = input * 0.45359237;
                    break;
                case "karat":
                    kg = input * 0.0002;
                    break;
                case "kwintal":
                    kg = input * 100;
                    break;
            }




            //Convert kg to unit2


            if (unit2 == unit1)
            {
                result = input;
            }
            else if (unit2 == "mg")
            {
                result = kg * 1000000;
            }
            else if (unit2 == "g")
            {
                result = kg * 1000;
            }
            else if (unit2 == "dkg")
            {
                result = kg * 100;
            }
            else if (unit2 == "kg")
            {
                result = kg;
            }
            else if (unit2 == "T")
            {
                result = kg * 0.0001;
            }
            else if (unit2 == "uncja")
            {
                result = kg * 35.274;
            }
            else if (unit2 == "funt")
            {
                result = kg * 2.2046;
            }
            else if (unit2 == "karat")
            {
                result = kg * 5000;
            }
            else if (unit2 == "kwintal")
            {
                result = kg * 0.01;
            }
            else
            {
                result = input;
            }


            return result + unit2;
        }


    }
}
