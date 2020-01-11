using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerConverterPlugin
{
    public class PowerConverter : ConverterSDK.IConvertible
    {
        public string ConverterName => "Moc";
        public List<string> Units =>
                new List<string>()
                {
                    "Wat",
                    "Kilowat",
                    "Koń Mechaniczny",
                    "Koń Parowy"
                };
        public string Convert(string unitFrom, string UnitTo, double value)
        {
            if (unitFrom.Equals(UnitTo))
                return value.ToString();
            //////////////////////
            //w->kw
            else if (unitFrom.Equals("Wat") && UnitTo.Equals("Kilowat"))
                return (value / 1000).ToString();
            //kw->w
            else if (unitFrom.Equals("Kilowat") && UnitTo.Equals("Wat"))
                return (value * 1000).ToString();
            //////////////////////
            //w->km
            else if (unitFrom.Equals("Wat") && UnitTo.Equals("Koń Mechaniczny"))
                return (value * 735.49875).ToString();
            //km->w
            else if (unitFrom.Equals("Koń Mechaniczny") && UnitTo.Equals("Wat"))
                return (value / 735.49875).ToString();
            //////////////////////
            //w->kp
            else if (unitFrom.Equals("Wat") && UnitTo.Equals("Koń Parowy"))
                return (value / 745.7).ToString();
            //kp->w
            else if (unitFrom.Equals("Koń Parowy") && UnitTo.Equals("Wat"))
                return (value * 745.7).ToString();
            //////////////////////
            //kw->km
            else if (unitFrom.Equals("Koń Mechaniczny") && UnitTo.Equals("Kilowat"))
                return (value / 1.36).ToString();
            //kw->km
            else if (unitFrom.Equals("Kilowat") && UnitTo.Equals("Koń Mechaniczny"))
                return (value * 1.36).ToString();
            //////////////////////
            //km->kp
            else if (unitFrom.Equals("Koń Mechaniczny") && UnitTo.Equals("Koń Parowy"))
                return (value / 1.01).ToString();
            //kp->km
            else if (unitFrom.Equals("Koń Parowy") && UnitTo.Equals("Koń Mechaniczny"))
                return (value * 1.01).ToString();
            //////////////////////////
            //kw->kp
            else if (unitFrom.Equals("Kilowat") && UnitTo.Equals("Koń Parowy"))
                return (value * 1.34).ToString();
            //kp->kw
            else
                return (value / 1.34).ToString();

        }
    }
}
