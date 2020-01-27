using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter
{
    class Dlugosci
    {
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
