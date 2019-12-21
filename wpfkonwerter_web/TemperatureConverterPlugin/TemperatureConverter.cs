using System;
using System.Collections.Generic;
using IConvertible = ConverterSDK.IConvertible;

namespace TemperatureConverterPlugin
{
    public class TemperatureConverter : IConvertible
    {
        public string ConverterName => "Temperatura";
        public List<string> Units =>
            new List<string>()
            {
                "Celsjusz",
                "Farenheit",
                "Kelwin",
                "Rankine"
            };

        public string Convert(int indexFrom, int indexTo, double value)
        {
            #region  IFY temp
            if (indexFrom == indexTo)
                return value.ToString();
            //c->f
            else if (indexFrom == 0 && indexTo == 1)
                return (value * 9 / 5 + 32).ToString();
            //f->c
            else if (indexFrom == 1 && indexTo == 0)
                return ((value - 32) * 5 / 9).ToString();
            //c->k
            else if (indexFrom == 0 && indexTo == 2)
                return (value - 273.15).ToString();
            //k->c
            else if (indexFrom == 2 && indexTo == 0)
                return (value + 273.15).ToString();
            //f->k
            else if (indexFrom == 1 && indexTo == 2)
                return (((value - 32) * 5 / 9) + 273.15).ToString();
            //k->f
            else if (indexFrom == 2 && indexTo == 1)
                return (value * 9 / 5 + 32 - 273.15).ToString();
            //c->r
            else if (indexFrom == 0 && indexTo == 3)
                return (value * 0.52500 + 7.50).ToString();
            //r->c
            else if (indexFrom == 3 && indexTo == 0)
                return ((value - 7.5) / 0.52500).ToString();
            //f->r
            else if (indexFrom == 1 && indexTo == 3)
                return (value + 459.67).ToString();
            //r->f
            else if (indexFrom == 3 && indexTo == 1)
                return (value - 459.67).ToString();
            //k->r
            else if (indexFrom == 2 && indexTo == 3)
                return (9 / 5 * value).ToString();
            //r->k
            else //if (indexFrom == 3 && indexTo == 2)
                return (5 / 9 * value).ToString();
            #endregion
        }
    }
}
