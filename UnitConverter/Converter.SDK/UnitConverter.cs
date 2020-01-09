using System.Collections.Generic;
using System.Linq;

namespace UnitConversion
{
    public abstract class UnitConverter
    {
        protected Dictionary<string, Unit> units;
        public abstract string Name { get; set; }
        public List<string> Units => units != null ? units.Keys.ToList() : new List<string>();
        //protected Unit BaseUnit { get; private set; }
        //protected Unit TargetUnit { get; private set; }
        public decimal Convert(string unitFrom, string unitTo, decimal sourceValue)
        {
            if (units.ContainsKey(unitFrom) == false || units.ContainsKey(unitTo) == false) throw new System.Exception("Invalid UnitFrom or UnitTo");
            decimal baseValue = units[unitFrom].ToBaseValue.Invoke(sourceValue);
            return units[unitTo].FromBaseValue(baseValue);
        }

        //public bool SetUnits(string unitFrom, string unitTo)
        //{
        //    if (units.ContainsKey(unitFrom) == false || units.ContainsKey(unitTo) == false) return false;
        //    BaseUnit = units[unitFrom];
        //    TargetUnit = units[unitTo];
        //    return true;
        //}

        public override string ToString()
        {
            return Name;
        }
    }

}
