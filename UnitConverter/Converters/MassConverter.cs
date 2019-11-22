using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter.Converters
{
    class MassConverter : IConverter
    {
        public string Name => "Mass";
        public List<string> Units => new List<string>(new[] {"MG","G","DKG", "KG", "T", "UNCJA", "FUNT", "KARAT", "KWINTAL" });

        public double Convert(string unitFrom, string unitTo, double a)
        {
            MassUnit from = (MassUnit)System.Enum.Parse(typeof(MassUnit), unitFrom);
            MassUnit to = (MassUnit)System.Enum.Parse(typeof(MassUnit), unitTo);
            if (from == MassUnit.MG && to == MassUnit.MG) { return a; }
            if (from == MassUnit.MG && to == MassUnit.G) { return new UnitOf.Mass().FromMilligrams(a).ToGrams(); }
            if (from == MassUnit.MG && to == MassUnit.KG) { return new UnitOf.Mass().FromMilligrams(a).ToKilograms(); }
            if (from == MassUnit.MG && to == MassUnit.DKG) { return new UnitOf.Mass().FromMilligrams(a).ToDekagrams(); }
            if (from == MassUnit.MG && to == MassUnit.T) { return new UnitOf.Mass().FromMilligrams(a).ToTonsMetric(); }
            if (from == MassUnit.MG && to == MassUnit.UNCJA) { return new UnitOf.Mass().FromMilligrams(a).ToOuncesMetric(); }
            if (from == MassUnit.MG && to == MassUnit.FUNT) { return new UnitOf.Mass().FromMilligrams(a).ToPounds(); }
            if (from == MassUnit.MG && to == MassUnit.KARAT) { return new UnitOf.Mass().FromMilligrams(a).ToCarats(); }

            if (from == MassUnit.G && to == MassUnit.G) { return a; }
            if (from == MassUnit.G && to == MassUnit.MG) { return new UnitOf.Mass().FromGrams(a).ToMilligrams(); }
            if (from == MassUnit.G && to == MassUnit.KG) { return new UnitOf.Mass().FromGrams(a).ToKilograms(); }
            if (from == MassUnit.G && to == MassUnit.DKG) { return new UnitOf.Mass().FromGrams(a).ToDekagrams(); }
            if (from == MassUnit.G && to == MassUnit.T) { return new UnitOf.Mass().FromGrams(a).ToTonsMetric(); }
            if (from == MassUnit.G && to == MassUnit.UNCJA) { return new UnitOf.Mass().FromGrams(a).ToOuncesMetric(); }
            if (from == MassUnit.G && to == MassUnit.FUNT) { return new UnitOf.Mass().FromGrams(a).ToPounds(); }
            if (from == MassUnit.G && to == MassUnit.KARAT) { return new UnitOf.Mass().FromGrams(a).ToCarats(); }

            if (from == MassUnit.KG && to == MassUnit.KG) { return a; }
            if (from == MassUnit.KG && to == MassUnit.MG) { return new UnitOf.Mass().FromKilograms(a).ToMilligrams(); }
            if (from == MassUnit.KG && to == MassUnit.G) { return new UnitOf.Mass().FromKilograms(a).ToGrams(); }
            if (from == MassUnit.KG && to == MassUnit.DKG) { return new UnitOf.Mass().FromKilograms(a).ToDekagrams(); }
            if (from == MassUnit.KG && to == MassUnit.T) { return new UnitOf.Mass().FromKilograms(a).ToTonsMetric(); }
            if (from == MassUnit.KG && to == MassUnit.UNCJA) { return new UnitOf.Mass().FromKilograms(a).ToOuncesMetric(); }
            if (from == MassUnit.KG && to == MassUnit.FUNT) { return new UnitOf.Mass().FromKilograms(a).ToPounds(); }
            if (from == MassUnit.KG && to == MassUnit.KARAT) { return new UnitOf.Mass().FromKilograms(a).ToCarats(); }

            if (from == MassUnit.DKG && to == MassUnit.DKG) { return a; }
            if (from == MassUnit.DKG && to == MassUnit.MG) { return new UnitOf.Mass().FromDekagrams(a).ToMilligrams(); }
            if (from == MassUnit.DKG && to == MassUnit.G) { return new UnitOf.Mass().FromDekagrams(a).ToGrams(); }
            if (from == MassUnit.DKG && to == MassUnit.KG) { return new UnitOf.Mass().FromDekagrams(a).ToKilograms(); }
            if (from == MassUnit.DKG && to == MassUnit.T) { return new UnitOf.Mass().FromDekagrams(a).ToTonsMetric(); }
            if (from == MassUnit.DKG && to == MassUnit.UNCJA) { return new UnitOf.Mass().FromDekagrams(a).ToOuncesMetric(); }
            if (from == MassUnit.DKG && to == MassUnit.FUNT) { return new UnitOf.Mass().FromDekagrams(a).ToPounds(); }
            if (from == MassUnit.DKG && to == MassUnit.KARAT) { return new UnitOf.Mass().FromDekagrams(a).ToCarats(); }

            if (from == MassUnit.T && to == MassUnit.T) { return a; }
            if (from == MassUnit.T && to == MassUnit.MG) { return new UnitOf.Mass().FromTonsMetric(a).ToMilligrams(); }
            if (from == MassUnit.T && to == MassUnit.G) { return new UnitOf.Mass().FromTonsMetric(a).ToGrams(); }
            if (from == MassUnit.T && to == MassUnit.KG) { return new UnitOf.Mass().FromTonsMetric(a).ToKilograms(); }
            if (from == MassUnit.T && to == MassUnit.DKG) { return new UnitOf.Mass().FromTonsMetric(a).ToDekagrams(); }
            if (from == MassUnit.T && to == MassUnit.UNCJA) { return new UnitOf.Mass().FromTonsMetric(a).ToOuncesMetric(); }
            if (from == MassUnit.T && to == MassUnit.FUNT) { return new UnitOf.Mass().FromTonsMetric(a).ToPounds(); }
            if (from == MassUnit.T && to == MassUnit.KARAT) { return new UnitOf.Mass().FromTonsMetric(a).ToCarats(); }

            if (from == MassUnit.UNCJA && to == MassUnit.UNCJA) { return a; }
            if (from == MassUnit.UNCJA && to == MassUnit.MG) { return new UnitOf.Mass().FromOuncesMetric(a).ToMilligrams(); }
            if (from == MassUnit.UNCJA && to == MassUnit.G) { return new UnitOf.Mass().FromOuncesMetric(a).ToGrams(); }
            if (from == MassUnit.UNCJA && to == MassUnit.KG) { return new UnitOf.Mass().FromOuncesMetric(a).ToKilograms(); }
            if (from == MassUnit.UNCJA && to == MassUnit.DKG) { return new UnitOf.Mass().FromOuncesMetric(a).ToDekagrams(); }
            if (from == MassUnit.UNCJA && to == MassUnit.T) { return new UnitOf.Mass().FromOuncesMetric(a).ToTonsMetric(); }
            if (from == MassUnit.UNCJA && to == MassUnit.FUNT) { return new UnitOf.Mass().FromOuncesMetric(a).ToPounds(); }
            if (from == MassUnit.UNCJA && to == MassUnit.KARAT) { return new UnitOf.Mass().FromOuncesMetric(a).ToCarats(); }

            if (from == MassUnit.FUNT && to == MassUnit.FUNT) { return a; }
            if (from == MassUnit.FUNT && to == MassUnit.MG) { return new UnitOf.Mass().FromPounds(a).ToMilligrams(); }
            if (from == MassUnit.FUNT && to == MassUnit.G) { return new UnitOf.Mass().FromPounds(a).ToGrams(); }
            if (from == MassUnit.FUNT && to == MassUnit.KG) { return new UnitOf.Mass().FromPounds(a).ToKilograms(); }
            if (from == MassUnit.FUNT && to == MassUnit.DKG) { return new UnitOf.Mass().FromPounds(a).ToDekagrams(); }
            if (from == MassUnit.FUNT && to == MassUnit.T) { return new UnitOf.Mass().FromPounds(a).ToTonsMetric(); }
            if (from == MassUnit.FUNT && to == MassUnit.UNCJA) { return new UnitOf.Mass().FromPounds(a).ToOuncesMetric(); }
            if (from == MassUnit.FUNT && to == MassUnit.KARAT) { return new UnitOf.Mass().FromPounds(a).ToCarats(); }


            if (from == MassUnit.KARAT && to == MassUnit.KARAT) { return a; }
            if (from == MassUnit.KARAT && to == MassUnit.MG) { return new UnitOf.Mass().FromCarats(a).ToMilligrams(); }
            if (from == MassUnit.KARAT && to == MassUnit.G) { return new UnitOf.Mass().FromCarats(a).ToGrams(); }
            if (from == MassUnit.KARAT && to == MassUnit.KG) { return new UnitOf.Mass().FromCarats(a).ToKilograms(); }
            if (from == MassUnit.KARAT && to == MassUnit.DKG) { return new UnitOf.Mass().FromCarats(a).ToDekagrams(); }
            if (from == MassUnit.KARAT && to == MassUnit.T) { return new UnitOf.Mass().FromCarats(a).ToTonsMetric(); }
            if (from == MassUnit.KARAT && to == MassUnit.UNCJA) { return new UnitOf.Mass().FromCarats(a).ToOuncesMetric(); }
            if (from == MassUnit.KARAT && to == MassUnit.FUNT) { return new UnitOf.Mass().FromCarats(a).ToPounds(); }
            return 0;
        }
    }
}
