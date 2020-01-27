using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter
{
    class Masa
    {
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
        public double kgToKwintal (double masa)
        {
            masa = masa / 100;
            return masa;
        }

    }
}
