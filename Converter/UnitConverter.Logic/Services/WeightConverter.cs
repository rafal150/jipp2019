using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitCoverterPart2.Services
{
    public class WeightConverter : IConverter
    {
        public string Name => "Wagi";

        public List<string> Units => new List<string>(new[] { "mg", "g", "dkg", "kg", "T", "lbs", "oz", "ct", "q" });

        public decimal Convert(string unitFrom, string unitTo, decimal value)
        {
            decimal valueInGrams = ConvertToGrams(unitFrom, value);
            decimal result = 0;
            if (unitTo.Equals("mg"))
            {
                result = this.ConvertFromGramsToMiligrams(valueInGrams);
            }
            if (unitTo.Equals("g"))
            {
                result = valueInGrams;
            }
            if (unitTo.Equals("dkg"))
            {
                result = this.ConvertFromGramsToDecagrams(valueInGrams);
            }
            if (unitTo.Equals("kg"))
            {
                result = this.ConvertFromGramsToKilograms(valueInGrams);
            }
            if (unitTo.Equals("T"))
            {
                result = this.ConvertFromGramsToTons(valueInGrams);
            }
            if (unitTo.Equals("oz"))
            {
                result = this.ConvertFromGramsToOunce(valueInGrams);
            }
            if (unitTo.Equals("lbs"))
            {
                result = this.ConvertFromGramsToPounds(valueInGrams);
            }
            if (unitTo.Equals("ct"))
            {
                result = this.ConvertFromGramsToCarats(valueInGrams);
            }
            if (unitTo.Equals("q"))
            {
                result = this.ConvertFromGramsToCental(valueInGrams);
            }

            return result;
        }

        private decimal ConvertToGrams(string unitFrom, decimal value)
        {
            decimal result = 0;
            if (unitFrom.Equals("g"))
            {
                result = value;
            }
            else
            {
                if (unitFrom.Equals("mg"))
                {
                    result = value / (decimal)1000.0;
                }
                if (unitFrom.Equals("g"))
                {
                    result = value;
                }
                if (unitFrom.Equals("dkg"))
                {
                    result = value * (decimal)10;
                }
                if (unitFrom.Equals("kg"))
                {
                    result = value * (decimal)1000;
                }
                if (unitFrom.Equals("T"))
                {
                    result = value * (decimal)1000000;
                }
                if (unitFrom.Equals("lbs"))
                {
                    result = value * (decimal)453.59237;
                }
                if (unitFrom.Equals("oz"))
                {
                    result = value * (decimal)28.3495231;
                }
                if (unitFrom.Equals("ct"))
                {
                    result = value * (decimal)0.2;
                }
                if (unitFrom.Equals("q"))
                {
                    result = value * (decimal)100000;
                }
            }
            return result;
        }

        private decimal ConvertFromGramsToMiligrams(decimal value)
        {
            return value * (decimal)(decimal)1000;
        }
        private decimal ConvertFromGramsToDecagrams(decimal value)
        {
            return value / (decimal)10.0;
        }
        private decimal ConvertFromGramsToKilograms(decimal value)
        {
            return value / (decimal)1000;
        }
        private decimal ConvertFromGramsToOunce(decimal value)
        {
            return value / (decimal)28.3495231;
        }
        private decimal ConvertFromGramsToPounds(decimal value)
        {
            return value / (decimal)453.59237;
        }
        private decimal ConvertFromGramsToCarats(decimal value)
        {
            return value / (decimal)0.2;
        }
        private decimal ConvertFromGramsToCental(decimal value)
        {
            return value / (decimal)100000;
        }
        private decimal ConvertFromGramsToTons(decimal value)
        {
            return value / (decimal)1000000;
        }
    }
}
