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

        public string Convert(int indexFrom, int indexTo, double value)
        {
            //"kilogram", "tona", "uncja", "funt" };

            #region IFY Masa

            if (indexFrom == indexTo)
                return value.ToString();
            ///////////////

            //k->t
            else if (indexFrom == 0 && indexTo == 1)
                return (value / 1000).ToString();
            //t->k
            else if (indexFrom == 1 && indexTo == 0)
                return (value * 1000).ToString();
            ///////////////////

            //k->u
            else if (indexFrom == 0 && indexTo == 2)
                return (value * 35.2739619).ToString();
            //u->k
            else if (indexFrom == 2 && indexTo == 0)
                return (value / 35.2739619).ToString();
            //////////////

            //k->f
            else if (indexFrom == 0 && indexTo == 3)
                return (value * 2.20462262).ToString();
            //f->k
            else if (indexFrom == 3 && indexTo == 0)
                return (value / 2.20462262).ToString();
            ///////////////

            //t->u
            else if (indexFrom == 1 && indexTo == 2)
                return (value * 35273.9619).ToString();
            //u->t
            else if (indexFrom == 2 && indexTo == 1)
                return (value / 35273.9619).ToString();
            ///////////////

            //t->f
            else if (indexFrom == 1 && indexTo == 3)
                return (value * 2204.62262).ToString();
            //f->t
            else if (indexFrom == 3 && indexTo == 1)
                return (value / 2204.62262).ToString();
            ///////////////

            //u->f
            else if (indexFrom == 2 && indexTo == 3)
                return (value * 0.062500).ToString();
            //f->u
            else // (indexFrom == 3 && indexTo == 2)
                return (value * 16.000).ToString();
            #endregion
        }
    }
}
