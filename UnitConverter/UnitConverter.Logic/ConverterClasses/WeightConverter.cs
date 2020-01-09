﻿using System.Collections.Generic;

namespace UnitConversion
{
    [ConverterClassType(ClassType.Constant)]
    public class WeightConverter : UnitConverter
    {
        private string name = "Konwerter masy";
        public override string Name
        {
            get => name;
            set => name = value;
        }

        public WeightConverter()
        {
            FillUnits();
        }

        private void FillUnits()
        {
            units = new Dictionary<string, Unit>();
            units.Add("mg", new Unit("mg", (x) => x, (x) => x));
            units.Add("g", new Unit("g", (x) => x / 1000m, (x) => x * 1000m));
            units.Add("dkg", new Unit("dkg", (x) => x / 10000m, (x) => x * 10000m));
            units.Add("kg", new Unit("kg", (x) => x / 1000000m, (x) => x * 1000000));
            units.Add("T", new Unit("T", (x) => x / 1000000000m, (x) => x * 1000000000));
            units.Add("uncja", new Unit("uncja", (x) => x / 28349.5231m, (x) => x * 28349.5231m));
            units.Add("funt", new Unit("funt", (x) => x / 453592.37m, (x) => x * 453592.37m));
            units.Add("karat", new Unit("karat", (x) => x / 200m, (x) => x * 200m));
            units.Add("kwintal", new Unit("kwintal", (x) => x / 100000000m, (x) => x * 100000000m));
        }


    }
}
