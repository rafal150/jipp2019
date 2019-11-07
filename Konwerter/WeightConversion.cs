using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter
{
    class WeightConversion
    {
        public static double fromBase(double value)
        {
            double convertedWeight = 0;
            switch (MainWindow.toUnit)
            {
                case "mg":
                    {
                        convertedWeight = value / 0.000001;
                        break;
                    }
                case "g":
                    {
                        convertedWeight = value / 0.001;
                        break;
                    }
                case "dkg":
                    {
                        convertedWeight = value / 0.01;
                        break;
                    }
                case "kg":
                    {
                        convertedWeight = value;
                        break;
                    }
                case "T":
                    {
                        convertedWeight = value / 1000;
                        break;
                    }
                case "uncja":
                    {
                        convertedWeight = value / 0.028349523;
                        break;
                    }
                case "funt":
                    {
                        convertedWeight = value / 0.45359237;
                        break;
                    }
                case "karat":
                    {
                        convertedWeight = value / 0.0002;
                        break;
                    }
                case "kwintal":
                    {
                        convertedWeight = value / 100;
                        break;
                    }
            }
            return convertedWeight;
        }

        public static double toBase(double value)
        {
            double convertedWeight = 0;
            switch (MainWindow.fromUnit)
            {
                case "mg":
                    {
                        convertedWeight = value * 0.000001;
                        break;
                    }
                case "g":
                    {
                        convertedWeight = value * 0.001;
                        break;
                    }
                case "dkg":
                    {
                        convertedWeight = value * 0.01;
                        break;
                    }
                case "kg":
                    {
                        convertedWeight = value;
                        break;
                    }
                case "T":
                    {
                        convertedWeight = value * 1000;
                        break;
                    }
                case "uncja":
                    {
                        convertedWeight = value * 0.028349523;
                        break;
                    }
                case "funt":
                    {
                        convertedWeight = value * 0.45359237;
                        break;
                    }
                case "karat":
                    {
                        convertedWeight = value * 0.0002;
                        break;
                    }
                case "kwintal":
                    {
                        convertedWeight = value * 100;
                        break;
                    }
            }
            return convertedWeight;
        }

        public static double Convert(double convert)
        {
            return fromBase(toBase(convert));
        }
    }
}
