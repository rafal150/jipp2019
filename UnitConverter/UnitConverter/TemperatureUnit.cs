using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter
{
    class TemperatureUnit:Unit
    {
        public void CelToBase()
        {
            value_temp = value_start + 273.15;
        }

        public void FarToBase()
        {
            value_temp = ((value_start + 459.67) * (5.0d / 9.0d));
        }

        public void KelToBase()
        {
            value_temp = value_start;
        }

        public void RankToBase()
        {
            value_temp = value_start * value_base;
        }




        public void BaselToCel()
        {
            value_end = value_temp - 273.15;
        }

        public void BaseToFar()
        {
            value_end = (value_temp * (9.0d / 5.0d)) -459.67 ;
        }

        public void BaseToKel()
        {
            value_end = value_temp;
        }

        public void BaseToRank()
        {
            value_end = value_temp / value_base;
        }

    }
}
