using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitCoverterPart2.Services;

namespace UnitConverter.Logic.Services
{
    public class PressureConverter : IConverter
    {
        public string Name => "Cisnienie";

        public List<string> Units => new List<string>(new[] { "hPa", "N/mm2" });

        public double Convert(string unitFrom, string unitTo, double value)
        {
            if (unitFrom == "hPa" && unitTo == "N/mm2")        //hPa zamienia na N/mm2
            {

                return (value / 10000);

            }

            if (unitFrom == "N/mm2" && unitTo == "hPa")        //N/mm2 zamienia na hPa
            {

                return (value * 10000);

            }
            if (unitFrom == "hPa" && unitTo == "hPa")        //hPa na hPa
            {

               return (value * 1);

            }
            if (unitFrom == "N/mm2" && unitTo == "N/mm2")        //N/mm2 na N/mm2
            {

               return (value * 1);
            }
            return double.NaN;
        }


    }
}
