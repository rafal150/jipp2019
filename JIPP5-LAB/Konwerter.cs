using JIPP5_LAB.Database;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JIPP5_LAB
{
    public class Konwerter
    {
        public decimal Convert(Jednostka fromUnit, decimal input, Jednostka toUnit)
        {
            return fromUnit.Przelicz(input, toUnit.Typ);
        }
    }
}
