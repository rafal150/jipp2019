using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter
{
    class Temperature: IConverter
    {
        public float toBaseUnit(string temp, float input)
        {
            float value=0;
            switch(temp)
            {
                case "Celsjusz":
                    value = input;
                    break;
                case "Fahrenheit":
                    value = 0.555555556f * (input-32);
                    break;
                case "Kelvin":
                    value = input - 273.15f;
                    break;
            }          
            value = Convert.ToSingle(value.ToString());
            return value;

        }

        public float toUnit(string temp, float input)
        {
            float value = 0;
            switch (temp)
            {
                case "Celsjusz":
                    value = input;
                    break;
                case "Fahrenheit":
                    value = input * 0.555555556f * (input + 32);
                    break;
                case "Kelvin":
                    value = input + 273.15f;
                    break;
            }
            value = Convert.ToSingle(value.ToString());
            return value;
        }
    }

}
