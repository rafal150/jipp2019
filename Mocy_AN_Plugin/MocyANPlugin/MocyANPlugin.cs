using System;
using System.Collections.Generic;
using System.Text;
using UnitCoverterPart2.Services;

namespace MocyANPlugin
{
    class MocyANPlugin
    {
        class ANConverter : IConverter
        {
            public string Name => "KonwerterMocy";

            public List<string> Units => new List<string>(new[] { "Watt", "Kilowat", "KonMechaniczny" });

            public double Convert(string unitFrom, string unitTo, double value)
            {
                if (unitFrom == "Watt" && unitTo == "Kilowat")
                {
                    value = value * 0.001;

                }
                if (unitFrom == "Watt" && unitTo == "KonMechaniczny")
                {
                    value = value * 0.0014;

                }
                if (unitFrom == "Kilowat" && unitTo == "Watt")
                {
                    value = value * 1000;

                }
                if (unitFrom == "Kilowat" && unitTo == "KonMechaniczny")
                {
                    value = value * 1.3596;

                }
                if (unitFrom == "KonMechaniczny" && unitTo == "Watt")
                {
                    value = value * 735.4988;

                }
                if (unitFrom == "KonMechaniczny" && unitTo == "Kilowat")
                {
                    value = value * 0.7355;

                }
                return value;
            }
        }



    }
}

