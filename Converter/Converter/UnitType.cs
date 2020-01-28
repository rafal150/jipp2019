using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Converter
{
    public enum UnitType
    {
        [Description("Metric")]
        Metric ,
        [Description("Weight")]
        Weight ,
        [Description("Temperature")]
        Temperature 
    }
}
