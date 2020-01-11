using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitCoverterPart2.Services
{
    public class DistanaceConverter : IConverter
    {
        public string Name => "Dystans";

        public List<string> Units => new List<string>(new[] {"mm","cm","dm","m","km","inch","ft","yard","mile","cabel","nauticalMile"});

        public decimal Convert(string unitFrom, string unitTo, decimal value)
        {
            decimal result = 0;
            decimal valueInMeters=ConvertToMeters(unitFrom, value);

            if (unitTo.Equals("inch"))
            {
                result = this.ConvertFromMetersToInch(valueInMeters);
            }
            if (unitTo.Equals("ft"))
            {
                result = this.ConvertFromMetersToFt(valueInMeters);
            }
            if (unitTo.Equals("yard"))
            {
                result = this.ConvertFromMetersToYard(valueInMeters);
            }
            if (unitTo.Equals("mile"))
            {
                result = this.ConvertFromMetersToMiles(valueInMeters);
            }
            if (unitTo.Equals("cabel"))
            {
                result = this.ConvertFromMetersToCabels(valueInMeters);
            }
            if (unitTo.Equals("nauticalMile"))
            {
                result = this.ConvertFromMetersToNauticalMiles(valueInMeters);
            }
            if (unitTo.Equals("mm"))
            {
                result = this.ConvertFromMetersToMiliMeters(valueInMeters);
            }
            if (unitTo.Equals("cm"))
            {
                result = this.ConvertFromMetersToCentimeters(valueInMeters);
            }
            if (unitTo.Equals("dm"))
            {
                result = this.ConvertFromMetersToDecimeters(valueInMeters);
            }
            if (unitTo.Equals("m"))
            {
                result = valueInMeters;
            }
            if (unitTo.Equals("km"))
            {
                result = this.ConvertFromMetersToKilometers(valueInMeters);
            }

            return result;
        }

        private decimal ConvertToMeters(string unitFrom, decimal value)
        {
            decimal result = 0;
            if (unitFrom.Equals("m"))
            {
                result = value;
            }
            else
            {
                if (unitFrom.Equals("mm"))
                {
                    result = value / 1000;
                }
                if (unitFrom.Equals("cm"))
                {
                    result = value / 100;
                }
                if (unitFrom.Equals("dm"))
                {
                    result = value / 10;
                }
                if (unitFrom.Equals("km"))
                {
                    result = value * 1000;
                }
                if (unitFrom.Equals("inch"))
                {
                    result = value * (decimal)0.0254;
                }
                if (unitFrom.Equals("ft"))
                {
                    result = value / (decimal)30.48;
                }
                if (unitFrom.Equals("yard"))
                {
                    result = value / (decimal)0.9144;
                }
                if (unitFrom.Equals("cabel"))
                {
                    result = value * (decimal)185.20;
                }
                if (unitFrom.Equals("nauticalMile"))
                {
                    result = value * 1852;
                }
            }

            return result;
        }

        private decimal ConvertFromMetersToInch(decimal value)
        {
            return value * (decimal)39.4;
        }
        private decimal ConvertFromMetersToFt(decimal value)
        {
            return value * (decimal)3.2808399;
        }
        private decimal ConvertFromMetersToYard(decimal value)
        {
            return value * (decimal)1.0936133;
        }
        private decimal ConvertFromMetersToMiles(decimal value)
        {
            return value * (decimal)0.000621371192;
        }
        private decimal ConvertFromMetersToCabels(decimal value)
        {
            return value / (decimal)185.2;
        }
        private decimal ConvertFromMetersToNauticalMiles(decimal value)
        {
            return value / 1852;
        }
        private decimal ConvertFromMetersToMiliMeters(decimal value)
        {
            return value * 1000;
        }
        private decimal ConvertFromMetersToCentimeters(decimal value)
        {
            return value * 100;
        }
        private decimal ConvertFromMetersToDecimeters(decimal value)
        {
            return value * 10;
        }
        private decimal ConvertFromMetersToKilometers(decimal value)
        {
            return value / 1000;
        }


    }
}
