using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter.Services
{
    public class MasaKonwerter : IKonwerter
    {
        public string Name => "Masy";

        public List<string> Units => new List<string>(new[] { "mg", "g", "dkg", "kg", "T", "uncja", "funt", "karat", "kwintal" });

        public double Convert(string unitFrom, string unitTo, double value)
        {
            int idVal_1 = 0;
            double toConvert = 0;
            double resultConvert = 0;

            if (unitFrom == "mg")
            {
                idVal_1 = 1;
            }
            else if (unitFrom == "g")
            {
                idVal_1 = 2;
            }
            else if (unitFrom == "dkg")
            {
                idVal_1 = 3;
            }
            else if (unitFrom == "kg")
            {
                idVal_1 = 4;
            }
            else if (unitFrom == "T")
            {
                idVal_1 = 5;
            }
            else if (unitFrom == "uncja")
            {
                idVal_1 = 6;
            }
            else if (unitFrom == "funt")
            {
                idVal_1 = 7;
            }
            else if (unitFrom == "karat")
            {
                idVal_1 = 8;
            }
            else if (unitFrom == "kwintal")
            {
                idVal_1 = 9;
            }

            int idVal_2 = 0;

            if (unitTo == "mg")
            {
                idVal_2 = 1;
            }
            else if (unitTo == "g")
            {
                idVal_2 = 2;
            }
            else if (unitTo == "dkg")
            {
                idVal_2 = 3;
            }
            else if (unitTo == "kg")
            {
                idVal_2 = 4;
            }
            else if (unitTo == "T")
            {
                idVal_2 = 5;
            }
            else if (unitTo == "uncja")
            {
                idVal_2 = 6;
            }
            else if (unitTo == "funt")
            {
                idVal_2 = 7;
            }
            else if (unitTo == "karat")
            {
                idVal_2 = 8;
            }
            else if (unitTo == "kwintal")
            {
                idVal_2 = 9;
            }

            //przekonwertowanie pierwotnej wartości na celciusze
            if (idVal_1 == 1)
            {
                toConvert = mgToKg(value);
            }
            if (idVal_1 == 2)
            {
                toConvert = gToKg(value);
            }
            if (idVal_1 == 3)
            {
                toConvert = dkgToKg(value);
            }
            if (idVal_1 == 4)
            {
                toConvert = value;
            }
            if (idVal_1 == 5)
            {
                toConvert = tToKg(value);
            }
            if (idVal_1 == 6)
            {
                toConvert = uncjaToKg(value);
            }
            if (idVal_1 == 7)
            {
                toConvert = funtToKg(value);
            }
            if (idVal_1 == 8)
            {
                toConvert = karatToKg(value);
            }
            if (idVal_1 == 9)
            {
                toConvert = kwintalToKg(value);
            }

            //przekonwertowanie docelowej wartości z celciuszy na docelową wartość
            if (idVal_2 == 1)
            {
                resultConvert = kgToMg(toConvert);
            }
            if (idVal_2 == 2)
            {
                resultConvert = kgToG(toConvert);
            }
            if (idVal_2 == 3)
            {
                resultConvert = kgToDkg(toConvert);
            }
            if (idVal_2 == 4)
            {
                resultConvert = toConvert;
            }
            if (idVal_2 == 5)
            {
                resultConvert = kgToT(toConvert);
            }
            if (idVal_2 == 6)
            {
                resultConvert = kgToUncja(toConvert);
            }
            if (idVal_2 == 7)
            {
                resultConvert = kgToFunt(toConvert);
            }
            if (idVal_2 == 8)
            {
                resultConvert = kgToKarat(toConvert);
            }
            if (idVal_2 == 9)
            {
                resultConvert = kgToKwintal(toConvert);
            }


            return resultConvert;
        }

        public double mgToKg(double masa)
        {
            masa = masa / 1000000;
            return masa;
        }
        public double kgToMg(double masa)
        {
            masa = masa * 1000000;
            return masa;
        }
        public double gToKg(double masa)
        {
            masa = masa / 1000;
            return masa;
        }
        public double kgToG(double masa)
        {
            masa = masa * 1000;
            return masa;
        }
        public double dkgToKg(double masa)
        {
            masa = masa / 100;
            return masa;
        }
        public double kgToDkg(double masa)
        {
            masa = masa * 100;
            return masa;
        }
        public double tToKg(double masa)
        {
            masa = masa * 1000;
            return masa;
        }
        public double kgToT(double masa)
        {
            masa = masa / 1000;
            return masa;
        }
        public double uncjaToKg(double masa)
        {
            masa = masa * 35.274;
            return masa;
        }
        public double kgToUncja(double masa)
        {
            masa = masa / 35.274;
            return masa;
        }
        public double funtToKg(double masa)
        {
            masa = masa * 2.2046;
            return masa;
        }
        public double kgToFunt(double masa)
        {
            masa = masa / 2.2046;
            return masa;
        }
        public double karatToKg(double masa)
        {
            masa = masa * 5000;
            return masa;
        }
        public double kgToKarat(double masa)
        {
            masa = masa / 5000;
            return masa;
        }
        public double kwintalToKg(double masa)
        {
            masa = masa * 100;
            return masa;
        }
        public double kgToKwintal(double masa)
        {
            masa = masa / 100;
            return masa;
        }
    }
}
