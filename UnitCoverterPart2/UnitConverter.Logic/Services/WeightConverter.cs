using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitCoverterPart2.Services
{
    public class WeightConverter : IConverter
    {
        public string Name => "Masy";

        public List<string> Units => new List<string>(new[] { "mg", "g", "dkg", "kg", "T", "uncja", "funt", "karat", "kwintal" });

        public double Convert(string unitFrom, string unitTo, double value)
        {
            //MILIGRAMY NA INNE JEDNOSTKI
            if (unitFrom == "mg" && unitTo == "mg")        //mg na mg
            {

                value = (value * 1);

            }

            if (unitFrom == "mg" && unitTo == "g")        //mg na g
            {

                value = (value * 0.001);

            }

            if (unitFrom == "mg" && unitTo == "dkg")        //mg na dkg
            {

                value = (value * 0.0001);

            }

            if (unitFrom == "mg" && unitTo == "kg")        //mg na kg
            {

                value = (value * 0.000001);

            }

            if (unitFrom == "mg" && unitTo == "T")        //mg na tone
            {

                value = (value * 0.000000001);

            }

            if (unitFrom == "mg" && unitTo == "uncja")        //mg na uncje
            {

                value = (value * 0.000035274);

            }

            if (unitFrom == "mg" && unitTo == "funt")        //mg na funt
            {

                value = (value * 0.0000022);

            }

            if (unitFrom == "mg" && unitTo == "karat")        //mg na karaty
            {

                value = (value * 0.00488);

            }

            if (unitFrom == "mg" && unitTo == "kwintal")        //mg na kwintale
            {

                value = (value * 0.00000001);

            }

            //GRAMY NA INNE JEDNOSTKI
            if (unitFrom == "g" && unitTo == "mg")        //g na mg
            {

                value = (value * 1000);

            }

            if (unitFrom == "g" && unitTo == "g")        //g na g
            {

                value = (value * 1);

            }

            if (unitFrom == "g" && unitTo == "dkg")        //g na dkg
            {

                value = (value * 0.1);

            }

            if (unitFrom == "g" && unitTo == "kg")        //g na kg
            {

                value = (value * 0.001);

            }

            if (unitFrom == "g" && unitTo == "T")        //g na Tone
            {

                value = (value * 0.000001);

            }

            if (unitFrom == "g" && unitTo == "funt")        //g na funt
            {

                value = (value * 0.0022);

            }

            if (unitFrom == "g" && unitTo == "uncja")        //g na uncje
            {

                value = (value * 0.03527);

            }

            if (unitFrom == "g" && unitTo == "karat")        //g na karaty
            {

                value = (value * 5);

            }

            if (unitFrom == "g" && unitTo == "kwintal")        //g na kwintale
            {

                value = (value * 0.00001);

            }

            //DEKAGRAMY NA INNE JEDNOSTKI
            if (unitFrom == "dkg" && unitTo == "mg")        //dkg na mg
            {

                value = (value * 10000);

            }

            if (unitFrom == "dkg" && unitTo == "g")        //dkg na g
            {

                value = (value * 10);

            }

            if (unitFrom == "dkg" && unitTo == "dkg")        //dkg na dkg
            {

                value = (value * 1);

            }

            if (unitFrom == "dkg" && unitTo == "kg")        //dkg na kg
            {

                value = (value * 0.01);

            }

            if (unitFrom == "dkg" && unitTo == "T")        //dkg na tone
            {

                value = (value * 0.00001);

            }

            if (unitFrom == "dkg" && unitTo == "funt")        //dkg na funt
            {

                value = (value * 0.022);

            }

            if (unitFrom == "dkg" && unitTo == "uncja")        //dkg na uncje
            {

                value = (value * 0.3527);

            }

            if (unitFrom == "dkg" && unitTo == "karat")        //dkg na karaty
            {

                value = (value * 50);

            }

            if (unitFrom == "dkg" && unitTo == "kwintal")        //dkg na kwintale
            {

                value = (value * 0.0001);

            }

            //KILOGRAMY NA INNE JEDNOSTKI
            if (unitFrom == "kg" && unitTo == "mg")        //kg na mg
            {

                value = (value * 1000000);

            }

            if (unitFrom == "kg" && unitTo == "g")        //kg na g
            {

                value = (value * 1000);

            }

            if (unitFrom == "kg" && unitTo == "dkg")        //kg na dkg
            {

                value = (value * 100);

            }

            if (unitFrom == "kg" && unitTo == "kg")        //kg na kg
            {

                value = (value * 1);

            }

            if (unitFrom == "kg" && unitTo == "T")        //kg na tone
            {

                value = (value * 0.001);

            }

            if (unitFrom == "kg" && unitTo == "funt")        //kg na funt
            {

                value = (value * 2.2046);

            }

            if (unitFrom == "kg" && unitTo == "uncja")        //kg na uncje
            {

                value = (value * 35.274);

            }

            if (unitFrom == "kg" && unitTo == "karat")        //kg na karaty
            {

                value = (value * 5000);

            }

            if (unitFrom == "kg" && unitTo == "kwintal")        //kg na kwintale
            {

                value = (value * 0.01);

            }

            //TONY NA INNE JEDNOSTKI
            if (unitFrom == "T" && unitTo == "mg")        //tona na mg
            {

                value = (value * 1000000000);

            }

            return value;
        }
    }
}
