using System;
using System.Collections.Generic;
using System.Text;

namespace Plugins
{
    public class VoltageConverter : BaseConverter
    {
        public VoltageConverter(string fromUnit, string toUnit, double value, DateTime convertingTime, string physicalProperty) : base(fromUnit, toUnit, value, convertingTime, physicalProperty)
        {

        }

        public VoltageConverter() : base()
        {

        }

        public override void Convert()
        {
            double valueInVolts = this.ConvertToVolts();

            if (ToUnit.Equals(Voltage.mv))
            {
                this.Result = this.ConvertFromVoltsToMiliVolts(valueInVolts);
            }
            if (ToUnit.Equals(Voltage.v))
            {
                this.Result = valueInVolts;
            }
            if (ToUnit.Equals(Voltage.kv))
            {
                this.Result = this.ConvertFromVoltsToKiloVolts(valueInVolts);
            }
            
        }

        private double ConvertFromVoltsToMiliVolts(double value)
        {
            return value * 1000.0;
        }
        private double ConvertFromVoltsToKiloVolts(double value)
        {
            return value / 1000.0;
        }

        private double ConvertToVolts()
        {
            double result = 0;
            if (this.FromUnit.Equals(Voltage.v))
            {
                result = this.Value;
            }
            else
            {
                if (this.FromUnit.Equals(Voltage.mv))
                {
                    result = this.Value / 1000.0;
                }
                if (this.FromUnit.Equals(Voltage.kv))
                {
                    result = this.Value * 1000.0;
                }
            }
            return result;
        }
    }
}
