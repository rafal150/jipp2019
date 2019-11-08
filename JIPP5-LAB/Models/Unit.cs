using JIPP5_LAB.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JIPP5_LAB.Models
{
    public class Unit
    {
        private readonly Dictionary<UnitTypes, Func<decimal, decimal>> factorDictionary;

        public string Name { get; }
        public string UnitSuffix { get; }
        public UnitTypes UnitType { get; }
        public string DisplayUnit => string.Format("{0} [{1}]", Name, UnitSuffix);

        public Unit(string name, string unitSuffix, UnitTypes unitType, Dictionary<UnitTypes, Func<decimal, decimal>> factors)
        {
            Name = name;
            UnitSuffix = unitSuffix;
            UnitType = unitType;
            factorDictionary = factors;
        }

        public decimal Calculate(decimal input, UnitTypes toUnit)
        {
            return factorDictionary[toUnit].Invoke(input);
        }
    }
}
