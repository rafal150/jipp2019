using System;
using System.Collections.Generic;
using IConvertible = ConverterSDK.IConvertible;

namespace MassConverterPlugin
{
    public class MassConverter : IConvertible
    {
        public string ConverterName => "Masa";
        public List<string> Units =>
                new List<string>()
                {
                    "Kilogram",
                    "Tona",
                    "Uncja",
                    "Funt"
                };

        public string Convert(string unitFrom, string unitTo, double value)
        {
            //"kilogram", "tona", "uncja", "funt" };

            #region IFY Masa

            if (unitFrom == unitTo)
                return value.ToString();
            ///////////////

            //k->t
            else if (unitFrom.Equals("kilogram") && unitTo.Equals("tona"))
                return (value / 1000).ToString();
            //t->k
            else if (unitFrom.Equals("tona") && unitTo.Equals("kilogram"))
                return (value * 1000).ToString();
            ///////////////////

            //k->u
            else if (unitFrom.Equals("kilogram") && unitTo.Equals("uncja"))
                return (value * 35.2739619).ToString();
            //u->k
            else if (unitFrom.Equals("uncja") && unitTo.Equals("kilogram"))
                return (value / 35.2739619).ToString();
            //////////////

            //k->f
            else if (unitFrom.Equals("kilogram") && unitTo.Equals("funt"))
                return (value * 2.20462262).ToString();
            //f->k
            else if (unitFrom.Equals("funt") && unitTo.Equals("kilogram"))
                return (value / 2.20462262).ToString();
            ///////////////

            //t->u
            else if (unitFrom.Equals("tona") && unitTo.Equals("uncja"))
                return (value * 35273.9619).ToString();
            //u->t
            else if (unitFrom.Equals("uncja") && unitTo.Equals("tona"))
                return (value / 35273.9619).ToString();
            ///////////////

            //t->f
            else if (unitFrom.Equals("tona") && unitTo.Equals("funt"))
                return (value * 2204.62262).ToString();
            //f->t
            else if (unitFrom.Equals("funt") && unitTo.Equals("tona"))
                return (value / 2204.62262).ToString();
            ///////////////

            //u->f
            else if (unitFrom.Equals("uncja") && unitTo.Equals("funt"))
                return (value * 0.062500).ToString();
            //f->u
            else // (indexFrom == 3 && indexTo == 2)
                return (value * 16.000).ToString();
            #endregion
        }
    }
}
