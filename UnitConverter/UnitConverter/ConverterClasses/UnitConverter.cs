using System.Collections.Generic;

namespace UnitConversion
{
    public abstract class UnitConverter
    {
        public abstract string Name { get; }
        public abstract List<Unit> Units { get; }
        public Unit BaseUnit { get; set; }
        public Unit TargetUnit { get; set; }
        public decimal Convert(decimal sourceValue)
        {
            decimal baseValue = BaseUnit.ToBaseValue.Invoke(sourceValue);
            return TargetUnit.FromBaseValue(baseValue);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
