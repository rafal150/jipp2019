using System;
using System.Collections.Generic;
using System.Text;

namespace Plugins
{
    class WeightConverter : BaseConverter
    {
        public WeightConverter(string fromUnit, string toUnit, double value, DateTime convertingTime, string physicalProperty) : base(fromUnit, toUnit, value, convertingTime, physicalProperty)
        {

        }

        public WeightConverter() : base()
        {

        }

        public override void Convert()
        {
            double valueInGrams = this.ConvertToGrams();

            if (ToUnit.Equals(Weight.mg))
            {
                this.Result = this.ConvertFromGramsToMiligrams(valueInGrams);
            }
            if (ToUnit.Equals(Weight.g))
            {
                this.Result = valueInGrams;
            }
            if (ToUnit.Equals(Weight.dkg))
            {
                this.Result = this.ConvertFromGramsToDecagrams(valueInGrams);
            }
            if (ToUnit.Equals(Weight.kg))
            {
                this.Result = this.ConvertFromGramsToKilograms(valueInGrams);
            }
            if (ToUnit.Equals(Weight.T))
            {
                this.Result = this.ConvertFromGramsToTons(valueInGrams);
            }
            if (ToUnit.Equals(Weight.oz))
            {
                this.Result = this.ConvertFromGramsToOunce(valueInGrams);
            }
            if (ToUnit.Equals(Weight.lbs))
            {
                this.Result = this.ConvertFromGramsToPounds(valueInGrams);
            }
            if (ToUnit.Equals(Weight.ct))
            {
                this.Result = this.ConvertFromGramsToCarats(valueInGrams);
            }
            if (ToUnit.Equals(Weight.q))
            {
                this.Result = this.ConvertFromGramsToCental(valueInGrams);
            }
        }

        private double ConvertFromGramsToMiligrams(double value)
        {
            return value * 1000;
        }
        private double ConvertFromGramsToDecagrams(double value)
        {
            return value / 10.0;
        }
        private double ConvertFromGramsToKilograms(double value)
        {
            return value / 1000;
        }
        private double ConvertFromGramsToOunce(double value)
        {
            return value / 28.3495231;
        }
        private double ConvertFromGramsToPounds(double value)
        {
            return value / 453.59237;
        }
        private double ConvertFromGramsToCarats(double value)
        {
            return value / 0.2;
        }
        private double ConvertFromGramsToCental(double value)
        {
            return value / 100000;
        }
        private double ConvertFromGramsToTons(double value)
        {
            return value / 1000000;
        }

        private double ConvertToGrams()
        {
            double result = 0;
            if (this.FromUnit.Equals(Weight.g))
            {
                result = this.Value;
            }
            else
            {
                if (this.FromUnit.Equals(Weight.mg))
                {
                    result = this.Value / 1000.0;
                }
                if (this.FromUnit.Equals(Weight.g))
                {
                    result = this.Value;
                }
                if (this.FromUnit.Equals(Weight.dkg))
                {
                    result = this.Value * 10;
                }
                if (this.FromUnit.Equals(Weight.kg))
                {
                    result = this.Value * 1000;
                }
                if (this.FromUnit.Equals(Weight.T))
                {
                    result = this.Value * 1000000;
                }
                if (this.FromUnit.Equals(Weight.lbs))
                {
                    result = this.Value * 453.59237;
                }
                if (this.FromUnit.Equals(Weight.oz))
                {
                    result = this.Value * 28.3495231;
                }
                if (this.FromUnit.Equals(Weight.ct))
                {
                    result = this.Value * 0.2;
                }
                if (this.FromUnit.Equals(Weight.q))
                {
                    result = this.Value * 100000;
                }
            }
            return result;
        }
    }
}
