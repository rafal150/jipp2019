using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitCoverterPart2.Services
{
    public class VoltageConverter : IConverter
    {
        public string Name => "Napiecie";

        public List<string> Units => new List<string>(new[] { "mv", "v", "kv" });

        public decimal Convert(string unitFrom, string unitTo, decimal value)
        {
            decimal valueInVolts = this.ConvertToVolts(unitFrom, value);
            decimal result = 0;
            if (unitTo.Equals("mv"))
            {
                result = this.ConvertFromVoltsToMiliVolts(valueInVolts);
            }
            if (unitTo.Equals("v"))
            {
                result = valueInVolts;
            }
            if (unitTo.Equals("kv"))
            {
                result = this.ConvertFromVoltsToKiloVolts(valueInVolts);
            }
            return result;
        }

        private decimal ConvertToVolts(string unitFrom,decimal value)
        {
            decimal result = 0;
            if (unitFrom.Equals("v"))
            {
                result = value;
            }
            else
            {
                if (unitFrom.Equals("mv"))
                {
                    result = value / (decimal)1000.0;
                }
                if (unitFrom.Equals("kv"))
                {
                    result = value * (decimal)1000.0;
                }
            }
            return result;
        }

        private decimal ConvertFromVoltsToMiliVolts(decimal value)
        {
            return value * (decimal)1000.0;
        }
        private decimal ConvertFromVoltsToKiloVolts(decimal value)
        {
            return value / (decimal)1000.0;
        }

    }
}
