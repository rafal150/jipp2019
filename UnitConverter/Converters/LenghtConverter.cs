using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter.Converters
{
    class LenghtConverter : IConverter
    {
        public string Name => "Lenght";
        public List<string> Units => new List<string>(new[] { "MM", "CM", "DCM", "M", "KM", "CAL", "JARD", "MILA", "KABEL","MILA_MORSKA" });

        public double Convert(string unitFrom, string unitTo, double a)
        {
            LenghtUnit from = (LenghtUnit)System.Enum.Parse(typeof(LenghtUnit), unitFrom);
            LenghtUnit to = (LenghtUnit)System.Enum.Parse(typeof(LenghtUnit), unitTo);

            if (from == LenghtUnit.MM && to == LenghtUnit.MM) { return a; }
            if (from == LenghtUnit.MM && to == LenghtUnit.CM) { return new UnitOf.Length().FromMillimeters(a).ToCentimeters(); }
            if (from == LenghtUnit.MM && to == LenghtUnit.M) { return new UnitOf.Length().FromMillimeters(a).ToMeters(); }
            if (from == LenghtUnit.MM && to == LenghtUnit.DCM) { return new UnitOf.Length().FromMillimeters(a).ToDecimeters(); }
            if (from == LenghtUnit.MM && to == LenghtUnit.KM) { return new UnitOf.Length().FromMillimeters(a).ToKilometers(); }
            if (from == LenghtUnit.MM && to == LenghtUnit.MILA) { return new UnitOf.Length().FromMillimeters(a).ToMiles(); }
            if (from == LenghtUnit.MM && to == LenghtUnit.MILA_MORSKA) { return new UnitOf.Length().FromMillimeters(a).ToNauticalMilesInternational(); }
            if (from == LenghtUnit.MM && to == LenghtUnit.CAL) { return new UnitOf.Length().FromMillimeters(a).ToInches(); }
            if (from == LenghtUnit.MM && to == LenghtUnit.JARD) { return new UnitOf.Length().FromMillimeters(a).ToYards(); }

            if (from == LenghtUnit.CM && to == LenghtUnit.CM) { return a; }
            if (from == LenghtUnit.CM && to == LenghtUnit.MM) { return new UnitOf.Length().FromCentimeters(a).ToMillimeters(); }
            if (from == LenghtUnit.CM && to == LenghtUnit.M) { return new UnitOf.Length().FromCentimeters(a).ToMeters(); }
            if (from == LenghtUnit.CM && to == LenghtUnit.DCM) { return new UnitOf.Length().FromCentimeters(a).ToDecimeters(); }
            if (from == LenghtUnit.CM && to == LenghtUnit.KM) { return new UnitOf.Length().FromCentimeters(a).ToKilometers(); }
            if (from == LenghtUnit.CM && to == LenghtUnit.MILA) { return new UnitOf.Length().FromCentimeters(a).ToMiles(); }
            if (from == LenghtUnit.CM && to == LenghtUnit.MILA_MORSKA) { return new UnitOf.Length().FromCentimeters(a).ToNauticalMilesInternational(); }
            if (from == LenghtUnit.CM && to == LenghtUnit.CAL) { return new UnitOf.Length().FromCentimeters(a).ToInches(); }
            if (from == LenghtUnit.CM && to == LenghtUnit.JARD) { return new UnitOf.Length().FromCentimeters(a).ToYards(); }

            if (from == LenghtUnit.M && to == LenghtUnit.M) { return a; }
            if (from == LenghtUnit.M && to == LenghtUnit.MM) { return new UnitOf.Length().FromMeters(a).ToMillimeters(); }
            if (from == LenghtUnit.M && to == LenghtUnit.CM) { return new UnitOf.Length().FromMeters(a).ToCentimeters(); }
            if (from == LenghtUnit.M && to == LenghtUnit.DCM) { return new UnitOf.Length().FromMeters(a).ToDecimeters(); }
            if (from == LenghtUnit.M && to == LenghtUnit.KM) { return new UnitOf.Length().FromMeters(a).ToKilometers(); }
            if (from == LenghtUnit.M && to == LenghtUnit.MILA) { return new UnitOf.Length().FromMeters(a).ToMiles(); }
            if (from == LenghtUnit.M && to == LenghtUnit.MILA_MORSKA) { return new UnitOf.Length().FromMeters(a).ToNauticalMilesInternational(); }
            if (from == LenghtUnit.M && to == LenghtUnit.CAL) { return new UnitOf.Length().FromMeters(a).ToInches(); }
            if (from == LenghtUnit.M && to == LenghtUnit.JARD) { return new UnitOf.Length().FromMeters(a).ToYards(); }

            if (from == LenghtUnit.DCM && to == LenghtUnit.DCM) { return a; }
            if (from == LenghtUnit.DCM && to == LenghtUnit.MM) { return new UnitOf.Length().FromDecimeters(a).ToMillimeters(); }
            if (from == LenghtUnit.DCM && to == LenghtUnit.CM) { return new UnitOf.Length().FromDecimeters(a).ToCentimeters(); }
            if (from == LenghtUnit.DCM && to == LenghtUnit.M) { return new UnitOf.Length().FromDecimeters(a).ToMeters(); }
            if (from == LenghtUnit.DCM && to == LenghtUnit.KM) { return new UnitOf.Length().FromDecimeters(a).ToKilometers(); }
            if (from == LenghtUnit.DCM && to == LenghtUnit.MILA) { return new UnitOf.Length().FromDecimeters(a).ToMiles(); }
            if (from == LenghtUnit.DCM && to == LenghtUnit.MILA_MORSKA) { return new UnitOf.Length().FromDecimeters(a).ToNauticalMilesInternational(); }
            if (from == LenghtUnit.DCM && to == LenghtUnit.CAL) { return new UnitOf.Length().FromDecimeters(a).ToInches(); }
            if (from == LenghtUnit.DCM && to == LenghtUnit.JARD) { return new UnitOf.Length().FromDecimeters(a).ToYards(); }

            if (from == LenghtUnit.KM && to == LenghtUnit.KM) { return a; }
            if (from == LenghtUnit.KM && to == LenghtUnit.MM) { return new UnitOf.Length().FromKilometers(a).ToMillimeters(); }
            if (from == LenghtUnit.KM && to == LenghtUnit.CM) { return new UnitOf.Length().FromKilometers(a).ToCentimeters(); }
            if (from == LenghtUnit.KM && to == LenghtUnit.M) { return new UnitOf.Length().FromKilometers(a).ToMeters(); }
            if (from == LenghtUnit.KM && to == LenghtUnit.DCM) { return new UnitOf.Length().FromKilometers(a).ToDecimeters(); }
            if (from == LenghtUnit.KM && to == LenghtUnit.MILA) { return new UnitOf.Length().FromKilometers(a).ToMiles(); }
            if (from == LenghtUnit.KM && to == LenghtUnit.MILA_MORSKA) { return new UnitOf.Length().FromKilometers(a).ToNauticalMilesInternational(); }
            if (from == LenghtUnit.KM && to == LenghtUnit.CAL) { return new UnitOf.Length().FromKilometers(a).ToInches(); }
            if (from == LenghtUnit.KM && to == LenghtUnit.JARD) { return new UnitOf.Length().FromKilometers(a).ToYards(); }

            if (from == LenghtUnit.MILA && to == LenghtUnit.MILA) { return a; }
            if (from == LenghtUnit.MILA && to == LenghtUnit.MM) { return new UnitOf.Length().FromMiles(a).ToMillimeters(); }
            if (from == LenghtUnit.MILA && to == LenghtUnit.CM) { return new UnitOf.Length().FromMiles(a).ToCentimeters(); }
            if (from == LenghtUnit.MILA && to == LenghtUnit.M) { return new UnitOf.Length().FromMiles(a).ToMeters(); }
            if (from == LenghtUnit.MILA && to == LenghtUnit.DCM) { return new UnitOf.Length().FromMiles(a).ToDecimeters(); }
            if (from == LenghtUnit.MILA && to == LenghtUnit.KM) { return new UnitOf.Length().FromMiles(a).ToKilometers(); }
            if (from == LenghtUnit.MILA && to == LenghtUnit.MILA_MORSKA) { return new UnitOf.Length().FromMiles(a).ToNauticalMilesInternational(); }
            if (from == LenghtUnit.MILA && to == LenghtUnit.CAL) { return new UnitOf.Length().FromMiles(a).ToInches(); }
            if (from == LenghtUnit.MILA && to == LenghtUnit.JARD) { return new UnitOf.Length().FromMiles(a).ToYards(); }

            if (from == LenghtUnit.MILA_MORSKA && to == LenghtUnit.MILA_MORSKA) { return a; }
            if (from == LenghtUnit.MILA_MORSKA && to == LenghtUnit.MM) { return new UnitOf.Length().FromNauticalMilesInternational(a).ToMillimeters(); }
            if (from == LenghtUnit.MILA_MORSKA && to == LenghtUnit.CM) { return new UnitOf.Length().FromNauticalMilesInternational(a).ToCentimeters(); }
            if (from == LenghtUnit.MILA_MORSKA && to == LenghtUnit.M) { return new UnitOf.Length().FromNauticalMilesInternational(a).ToMeters(); }
            if (from == LenghtUnit.MILA_MORSKA && to == LenghtUnit.DCM) { return new UnitOf.Length().FromNauticalMilesInternational(a).ToDecimeters(); }
            if (from == LenghtUnit.MILA_MORSKA && to == LenghtUnit.KM) { return new UnitOf.Length().FromNauticalMilesInternational(a).ToKilometers(); }
            if (from == LenghtUnit.MILA_MORSKA && to == LenghtUnit.MILA) { return new UnitOf.Length().FromNauticalMilesInternational(a).ToMiles(); }
            if (from == LenghtUnit.MILA_MORSKA && to == LenghtUnit.CAL) { return new UnitOf.Length().FromNauticalMilesInternational(a).ToInches(); }
            if (from == LenghtUnit.MILA_MORSKA && to == LenghtUnit.JARD) { return new UnitOf.Length().FromNauticalMilesInternational(a).ToYards(); }

            if (from == LenghtUnit.CAL && to == LenghtUnit.CAL) { return a; }
            if (from == LenghtUnit.CAL && to == LenghtUnit.MM) { return new UnitOf.Length().FromInches(a).ToMillimeters(); }
            if (from == LenghtUnit.CAL && to == LenghtUnit.CM) { return new UnitOf.Length().FromInches(a).ToCentimeters(); }
            if (from == LenghtUnit.CAL && to == LenghtUnit.M) { return new UnitOf.Length().FromInches(a).ToMeters(); }
            if (from == LenghtUnit.CAL && to == LenghtUnit.DCM) { return new UnitOf.Length().FromInches(a).ToDecimeters(); }
            if (from == LenghtUnit.CAL && to == LenghtUnit.KM) { return new UnitOf.Length().FromInches(a).ToKilometers(); }
            if (from == LenghtUnit.CAL && to == LenghtUnit.MILA) { return new UnitOf.Length().FromInches(a).ToMiles(); }
            if (from == LenghtUnit.CAL && to == LenghtUnit.MILA_MORSKA) { return new UnitOf.Length().FromInches(a).ToNauticalMilesInternational(); }
            if (from == LenghtUnit.CAL && to == LenghtUnit.JARD) { return new UnitOf.Length().FromInches(a).ToYards(); }

            if (from == LenghtUnit.JARD && to == LenghtUnit.JARD) { return a; }
            if (from == LenghtUnit.JARD && to == LenghtUnit.MM) { return new UnitOf.Length().FromYards(a).ToMillimeters(); }
            if (from == LenghtUnit.JARD && to == LenghtUnit.CM) { return new UnitOf.Length().FromYards(a).ToCentimeters(); }
            if (from == LenghtUnit.JARD && to == LenghtUnit.M) { return new UnitOf.Length().FromYards(a).ToMeters(); }
            if (from == LenghtUnit.JARD && to == LenghtUnit.DCM) { return new UnitOf.Length().FromYards(a).ToDecimeters(); }
            if (from == LenghtUnit.JARD && to == LenghtUnit.KM) { return new UnitOf.Length().FromYards(a).ToKilometers(); }
            if (from == LenghtUnit.JARD && to == LenghtUnit.MILA) { return new UnitOf.Length().FromYards(a).ToMiles(); }
            if (from == LenghtUnit.JARD && to == LenghtUnit.MILA_MORSKA) { return new UnitOf.Length().FromYards(a).ToNauticalMilesInternational(); }
            if (from == LenghtUnit.JARD && to == LenghtUnit.CAL) { return new UnitOf.Length().FromYards(a).ToInches(); }
            return 0;
        }
    }
}
