using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter4.UnitConverters
{
    public interface IUnitConverter
    {
        string Type { get; }

        string Unit { get; }

        decimal ConvertToSI(decimal value);

        decimal ConvertFromSI(decimal value);
    }
}
