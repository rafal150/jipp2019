using System;
using System.Collections.Generic;
using System.Text;

namespace Converter
{
    public class CalculationResultDTO : BaseEntity
    {
        public string UnitType { get; set; }

        public string FromUnit { get; set; }

        public string ToUnit { get; set; }

        public decimal FromValue { get; set; }

        public decimal ToValue { get; set; }
    }
}
