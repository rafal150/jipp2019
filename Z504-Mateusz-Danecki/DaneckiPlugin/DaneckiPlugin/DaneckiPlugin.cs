using System;
using System.Collections.Generic;
using System.Text;
using UnitCoverterPart2.Services;

namespace DaneckiPlugin
{
    class DaneckiPlugin
    {
        class MDConverter: IConverter
        {
            public string Name => "SystemDidota";

            public List<string> Units => new List<string>(new[] { "punkt", "cycero", "kwadrat" });

            public double Convert(string unitFrom, string unitTo, double value)
            {
                if (unitFrom == "punkt" && unitTo == "cycero")        //punkt na cycero 
                {
                    value = value * 0.0833;

                }

                if (unitFrom == "punkt" && unitTo == "kwadrat")        //punkt na kwadrat
                {
                    value = value * 0.0208;

                }

                if (unitFrom == "cycero" && unitTo == "punkt")        //cycero [cc]  na punkt [p,dd]
                {
                    value = value * 12;

                }

                if (unitFrom == "cycero" && unitTo == "kwadrat")        //cycero [cc] na kwadrat [kw]
                {
                    value = value * 0.25;

                }

                if (unitFrom == "kwadrat" && unitTo == "punkt")        //kwadrat [kw] na punkt [p,dd]
                {
                    value = value * 48;

                }

                if (unitFrom == "kwadrat" && unitTo == "cycero")        //kwadrat [kw] na cycero [cc]
                {
                    value = value * 4;

                }
                return value;
            }
            }
    }
}
