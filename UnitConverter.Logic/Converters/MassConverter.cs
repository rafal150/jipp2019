using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter.Converters
{
    class MassConverter : IConverter
    {
        public string Name => "Masy";
        public List<string> Units => new List<string>(new[] { "MG", "G", "DKG", "KG", "T", "UNCJA", "FUNT", "KARAT" });

        public double Convert(string unitFrom, string unitTo, double value)
        {
            Mass from = (Mass)System.Enum.Parse(typeof(Mass), unitFrom);
            Mass to = (Mass)System.Enum.Parse(typeof(Mass), unitTo);
            if (from == Mass.MG && to == Mass.MG) { return value; }
            if (from == Mass.MG && to == Mass.G) { return (value * 0.001); }
            if (from == Mass.MG && to == Mass.KG) { return (value * 0.000001); }
            if (from == Mass.MG && to == Mass.DKG) { return (value * 0.0001); }
            if (from == Mass.MG && to == Mass.T) { return (value * 0.000000001); }
            if (from == Mass.MG && to == Mass.UNCJA) { return (value * 0.000035274); }
            if (from == Mass.MG && to == Mass.FUNT) { return (value * 0.0000022); }
            if (from == Mass.MG && to == Mass.KARAT) { return (value * 0.00488); }

            if (from == Mass.G && to == Mass.G) { return value; }
            if (from == Mass.G && to == Mass.MG) { return (value * 1000); }
            if (from == Mass.G && to == Mass.KG) { return (value * 0.001); }
            if (from == Mass.G && to == Mass.DKG) { return (value * 0.1); }
            if (from == Mass.G && to == Mass.T) { return (value * 0.000001); }
            if (from == Mass.G && to == Mass.UNCJA) { return (value * 0.03527); }
            if (from == Mass.G && to == Mass.FUNT) { return (value * 0.0022); }
            if (from == Mass.G && to == Mass.KARAT) { return (value * 5); }

            if (from == Mass.KG && to == Mass.KG) { return value; }
            if (from == Mass.KG && to == Mass.MG) { return (value * 1000000); }
            if (from == Mass.KG && to == Mass.G) { return (value * 1000); }
            if (from == Mass.KG && to == Mass.DKG) { return (value * 100); }
            if (from == Mass.KG && to == Mass.T) { return (value * 0.001); }
            if (from == Mass.KG && to == Mass.UNCJA) { return (value * 35.274); }
            if (from == Mass.KG && to == Mass.FUNT) { return (value * 2.2046); }
            if (from == Mass.KG && to == Mass.KARAT) { return (value * 5000); }

            if (from == Mass.DKG && to == Mass.DKG) { return value; }
            if (from == Mass.DKG && to == Mass.MG) { return (value * 10000); }
            if (from == Mass.DKG && to == Mass.G) { return (value * 10); }
            if (from == Mass.DKG && to == Mass.KG) { return (value * 0.01); }
            if (from == Mass.DKG && to == Mass.T) { return (value * 0.00001); }
            if (from == Mass.DKG && to == Mass.UNCJA) { return (value * 0.3527); }
            if (from == Mass.DKG && to == Mass.FUNT) { return (value * 0.022); }
            if (from == Mass.DKG && to == Mass.KARAT) { return (value * 50); }

            if (from == Mass.T && to == Mass.T) { return value; }
            if (from == Mass.T && to == Mass.MG) { return (value * 1000000000); }
            if (from == Mass.T && to == Mass.G) { return (value * 1000000); }
            if (from == Mass.T && to == Mass.KG) { return (value * 1000); }
            if (from == Mass.T && to == Mass.DKG) { return (value * 100000); }
            if (from == Mass.T && to == Mass.UNCJA) { return (value * 35273); }
            if (from == Mass.T && to == Mass.FUNT) { return (value * 2204); }
            if (from == Mass.T && to == Mass.KARAT) { return (value * 5); }

            if (from == Mass.UNCJA && to == Mass.UNCJA) { return value; }
            if (from == Mass.UNCJA && to == Mass.MG) { return (value * 28349.523); }
            if (from == Mass.UNCJA && to == Mass.G) { return (value * 28.3495); }
            if (from == Mass.UNCJA && to == Mass.KG) { return (value * 0.0283); }
            if (from == Mass.UNCJA && to == Mass.DKG) { return (value * 2.835); }
            if (from == Mass.UNCJA && to == Mass.T) { return (value * 2.835); }
            if (from == Mass.UNCJA && to == Mass.FUNT) { return (value * 0.0625); }
            if (from == Mass.UNCJA && to == Mass.KARAT) { return (value * 141.7476); }

            if (from == Mass.FUNT && to == Mass.FUNT) { return value; }
            if (from == Mass.FUNT && to == Mass.MG) { return (value * 4.5359); }
            if (from == Mass.FUNT && to == Mass.G) { return (value * 453.5924); }
            if (from == Mass.FUNT && to == Mass.KG) { return (value * 0.4536); }
            if (from == Mass.FUNT && to == Mass.DKG) { return (value * 45.3592); }
            if (from == Mass.FUNT && to == Mass.T) { return (value * 0.0005); }
            if (from == Mass.FUNT && to == Mass.UNCJA) { return (value * 16); }
            if (from == Mass.FUNT && to == Mass.KARAT) { return (value * 2267.9619); }


            if (from == Mass.KARAT && to == Mass.KARAT) { return value; }
            if (from == Mass.KARAT && to == Mass.MG) { return (value * 200); }
            if (from == Mass.KARAT && to == Mass.G) { return (value * 0.2); }
            if (from == Mass.KARAT && to == Mass.KG) { return (value * 0.0002); }
            if (from == Mass.KARAT && to == Mass.DKG) { return (value * 0.02); }
            if (from == Mass.KARAT && to == Mass.T) { return (value * 2); }
            if (from == Mass.KARAT && to == Mass.UNCJA) { return (value * 0.0071); }
            if (from == Mass.KARAT && to == Mass.FUNT) { return (value * 0.0004); }
            return 0;
        }
    }
}
