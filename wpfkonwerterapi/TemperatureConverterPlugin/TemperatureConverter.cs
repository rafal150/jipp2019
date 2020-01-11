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

        public string Convert(string unitFrom, string unitTo, double value)
        {
            #region  IFY temp
            if (unitFrom.Equals( unitTo))
                return value.ToString();
            //c->f
            else if (unitFrom.Equals("Celsjusz") && unitTo.Equals("Farenheit"))
                return (value * 9 / 5 + 32).ToString();
            //f->c
            else if (unitFrom.Equals("Farenheit") && unitTo.Equals("Celsjusz"))
                return ((value - 32) * 5 / 9).ToString();
            //c->k
            else if (unitFrom.Equals("Celsjusz") && unitTo.Equals("Kelwin"))
                return (value - 273.15).ToString();
            //k->c
            else if (unitFrom.Equals("Kelwin") && unitTo.Equals("Celsjusz"))
                return (value + 273.15).ToString();
            //f->k
            else if (unitFrom.Equals("Farenheit") && unitTo.Equals("Kelwin"))
                return (((value - 32) * 5 / 9) + 273.15).ToString();
            //k->f
            else if (unitFrom.Equals("Kelwin") && unitTo.Equals("Farenheit"))
                return (value * 9 / 5 + 32 - 273.15).ToString();
            //c->r
            else if (unitFrom.Equals("Celsjusz") && unitTo.Equals("Rankine"))
                return (value * 0.52500 + 7.50).ToString();
            //r->c
            else if (unitFrom.Equals("Rankine") && unitTo.Equals("Celsjusz"))
                return ((value - 7.5) / 0.52500).ToString();
            //f->r
            else if (unitFrom.Equals("Farenheit") && unitTo.Equals("Rankine"))
                return (value + 459.67).ToString();
            //r->f
            else if (unitFrom.Equals("Rankine") && unitTo.Equals("Farenheit"))
                return (value - 459.67).ToString();
            //k->r
            else if (unitFrom.Equals("Kelwin") && unitTo.Equals("Rankine"))
                return (9 / 5 * value).ToString();
            //r->k
            else //if (indexFrom == 3 && indexTo == 2)
                return (5 / 9 * value).ToString();
            #endregion
        }
    }
}
