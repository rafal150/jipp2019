using System;
using System.Collections.Generic;
using System.Text;

namespace Converter
{
    public class CalculationResult: BaseEntity
    {
        public CalculationResult()
        {
            
        }

        public UnitType UnitType { get; set; }

        public string FromUnit { get; set; }

        public string ToUnit { get; set; }

        public decimal FromValue { get; set; }

        public decimal ToValue { get; set; }
    }

}
