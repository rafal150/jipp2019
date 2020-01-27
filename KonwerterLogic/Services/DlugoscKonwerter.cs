using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter.Services
{
    public class DlugoscKonwerter : IKonwerter
    {
        public string Name => "Dlugosci";

        public List<string> Units => new List<string>(new[] { "mm", "cm", "dcm", "m", "km", "cal", "stop", "jard", "mila", "kabel", "mila morska" });

        public double Convert(string unitFrom, string unitTo, double value)
        {
            int idVal_1 = 0;
            double toConvert = 0;
            double resultConvert = 0;

            if (unitFrom == "mm")
            {
                idVal_1 = 1;
            }
            else if (unitFrom == "cm")
            {
                idVal_1 = 2;
            }
            else if (unitFrom == "dcm")
            {
                idVal_1 = 3;
            }
            else if (unitFrom == "m")
            {
                idVal_1 = 4;
            }
            else if (unitFrom == "km")
            {
                idVal_1 = 5;
            }
            else if (unitFrom == "cal")
            {
                idVal_1 = 6;
            }
            else if (unitFrom == "stop")
            {
                idVal_1 = 7;
            }
            else if (unitFrom == "jard")
            {
                idVal_1 = 8;
            }
            else if (unitFrom == "mila")
            {
                idVal_1 = 9;
            }
            else if (unitFrom == "kabel")
            {
                idVal_1 = 10;
            }
            else if (unitFrom == "mila morska")
            {
                idVal_1 = 11;
            }

            int idVal_2 = 0;

            if (unitTo == "mm")
            {
                idVal_2 = 1;
            }
            else if (unitTo == "cm")
            {
                idVal_2 = 2;
            }
            else if (unitTo == "dcm")
            {
                idVal_2 = 3;
            }
            else if (unitTo == "m")
            {
                idVal_2 = 4;
            }
            else if (unitTo == "km")
            {
                idVal_2 = 5;
            }
            else if (unitTo == "cal")
            {
                idVal_2 = 6;
            }
            else if (unitTo == "stop")
            {
                idVal_2 = 7;
            }
            else if (unitTo == "jard")
            {
                idVal_2 = 8;
            }
            else if (unitTo == "mila")
            {
                idVal_2 = 9;
            }
            else if (unitTo == "kabel")
            {
                idVal_2 = 10;
            }
            else if (unitTo == "mila morska")
            {
                idVal_2 = 11;
            }


            //KONWERTOWANIE

            //przekonwertowanie pierwotnej wartości
            if (idVal_1 == 1)
            {
                toConvert = mmToM(value);
            }
            if (idVal_1 == 2)
            {
                toConvert = cmToM(value);
            }
            if (idVal_1 == 3)
            {
                toConvert = dcmToM(value);
            }
            if (idVal_1 == 4)
            {
                toConvert = value;
            }
            if (idVal_1 == 5)
            {
                toConvert = kmToM(value);
            }
            if (idVal_1 == 6)
            {
                toConvert = calToM(value);
            }
            if (idVal_1 == 7)
            {
                toConvert = stopToM(value);
            }
            if (idVal_1 == 8)
            {
                toConvert = jardToM(value);
            }
            if (idVal_1 == 9)
            {
                toConvert = milaToM(value);
            }
            if (idVal_1 == 10)
            {
                toConvert = kabelToM(value);
            }
            if (idVal_1 == 11)
            {
                toConvert = MilaMorskaToM(value);
            }

            //przekonwertowanie docelowej wartości na docelową wartość
            if (idVal_2 == 1)
            {
                resultConvert = mToMm(toConvert);
            }
            if (idVal_2 == 2)
            {
                resultConvert = mToCm(toConvert);
            }
            if (idVal_2 == 3)
            {
                resultConvert = mToDcm(toConvert);
            }
            if (idVal_2 == 4)
            {
                resultConvert = toConvert;
            }
            if (idVal_2 == 5)
            {
                resultConvert = mToKm(toConvert);
            }
            if (idVal_2 == 6)
            {
                resultConvert = mToCal(toConvert);
            }
            if (idVal_2 == 7)
            {
                resultConvert = mToStop(toConvert);
            }
            if (idVal_2 == 8)
            {
                resultConvert = mToJard(toConvert);
            }
            if (idVal_2 == 9)
            {
                resultConvert = mToMila(toConvert);
            }
            if (idVal_2 == 10)
            {
                resultConvert = mToKabel(toConvert);
            }
            if (idVal_2 == 11)
            {
                resultConvert = mToMilaMorska(toConvert);
            }

            return resultConvert;
        }

        public double mmToM(double dlugosc)
        {
            dlugosc = dlugosc / 1000;
            return dlugosc;
        }
        public double mToMm(double dlugosc)
        {
            dlugosc = dlugosc * 1000;
            return dlugosc;
        }
        public double cmToM(double dlugosc)
        {
            dlugosc = dlugosc / 100;
            return dlugosc;
        }
        public double mToCm(double dlugosc)
        {
            dlugosc = dlugosc * 100;
            return dlugosc;
        }
        public double dcmToM(double dlugosc)
        {
            dlugosc = dlugosc / 10;
            return dlugosc;
        }
        public double mToDcm(double dlugosc)
        {
            dlugosc = dlugosc * 10;
            return dlugosc;
        }
        public double kmToM(double dlugosc)
        {
            dlugosc = dlugosc * 1000;
            return dlugosc;
        }
        public double mToKm(double dlugosc)
        {
            dlugosc = dlugosc / 1000;
            return dlugosc;
        }
        public double mToCal(double dlugosc)
        {
            dlugosc = dlugosc * 39.37;
            return dlugosc;
        }
        public double calToM(double dlugosc)
        {
            dlugosc = dlugosc / 39.37;
            return dlugosc;
        }
        public double mToStop(double dlugosc)
        {
            dlugosc = dlugosc * 3.2808;
            return dlugosc;
        }
        public double stopToM(double dlugosc)
        {
            dlugosc = dlugosc / 3.2808;
            return dlugosc;
        }
        public double mToJard(double dlugosc)
        {
            dlugosc = dlugosc * 1.0936;
            return dlugosc;
        }
        public double jardToM(double dlugosc)
        {
            dlugosc = dlugosc / 1.0936;
            return dlugosc;
        }
        public double mToMila(double dlugosc)
        {
            dlugosc = dlugosc * 0.00062137;
            return dlugosc;
        }
        public double milaToM(double dlugosc)
        {
            dlugosc = dlugosc / 0.00062137;
            return dlugosc;
        }
        public double mToKabel(double dlugosc)
        {
            dlugosc = dlugosc / 185.2;
            return dlugosc;
        }
        public double kabelToM(double dlugosc)
        {
            dlugosc = dlugosc * 185.2;
            return dlugosc;
        }
        public double mToMilaMorska(double dlugosc)
        {
            dlugosc = dlugosc / 1852;
            return dlugosc;
        }
        public double MilaMorskaToM(double dlugosc)
        {
            dlugosc = dlugosc * 1852;
            return dlugosc;
        }
    }
}
