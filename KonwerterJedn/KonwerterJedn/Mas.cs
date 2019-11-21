using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterJedn
{
    class Mas : IConverter
    {
       // public string valueFrom;
       // public string valueTo;
        // public double myValue;
      //  public double Wartosc; //value
        public string Type = "Masa";


        public string Nazwa => "Masa";

        public List<string> Jednostki => new List<string>(new[] { "mg", "g", "dkg", "kg", "t", "uncja", "funt", "karat", "kwintal" });

        public double Convert(string unitFrom, string unitTo, double Wartosc)
        {
            if (unitFrom == "mg" && unitTo == "mg")
            {
                return Wartosc;
            }
            else if (unitFrom == "mg" && unitTo == "g")
            {
                Wartosc = (Wartosc * 0.001);
                return Wartosc;
            }
            else if (unitFrom == "mg" && unitTo == "dkg")
            {
                Wartosc = (Wartosc * 0.0001);
                return Wartosc;
            }
            else if (unitFrom == "mg" && unitTo == "kg")
            {
                Wartosc = (Wartosc * 0.000001);
                return Wartosc;
            }
            else if (unitFrom == "mg" && unitTo == "t")
            {
                Wartosc = (Wartosc * 0.000000001);
                return Wartosc;
            }
            else if (unitFrom == "mg" && unitTo == "uncja")
            {
                Wartosc = (Wartosc * 0.000035274);
                return Wartosc;
            }
            else if (unitFrom == "mg" && unitTo == "funt")
            {
                Wartosc = (Wartosc * 0.0000022046);
                return Wartosc;
            }
            else if (unitFrom == "mg" && unitTo == "karat")
            {
                Wartosc = (Wartosc * 0.005);
                return Wartosc;
            }
            else if (unitFrom == "mg" && unitTo == "kwintal")
            {
                Wartosc = (Wartosc * 0.00000001);
                return Wartosc;
            }

            ///////////g////////////
            else if (unitFrom == "g" && unitTo == "g")
            {
                return Wartosc;
            }
            else if (unitFrom == "g" && unitTo == "mg")
            {
                Wartosc = (Wartosc * 1000);
                return Wartosc;
            }
            else if (unitFrom == "g" && unitTo == "dkg")
            {
                Wartosc = (Wartosc * 0.1);
                return Wartosc;
            }
            else if (unitFrom == "g" && unitTo == "kg")
            {
                Wartosc = (Wartosc * 0.001);
                return Wartosc;
            }
            else if (unitFrom == "g" && unitTo == "t")
            {
                Wartosc = (Wartosc * 0.000001);
                return Wartosc;
            }

            else if (unitFrom == "g" && unitTo == "uncja")
            {
                Wartosc = (Wartosc * 0.0353);
                return Wartosc;
            }
            else if (unitFrom == "g" && unitTo == "funt")
            {
                Wartosc = (Wartosc * 0.0022);
                return Wartosc;
            }
            else if (unitFrom == "g" && unitTo == "karat")
            {
                Wartosc = (Wartosc * 5);
                return Wartosc;
            }
            else if (unitFrom == "g" && unitTo == "kwintal")
            {
                Wartosc = (Wartosc * 0.00001);
                return Wartosc;
            }



            ////dkg/////
            else if (unitFrom == "dkg" && unitTo == "dkg")
            {
                return Wartosc;
            }
            else if (unitFrom == "dkg" && unitTo == "g")
            {
                Wartosc = (Wartosc * 10000);
                return Wartosc;
            }
            else if (unitFrom == "dkg" && unitTo == "mg")
            {
                Wartosc = (Wartosc * 10);
                return Wartosc;
            }
            else if (unitFrom == "dkg" && unitTo == "kg")
            {
                Wartosc = (Wartosc * 0.01);
                return Wartosc;
            }
            else if (unitFrom == "dkg" && unitTo == "t")
            {
                Wartosc = (Wartosc * 0.00001);
                return Wartosc;
            }

            else if (unitFrom == "dkg" && unitTo == "uncja")
            {
                Wartosc = (Wartosc * 0.3527);
                return Wartosc;
            }
            else if (unitFrom == "dkg" && unitTo == "funt")
            {
                Wartosc = (Wartosc * 0.022);
                return Wartosc;
            }
            else if (unitFrom == "dkg" && unitTo == "karat")
            {
                Wartosc = (Wartosc * 50);
                return Wartosc;
            }
            else if (unitFrom == "dkg" && unitTo == "kwintal")
            {
                Wartosc = (Wartosc * 0.0001);
                return Wartosc;
            }



            ////kg/////
            else if (unitFrom == "kg" && unitTo == "kg")
            {
                return Wartosc;
            }
            else if (unitFrom == "kg" && unitTo == "g")
            {
                Wartosc = (Wartosc * 1000000);
                return Wartosc;
            }
            else if (unitFrom == "kg" && unitTo == "mg")
            {
                Wartosc = (Wartosc * 1000);
                return Wartosc;
            }
            else if (unitFrom == "kg" && unitTo == "dkg")
            {
                Wartosc = (Wartosc * 100);
                return Wartosc;
            }
            else if (unitFrom == "kg" && unitTo == "t")
            {
                Wartosc = (Wartosc * 0.001);
                return Wartosc;
            }

            else if (unitFrom == "kg" && unitTo == "uncja")
            {
                Wartosc = (Wartosc * 35.274);
                return Wartosc;
            }
            else if (unitFrom == "kg" && unitTo == "funt")
            {
                Wartosc = (Wartosc * 2.2046);
                return Wartosc;
            }
            else if (unitFrom == "kg" && unitTo == "karat")
            {
                Wartosc = (Wartosc * 5000);
                return Wartosc;
            }
            else if (unitFrom == "kg" && unitTo == "kwintal")
            {
                Wartosc = (Wartosc * 0.01);
                return Wartosc;
            }




            ////t/////
            else if (unitFrom == "t" && unitTo == "t")
            {
                return Wartosc;
            }
            else if (unitFrom == "t" && unitTo == "g")
            {
                Wartosc = (Wartosc * 1.000000);
                return Wartosc;
            }
            else if (unitFrom == "t" && unitTo == "mg")
            {
                Wartosc = (Wartosc * 1.000000000);
                return Wartosc;
            }
            else if (unitFrom == "t" && unitTo == "dkg")
            {
                Wartosc = (Wartosc * 100000);
                return Wartosc;
            }
            else if (unitFrom == "t" && unitTo == "kg")
            {
                Wartosc = (Wartosc * 1000);
                return Wartosc;
            }
            else if (unitFrom == "t" && unitTo == "uncja")
            {
                Wartosc = (Wartosc * 35273.9621);
                return Wartosc;
            }
            else if (unitFrom == "t" && unitTo == "funt")
            {
                Wartosc = (Wartosc * 2204.6226);
                return Wartosc;
            }
            else if (unitFrom == "t" && unitTo == "karat")
            {
                Wartosc = (Wartosc * 5.000000);
                return Wartosc;
            }
            else if (unitFrom == "t" && unitTo == "kwintal")
            {
                Wartosc = (Wartosc * 10);
                return Wartosc;
            }



            /////uncja//////
            else if (unitFrom == "uncja" && unitTo == "uncja")
            {
                return Wartosc;
            }
            else if (unitFrom == "uncja" && unitTo == "mg")
            {
                Wartosc = (Wartosc * 28349.523);
                return Wartosc;
            }
            else if (unitFrom == "uncja" && unitTo == "g")
            {
                Wartosc = (Wartosc * 28.3495);
                return Wartosc;
            }
            else if (unitFrom == "uncja" && unitTo == "dkg")
            {
                Wartosc = (Wartosc * 2.835);
                return Wartosc;
            }
            else if (unitFrom == "uncja" && unitTo == "kg")
            {
                Wartosc = (Wartosc * 0.0283);
                return Wartosc;
            }
            else if (unitFrom == "uncja" && unitTo == "t")
            {
                Wartosc = (Wartosc * 0.00000283);
                return Wartosc;
            }
            else if (unitFrom == "uncja" && unitTo == "funt")
            {
                Wartosc = (Wartosc * 0.0625);
                return Wartosc;
            }
            else if (unitFrom == "uncja" && unitTo == "karat")
            {
                Wartosc = (Wartosc * 141.75);
                return Wartosc;
            }
            else if (unitFrom == "uncja" && unitTo == "kwintal")
            {
                Wartosc = (Wartosc * 0.0003);
                return Wartosc;
            }

            ////funt///////
            else if (unitFrom == "funt" && unitTo == "funt")
            {
                return Wartosc;
            }
            else if (unitFrom == "funt" && unitTo == "mg")
            {
                Wartosc = (Wartosc * 0.000045359);
                return Wartosc;
            }
            else if (unitFrom == "funt" && unitTo == "g")
            {
                Wartosc = (Wartosc * 453.5924);
                return Wartosc;
            }
            else if (unitFrom == "funt" && unitTo == "dkg")
            {
                Wartosc = (Wartosc * 45.3592);
                return Wartosc;
            }
            else if (unitFrom == "funt" && unitTo == "kg")
            {
                Wartosc = (Wartosc * 0.4536);
                return Wartosc;
            }
            else if (unitFrom == "funt" && unitTo == "uncja")
            {
                Wartosc = (Wartosc * 16);
                return Wartosc;
            }
            else if (unitFrom == "funt" && unitTo == "t")
            {
                Wartosc = (Wartosc * 0.0005);
                return Wartosc;
            }
            else if (unitFrom == "funt" && unitTo == "karat")
            {
                Wartosc = (Wartosc * 2267.9619);
                return Wartosc;
            }
            else if (unitFrom == "funt" && unitTo == "kwintal")
            {
                Wartosc = (Wartosc * 0.0045);
                return Wartosc;
            }
            ////karat//////
            else if (unitFrom == "karat" && unitTo == "karat")
            {
                return Wartosc;
            }
            else if (unitFrom == "karat" && unitTo == "g")
            {
                Wartosc = (Wartosc * 0.2);
                return Wartosc;
            }
            else if (unitFrom == "karat" && unitTo == "mg")
            {
                Wartosc = (Wartosc * 200);
                return Wartosc;
            }
            else if (unitFrom == "karat" && unitTo == "dkg")
            {
                Wartosc = (Wartosc * 0.02);
                return Wartosc;
            }
            else if (unitFrom == "karat" && unitTo == "kg")
            {
                Wartosc = (Wartosc * 0.0002);
                return Wartosc;
            }
            else if (unitFrom == "karat" && unitTo == "uncja")
            {
                Wartosc = (Wartosc * 0.0071);
                return Wartosc;
            }
            else if (unitFrom == "karat" && unitTo == "funt")
            {
                Wartosc = (Wartosc * 0.0004);
                return Wartosc;
            }
            else if (unitFrom == "karat" && unitTo == "t")
            {
                Wartosc = (Wartosc * 0.0000002);
                return Wartosc;
            }
            else if (unitFrom == "karat" && unitTo == "kwintal")
            {
                Wartosc = (Wartosc * 0.000002);
                return Wartosc;
            }

            ////kwintal/////
            else if (unitFrom == "kwintal" && unitTo == "kwintal")
            {
                return Wartosc;
            }
            else if (unitFrom == "kwintal" && unitTo == "g")
            {
                Wartosc = (Wartosc * 100000);
                return Wartosc;
            }
            else if (unitFrom == "kwintal" && unitTo == "mg")
            {
                Wartosc = (Wartosc * 100000000);
                return Wartosc;
            }
            else if (unitFrom == "kwintal" && unitTo == "dkg")
            {
                Wartosc = (Wartosc * 100);
                return Wartosc;
            }
            else if (unitFrom == "kwintal" && unitTo == "kg")
            {
                Wartosc = (Wartosc * 1000);
                return Wartosc;
            }
            else if (unitFrom == "kwintal" && unitTo == "uncja")
            {
                Wartosc = (Wartosc * 3527.3962);
                return Wartosc;
            }
            else if (unitFrom == "kwintal" && unitTo == "funt")
            {
                Wartosc = (Wartosc * 220.4623);
                return Wartosc;
            }
            else if (unitFrom == "kwintal" && unitTo == "karat")
            {
                Wartosc = (Wartosc * 5.00000);
                return Wartosc;
            }
            else if (unitFrom == "kwintal" && unitTo == "t")
            {
                Wartosc = (Wartosc * 0.1);
                return Wartosc;
            }
            else
                return 0;
        }
        //public string PodajWartosc()
       // { return this.WartoscString; }

    }
}
