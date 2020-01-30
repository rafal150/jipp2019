using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter.Services
{
    public class IloscKonwerter : IKonwerter
    {
        public string Name => "Ilość";

        public List<string> Units => new List<string>(new[] { "Szt", "Kopa"});


        public double Convert(string unitFrom, string unitTo, double value)
        {
            double toConvert = 0;
            double resultConvert = 0;


            //przekonwertowanie pierwotnej wartości
            if (unitFrom == "Szt")
            {
                toConvert = value;
            }
            if (unitFrom == "Kopa")
            {
                toConvert = KopaToSzt(value);
            }

            if (unitTo == "Szt")
            {
                resultConvert = toConvert;
            }
            if (unitTo == "Kopa")
            {
                resultConvert = SztToKopa(toConvert);
            }


            return resultConvert;
        }

        public double SztToKopa(double ilosc)
        {
            ilosc = ilosc / 60;
            return ilosc;
        }
        public double KopaToSzt(double ilosc)
        {
            ilosc = ilosc * 60;
            return ilosc;
        }

    }

}
