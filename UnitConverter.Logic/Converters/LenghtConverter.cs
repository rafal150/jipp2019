using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter.Converters
{
    class LenghtConverter : IConverter
    {
        public string Name => "Długości";
        public List<string> Units => new List<string>(new[] { "MM", "CM", "DCM", "M", "KM", "CAL", "JARD", "MILA", "MILA_MORSKA" });

        public double Convert(string unitFrom, string unitTo, double value)
        {
            Lenght from = (Lenght)System.Enum.Parse(typeof(Lenght), unitFrom);
            Lenght to = (Lenght)System.Enum.Parse(typeof(Lenght), unitTo);

            if (from == Lenght.MM && to == Lenght.MM) { return value; }
            if (from == Lenght.MM && to == Lenght.CM) { return (value * 0.1); }
            if (from == Lenght.MM && to == Lenght.M) { return (value * 0.001); }
            if (from == Lenght.MM && to == Lenght.DCM) { return (value * 0.01); }
            if (from == Lenght.MM && to == Lenght.KM) { return (value * 0.000001); }
            if (from == Lenght.MM && to == Lenght.MILA) { return (value * 0.0000006214); }
            if (from == Lenght.MM && to == Lenght.MILA_MORSKA) { return (value * 0.00000054); }
            if (from == Lenght.MM && to == Lenght.CAL) { return (value * 0.039370); }
            if (from == Lenght.MM && to == Lenght.JARD) { return (value * 0.001093); }

            if (from == Lenght.CM && to == Lenght.CM) { return value; }
            if (from == Lenght.CM && to == Lenght.MM) { return (value * 10); }
            if (from == Lenght.CM && to == Lenght.M) { return (value * 100); }
            if (from == Lenght.CM && to == Lenght.DCM) { return (value * 0.1); }
            if (from == Lenght.CM && to == Lenght.KM) { return (value * 0.00001); }
            if (from == Lenght.CM && to == Lenght.MILA) { return (value * 0.000006214); }
            if (from == Lenght.CM && to == Lenght.MILA_MORSKA) { return (value * 0.0000054); }
            if (from == Lenght.CM && to == Lenght.CAL) { return (value * 0.39370); }
            if (from == Lenght.CM && to == Lenght.JARD) { return (value * 0.01093); }

            if (from == Lenght.M && to == Lenght.M) { return value; }
            if (from == Lenght.M && to == Lenght.MM) { return (value * 1000); }
            if (from == Lenght.M && to == Lenght.CM) { return (value * 100); }
            if (from == Lenght.M && to == Lenght.DCM) { return (value * 10); }
            if (from == Lenght.M && to == Lenght.KM) { return (value * 0.001); }
            if (from == Lenght.M && to == Lenght.MILA) { return (value * 0.1); }
            if (from == Lenght.M && to == Lenght.MILA_MORSKA) { return (value * 0.0006214); }
            if (from == Lenght.M && to == Lenght.CAL) { return (value * 39.370); }
            if (from == Lenght.M && to == Lenght.JARD) { return (value * 1.093); }

            if (from == Lenght.DCM && to == Lenght.DCM) { return value; }
            if (from == Lenght.DCM && to == Lenght.MM) { return (value * 100); }
            if (from == Lenght.DCM && to == Lenght.CM) { return (value * 10); }
            if (from == Lenght.DCM && to == Lenght.M) { return (value * 0.1); }
            if (from == Lenght.DCM && to == Lenght.KM) { return (value * 0.0001); }
            if (from == Lenght.DCM && to == Lenght.MILA) { return (value * 0.00006214); }
            if (from == Lenght.DCM && to == Lenght.MILA_MORSKA) { return (value * 0.000054); }
            if (from == Lenght.DCM && to == Lenght.CAL) { return (value * 3.9370); }
            if (from == Lenght.DCM && to == Lenght.JARD) { return (value * 0.1093); }

            if (from == Lenght.KM && to == Lenght.KM) { return value; }
            if (from == Lenght.KM && to == Lenght.MM) { return (value * 1000000); }
            if (from == Lenght.KM && to == Lenght.CM) { return (value * 100000); }
            if (from == Lenght.KM && to == Lenght.M) { return (value * 1000); }
            if (from == Lenght.KM && to == Lenght.DCM) { return (value * 10000); }
            if (from == Lenght.KM && to == Lenght.MILA) { return (value * 0.6214); }
            if (from == Lenght.KM && to == Lenght.MILA_MORSKA) { return (value * 0.54); }
            if (from == Lenght.KM && to == Lenght.CAL) { return (value * 39370); }
            if (from == Lenght.KM && to == Lenght.JARD) { return (value * 1093); }

            if (from == Lenght.MILA && to == Lenght.MILA) { return value; }
            if (from == Lenght.MILA && to == Lenght.MM) { return (value * 1609344); }
            if (from == Lenght.MILA && to == Lenght.CM) { return (value * 160934.4); }
            if (from == Lenght.MILA && to == Lenght.M) { return (value * 1609.344); }
            if (from == Lenght.MILA && to == Lenght.DCM) { return (value * 16093.44); }
            if (from == Lenght.MILA && to == Lenght.KM) { return (value * 1.609344); }
            if (from == Lenght.MILA && to == Lenght.MILA_MORSKA) { return (value * 0.8689); }
            if (from == Lenght.MILA && to == Lenght.CAL) { return (value * 63360); }
            if (from == Lenght.MILA && to == Lenght.JARD) { return (value * 1760); }

            if (from == Lenght.MILA_MORSKA && to == Lenght.MILA_MORSKA) { return value; }
            if (from == Lenght.MILA_MORSKA && to == Lenght.MM) { return (value * 1852000); }
            if (from == Lenght.MILA_MORSKA && to == Lenght.CM) { return (value * 185200); }
            if (from == Lenght.MILA_MORSKA && to == Lenght.M) { return (value * 1852); }
            if (from == Lenght.MILA_MORSKA && to == Lenght.DCM) { return (value * 18520); }
            if (from == Lenght.MILA_MORSKA && to == Lenght.KM) { return (value * 1.852); }
            if (from == Lenght.MILA_MORSKA && to == Lenght.MILA) { return (value * 1.15); }
            if (from == Lenght.MILA_MORSKA && to == Lenght.CAL) { return (value * 72913.4); }
            if (from == Lenght.MILA_MORSKA && to == Lenght.JARD) { return (value * 2025.4); }

            if (from == Lenght.CAL && to == Lenght.CAL) { return value; }
            if (from == Lenght.CAL && to == Lenght.MM) { return (value * 25.4); }
            if (from == Lenght.CAL && to == Lenght.CM) { return (value * 2.54); }
            if (from == Lenght.CAL && to == Lenght.M) { return (value * 0.0254); }
            if (from == Lenght.CAL && to == Lenght.DCM) { return (value * 0.254); }
            if (from == Lenght.CAL && to == Lenght.KM) { return (value * 0.0000254); }
            if (from == Lenght.CAL && to == Lenght.MILA) { return (value * 0.00001578); }
            if (from == Lenght.CAL && to == Lenght.MILA_MORSKA) { return (value * 0.0000137); }
            if (from == Lenght.CAL && to == Lenght.JARD) { return (value * 0.0277); }

            if (from == Lenght.JARD && to == Lenght.JARD) { return value; }
            if (from == Lenght.JARD && to == Lenght.MM) { return (value * 914.4); }
            if (from == Lenght.JARD && to == Lenght.CM) { return (value * 91.44); }
            if (from == Lenght.JARD && to == Lenght.M) { return (value * 0.9144); }
            if (from == Lenght.JARD && to == Lenght.DCM) { return (value * 9.144); }
            if (from == Lenght.JARD && to == Lenght.KM) { return (value * 0.0009144); }
            if (from == Lenght.JARD && to == Lenght.MILA) { return (value * 0.0005681); }
            if (from == Lenght.JARD && to == Lenght.MILA_MORSKA) { return (value * 0.0004937); }
            if (from == Lenght.JARD && to == Lenght.CAL) { return (value * 36); }
            return 0;
        }
    }
}
