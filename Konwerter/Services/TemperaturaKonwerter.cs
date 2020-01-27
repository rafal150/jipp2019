using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter.Services
{
    public class TemperaturaKonwerter : IKonwerter
    {
        public string Name => "Temperatura";

        public List<string> Units => new List<string> (new[] { "C", "F", "K", "R" });


        public double Convert(string unitFrom, string unitTo, double value)
        {
            int idVal_1 = 0;
            double toConvert = 0;
            double resultConvert = 0;

            if (unitFrom == "C")
            {
                idVal_1 = 1;
            }
            else if(unitFrom == "F")
            {
                idVal_1 = 2;
            }
            else if (unitFrom == "K")
            {
                idVal_1 = 3;
            }
            else if (unitFrom == "R")
            {
                idVal_1 = 4;
            }

            int idVal_2 = 0;

            if (unitTo == "C")
            {
                idVal_2 = 1;
            }
            else if (unitTo == "F")
            {
                idVal_2 = 2;
            }
            else if (unitTo == "K")
            {
                idVal_2 = 3;
            }
            else if (unitTo == "R")
            {
                idVal_2 = 4;
            }

            //przekonwertowanie pierwotnej wartości na celciusze
            if (idVal_1 == 2)
            {
                toConvert = FarenheitToCelsiusz(value);
            }
            if (idVal_1 == 3)
            {
                toConvert = KelvinToCelsiusz(value);
            }
            if (idVal_1 == 4)
            {
                toConvert = RankineToCelsiusz(value);
            }
            if (idVal_1 == 1)
            {
                toConvert = value;
            }

            if (idVal_2 == 2)
            {
                resultConvert = CelsiuszToFarenheit(toConvert);
            }
            if (idVal_2 == 3)
            {
                resultConvert = CelsiuszToKelvin(toConvert);
            }
            if (idVal_2 == 4)
            {
                resultConvert = CelsiuszToRankine(toConvert);
            }
            if (idVal_2 == 1)
            {
                resultConvert = toConvert;
            }


            return resultConvert;
        }

        public double FarenheitToCelsiusz(double temperatura)
        {
            temperatura = (temperatura - 32) / 1.8;
            return temperatura;
        }
        public double CelsiuszToFarenheit(double temperatura)
        {
            temperatura = 1.8 * temperatura + 32;
            return temperatura;
        }
        public double KelvinToCelsiusz(double temperatura)
        {
            temperatura = temperatura - 273.15;
            return temperatura;
        }
        public double CelsiuszToKelvin(double temperatura)
        {
            temperatura = temperatura + 273.15;
            return temperatura;
        }
        public double RankineToCelsiusz(double temperatura)
        {
            temperatura = (temperatura / 1.8) - 273.15;
            return temperatura;
        }
        public double CelsiuszToRankine(double temperatura)
        {
            temperatura = (temperatura + 273.15) * 1.8;
            return temperatura;
        }
    }

}
