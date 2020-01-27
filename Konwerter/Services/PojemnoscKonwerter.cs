using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter.Services
{
    public class PojemnoscKonwerter : IKonwerter
    {
        public string Name => "Pojemność";

        public List<string> Units => new List<string>(new[] { "B", "kB", "MB" });


        public double Convert(string unitFrom, string unitTo, double value)
        {
            int idVal_1 = 0;
            double toConvert = 0;
            double resultConvert = 0;

            if (unitFrom == "B")
            {
                idVal_1 = 1;
            }
            else if (unitFrom == "kB")
            {
                idVal_1 = 2;
            }
            else if (unitFrom == "MB")
            {
                idVal_1 = 3;
            }

            int idVal_2 = 0;

            if (unitTo == "B")
            {
                idVal_2 = 1;
            }
            else if (unitTo == "kB")
            {
                idVal_2 = 2;
            }
            else if (unitTo == "MB")
            {
                idVal_2 = 3;
            }

            //przekonwertowanie pierwotnej wartości
            if (idVal_1 == 1)
            {
                toConvert = value;
            }
            if (idVal_1 == 2)
            {
                toConvert = kBToB(value);
            }
            if (idVal_1 == 3)
            {
                toConvert = MBToB(value);
            }

            if (idVal_2 == 1)
            {
                resultConvert = toConvert;
            }
            if (idVal_2 == 2)
            {
                resultConvert = BTokB(toConvert);
            }
            if (idVal_2 == 3)
            {
                resultConvert = BToMB(toConvert);
            }


            return resultConvert;
        }

        public double kBToB(double pojemnosc)
        {
            pojemnosc = pojemnosc * 1000;
            return pojemnosc;
        }
        public double MBToB(double pojemnosc)
        {
            pojemnosc = pojemnosc * 1000000;
            return pojemnosc;
        }
        public double BTokB(double pojemnosc)
        {
            pojemnosc = pojemnosc / 1000;
            return pojemnosc;
        }
        public double BToMB(double pojemnosc)
        {
            pojemnosc = pojemnosc / 1000000;
            return pojemnosc;
        }

    }

}
