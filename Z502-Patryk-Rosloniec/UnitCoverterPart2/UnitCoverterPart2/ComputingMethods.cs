using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitCoverterPart2
{
    class ComputingMethods
    {

       


        public static double ConvertLength(string fromUnit, string toUnit, double inputValue)
        {
            double k1 = 0.0, k2 = 0.0;

            for (int i = 0; i < AppData.lUnits.Length; i++)
            {
                if (fromUnit == AppData.lUnits[i])
                    k1 = AppData.lMultiplier[i];
                if (toUnit == AppData.lUnits[i])
                    k2 = AppData.lMultiplier[i];
            }


            return k1 * inputValue / k2;
            ;
        }


        public static double ConvertWeight(string fromUnit, string toUnit, double inputValue)
        {
            double k1 = 0.0, k2 = 0.0;

            for (int i = 0; i < AppData.wUnits.Length; i++)
            {
                if (fromUnit == AppData.wUnits[i])
                    k1 = AppData.wMultiplier[i];
                if (toUnit == AppData.wUnits[i])
                    k2 = AppData.wMultiplier[i];
            }


            return k1 * inputValue / k2;
            ;
        }


        public static double ConvertTemperature(string from, string to, double inputValue)
        {

            if (from == "K")
            {
                if (to == "°C")
                    return inputValue - 273.15;

                else if (to == "°F")
                    return ((inputValue - 273.15) * 1.8) + 32.0;

                else if (to == "°R")
                    return inputValue * 1.8;

            }
            else if (from == "°C")
            {
                if (to == "K")
                    return inputValue + 273.15;

                else if (to == "°F")
                    return (inputValue * 1.8) + 32.0;

                else if (to == "°R")
                    return (inputValue + 273.15) * 1.8;

            }
            else if (from == "°F")
            {
                if (to == "°C")
                    return (inputValue - 32.0) / 1.8;

                else if (to == "K")
                    return ((inputValue - 32.0) / 1.8) + 273.15;

                else if (to == "°R")
                    return (((inputValue - 32.0) / 1.8) + 273.15) * 1.8;

            }
            else if (from == "°R")
            {
                if (to == "°C")
                    return (inputValue / 1.8) - 273.15;

                else if (to == "K")
                    return (inputValue / 1.8);

                else if (to == "°F")
                    return (((inputValue / 1.8) - 273.15) * 1.8) + 32.0;
            }

            return 0;
        }

    }
}
