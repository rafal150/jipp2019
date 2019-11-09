using System;

namespace UnitConversion
{
    public class Unit
    {
        public string Name { get; private set; }
        public decimal BaseValue { get; private set; }
        public Func<decimal, decimal> ToBaseValue { get; private set; }
        public Func<decimal, decimal> FromBaseValue { get; private set; }

        public Unit(string name, Func<decimal, decimal> fromBaseValue, Func<decimal, decimal> toBaseValue)
        {
            Name = name;
            ToBaseValue = toBaseValue;
            FromBaseValue = fromBaseValue;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
