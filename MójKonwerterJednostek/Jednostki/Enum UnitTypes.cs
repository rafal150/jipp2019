using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MójKonwerterJednostek.Jednostki;
using MójKonwerterJednostek.Dane;
using System.ComponentModel;


namespace MójKonwerterJednostek.Jednostki
{
    enum UnitTypes
    {
        [Description("Temperature")] Celsius = 1,
        [Description("Temperature")] Kelvin = 2,
        [Description("Temperature")] Rankine = 3,
        [Description("Temperature")] Farenheit = 4,

        [Description("Weight")] mg = 5,
        [Description("Weight")] g = 6,
        [Description("Weight")] dkg = 7,
        [Description("Weight")] kg = 8,
        [Description("Weight")] T = 9,
        [Description("Weight")] ounce = 10,
        [Description("Weight")] pound = 11,
        [Description("Weight")] carat = 12,
        [Description("Weight")] quintal = 13,

        [Description("Length")] m = 14,
        [Description("Length")] mm = 15,
        [Description("Length")] cm = 16,
        [Description("Length")] dm = 17,
        [Description("Length")] km = 18,
        [Description("Length")] inch = 19,
        [Description("Length")] foot = 20,
        [Description("Length")] yard = 21,
        [Description("Length")] mile = 22,
        [Description("Length")] cable_length = 23,
        [Description("Length")] nautical_mile = 24
    }
}
