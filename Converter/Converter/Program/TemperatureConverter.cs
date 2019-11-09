using Converter.Dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter.Program
{
    class TemperatureConverter : BaseConverter
    {
        public TemperatureConverter(string fromUnit, string toUnit, double value, DateTime convertingTime, string physicalProperty) : base(fromUnit, toUnit, value, convertingTime, physicalProperty)
        {

        }

        public TemperatureConverter() : base()
        {

        }

        public override void Convert()
        {
            double valueInCelcius = this.ConvertToCelsius();

            if(this.ToUnit.Equals(Temperature.C))
            {
                this.Result = valueInCelcius;
            }
            if(this.ToUnit.Equals(Temperature.F))
            {
                ConvertFromCelsiusToFahrenheit(valueInCelcius);
            }
            if (this.ToUnit.Equals(Temperature.K))
            {
                ConvertFromCelsiusToKelvin(valueInCelcius);
            }
            if (this.ToUnit.Equals(Temperature.R))
            {
                ConvertFromCelsiusToRankine(valueInCelcius);
            }
        }

        private double ConvertToCelsius()
        {
            double result = 0;
            if(this.FromUnit.Equals(Temperature.C))
            {
                result = this.Value;
            }
            else
            {
                if (this.FromUnit.Equals(Temperature.F))
                {
                    result = (this.Value - 32) / 1.8;
                }
                if (this.FromUnit.Equals(Temperature.K))
                {
                    result = this.Value - 273.15;
                }
                if (this.FromUnit.Equals(Temperature.R))
                {
                    result = (this.Value - 491.67) * (5.0 / 9.0);
                }
            }
            return result;
        }

        private void ConvertFromCelsiusToKelvin(double value)
        {
            this.Result = value + 273.15;
        }
        private void ConvertFromCelsiusToFahrenheit(double value)
        {
            this.Result = value * 1.8 + 32;
        }
        private void ConvertFromCelsiusToRankine(double value)
        {
            this.Result = value * 1.8 + 491.67;
        }
    }
}
