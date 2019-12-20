using System.Collections.Generic;

namespace UnitConversion
{
    public abstract class UnitConverter
    {
        public abstract string Name { get; }
        public abstract Dictionary<string, Unit> Units { get; }
        public Unit BaseUnit { get; set; }
        public Unit TargetUnit { get; set; }
        public decimal Convert(decimal sourceValue)
        {
            decimal baseValue = BaseUnit.ToBaseValue.Invoke(sourceValue);
            return TargetUnit.FromBaseValue(baseValue);
        }

        public bool SetUnits(string unitFrom, string unitTo)
        {
            if (Units.ContainsKey(unitFrom) == false || Units.ContainsKey(unitTo) == false) return false;
            BaseUnit = Units[unitFrom];
            TargetUnit = Units[unitTo];
            return true;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
