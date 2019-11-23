using System;
using System.Collections.Generic;
using System.Text;

namespace Plugins
{
    public class DistanceConverter : BaseConverter
    {
        public DistanceConverter(string fromUnit, string toUnit, double value, DateTime convertingTime, string physicalProperty) : base(fromUnit, toUnit, value, convertingTime, physicalProperty)
        {

        }
        public DistanceConverter() : base()
        {

        }
        public override void Convert()
        {
            double valueInMeters = this.ConvertToMeters();

            if (ToUnit.Equals(Distance.inch))
            {
                this.Result = this.ConvertFromMetersToInch(valueInMeters);
            }
            if (ToUnit.Equals(Distance.ft))
            {
                this.Result = this.ConvertFromMetersToFt(valueInMeters);
            }
            if (ToUnit.Equals(Distance.yard))
            {
                this.Result = this.ConvertFromMetersToYard(valueInMeters);
            }
            if (ToUnit.Equals(Distance.mile))
            {
                this.Result = this.ConvertFromMetersToMiles(valueInMeters);
            }
            if (ToUnit.Equals(Distance.cabel))
            {
                this.Result = this.ConvertFromMetersToCabels(valueInMeters);
            }
            if (ToUnit.Equals(Distance.nauticalMile))
            {
                this.Result = this.ConvertFromMetersToNauticalMiles(valueInMeters);
            }
            if (ToUnit.Equals(Distance.mm))
            {
                this.Result = this.ConvertFromMetersToMiliMeters(valueInMeters);
            }
            if (ToUnit.Equals(Distance.cm))
            {
                this.Result = this.ConvertFromMetersToCentimeters(valueInMeters);
            }
            if (ToUnit.Equals(Distance.dm))
            {
                this.Result = this.ConvertFromMetersToDecimeters(valueInMeters);
            }
            if (ToUnit.Equals(Distance.m))
            {
                Result = valueInMeters;
            }
            if (ToUnit.Equals(Distance.km))
            {
                this.Result = this.ConvertFromMetersToKilometers(valueInMeters);
            }
        }

        private double ConvertFromMetersToInch(double value)
        {
            return value * 39.4;
        }
        private double ConvertFromMetersToFt(double value)
        {
            return value * 3.2808399;
        }
        private double ConvertFromMetersToYard(double value)
        {
            return value * 1.0936133;
        }
        private double ConvertFromMetersToMiles(double value)
        {
            return value * 0.000621371192;
        }
        private double ConvertFromMetersToCabels(double value)
        {
            return value / 185.2;
        }
        private double ConvertFromMetersToNauticalMiles(double value)
        {
            return value / 1852;
        }
        private double ConvertFromMetersToMiliMeters(double value)
        {
            return value * 1000;
        }
        private double ConvertFromMetersToCentimeters(double value)
        {
            return value * 100;
        }
        private double ConvertFromMetersToDecimeters(double value)
        {
            return value * 10;
        }
        private double ConvertFromMetersToKilometers(double value)
        {
            return value / 1000;
        }


        private double ConvertToMeters()
        {
            double result = 0;
            if (FromUnit.Equals(Distance.m))
            {
                result = this.Value;
            }
            else
            {
                if (FromUnit.Equals(Distance.mm))
                {
                    result = this.Value / 1000;
                }
                if (FromUnit.Equals(Distance.cm))
                {
                    result = this.Value / 100;
                }
                if (FromUnit.Equals(Distance.dm))
                {
                    result = this.Value / 10;
                }
                if (FromUnit.Equals(Distance.km))
                {
                    result = this.Value * 1000;
                }
                if (FromUnit.Equals(Distance.inch))
                {
                    result = this.Value * 0.0254;
                }
                if (FromUnit.Equals(Distance.ft))
                {
                    result = this.Value / 30.48;
                }
                if (FromUnit.Equals(Distance.yard))
                {
                    result = this.Value / 0.9144;
                }
                if (FromUnit.Equals(Distance.cabel))
                {
                    result = this.Value * 185.20;
                }
                if (FromUnit.Equals(Distance.nauticalMile))
                {
                    result = this.Value * 1852;
                }
            }

            return result;
        }
    }
}
