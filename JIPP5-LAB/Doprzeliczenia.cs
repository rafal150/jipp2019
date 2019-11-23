using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JIPP5_LAB
{
    public class Doprzeliczenia
    {
        public List<Jednostka> Temperatury = new List<Jednostka>()
        {
            new Jednostka("Celsjusz", "°C", Jednostki.Celsius, new Dictionary<Jednostki, Func<decimal,decimal>>() {
                {Jednostki.Kelvin, (input)=>{ return input + (decimal)273.15; } },
                {Jednostki.Celsius, (input)=>{ return input; } },
                {Jednostki.Fahrenheit, (input)=>{ return ((input + 40) * (decimal)1.8)-40; } },
                {Jednostki.Rankine, (input)=>{ return (input + (decimal)273.15) * (decimal)1.8; } },
            }),
            new Jednostka("Kelvin", "°K", Jednostki.Kelvin, new Dictionary<Jednostki, Func<decimal, decimal>>() {
                {Jednostki.Kelvin, (input)=>{ return input; } },
                {Jednostki.Celsius, (input)=>{ return input - (decimal)273.15; } },
                {Jednostki.Fahrenheit, (input)=>{ return input * (decimal)1.8 - (decimal)459.67; } },
                {Jednostki.Rankine, (input)=>{ return input * (decimal)1.8; } },
            }),
            new Jednostka("Fahrenheit", "°F", Jednostki.Fahrenheit, new Dictionary<Jednostki, Func<decimal, decimal>>() {
                {Jednostki.Kelvin, (input)=>{ return (input + (decimal)459.67) * ((decimal)5/(decimal)9); } },
                {Jednostki.Celsius, (input)=>{ return (input-32)/(decimal)1.8; } },
                {Jednostki.Fahrenheit, (input)=>{ return input; } },
                {Jednostki.Rankine, (input)=>{ return input + (decimal)459.67; } },
            }),
            new Jednostka("Rankine", "°R", Jednostki.Rankine, new Dictionary<Jednostki, Func<decimal, decimal>>() {
                {Jednostki.Kelvin, (input)=>{ return input * ((decimal)5/(decimal)9); } },
                {Jednostki.Celsius, (input)=>{ return (input - (decimal)491.67) * ((decimal)5/(decimal)9); } },
                {Jednostki.Fahrenheit, (input)=>{ return input - (decimal)459.67; } },
                {Jednostki.Rankine, (input)=>{ return input; } },
            })
        };

        public List<Jednostka> Dlugosci = new List<Jednostka>()
        {
            new Jednostka("Milimetr", "mm", Jednostki.Millimeter, new Dictionary<Jednostki, Func<decimal, decimal>>()
            {
                {Jednostki.Millimeter, (input)=>{ return input; } },
                {Jednostki.Meter, (input)=>{ return input/1000; } },
                {Jednostki.Kilometer, (input)=>{ return input/1000000; } },
                {Jednostki.Centymeter, (input)=>{ return input * (decimal)0.1; } },
                {Jednostki.Decimeter, (input)=>{ return input * (decimal)0.01; } },
                {Jednostki.Mile, (input)=>{ return input * ((decimal)6.2137119223733/(decimal)10000000); } },
                {Jednostki.NauticalMile, (input)=>{ return input * ((decimal)5.3995680345572/(decimal)10000000); } },
                {Jednostki.Cable, (input)=>{ return input * ((decimal)4.55672208/1000000); } },
                {Jednostki.Yard, (input)=>{ return input * (decimal)0.0011963081929167; } },
                {Jednostki.Inch, (input)=>{ return input * (decimal)0.039370078740157; } },
                {Jednostki.Foot, (input)=>{ return input * (decimal)0.0032808398950131; } },
            }),
            new Jednostka("Metr", "m", Jednostki.Meter, new Dictionary<Jednostki, Func<decimal, decimal>>()
            {
                {Jednostki.Millimeter, (input)=>{ return input * 1000; } },
                {Jednostki.Meter, (input)=>{ return input; } },
                {Jednostki.Kilometer, (input)=>{ return input/1000; } },
                {Jednostki.Centymeter, (input)=>{ return input * (decimal)100; } },
                {Jednostki.Decimeter, (input)=>{ return input * (decimal)10; } },
                {Jednostki.Mile, (input)=>{ return input * ((decimal)6.2137119223733/(decimal)10000); } },
                {Jednostki.NauticalMile, (input)=>{ return input * ((decimal)5.3995680345572/(decimal)10000); } },
                {Jednostki.Cable, (input)=>{ return input * ((decimal)4.55672208/1000); } },
                {Jednostki.Yard, (input)=>{ return input * (decimal)1.1963081929167; } },
                {Jednostki.Inch, (input)=>{ return input * (decimal)39.370078740157; } },
                {Jednostki.Foot, (input)=>{ return input * (decimal)3.2808398950131; } },
            }),
            new Jednostka("Kilometr", "km", Jednostki.Kilometer, new Dictionary<Jednostki, Func<decimal, decimal>>()
            {
                {Jednostki.Millimeter, (input)=>{ return input * 1000000; } },
                {Jednostki.Meter, (input)=>{ return input * 1000; } },
                {Jednostki.Kilometer, (input)=>{ return input; } },
                {Jednostki.Centymeter, (input)=>{ return input * (decimal)100000; } },
                {Jednostki.Decimeter, (input)=>{ return input * (decimal)10000; } },
                {Jednostki.Mile, (input)=>{ return input * ((decimal)6.2137119223733/(decimal)10); } },
                {Jednostki.NauticalMile, (input)=>{ return input * ((decimal)5.3995680345572/(decimal)10); } },
                {Jednostki.Cable, (input)=>{ return input * ((decimal)4.55672208); } },
                {Jednostki.Yard, (input)=>{ return input * (decimal)1196.3081929167; } },
                {Jednostki.Inch, (input)=>{ return input * (decimal)39370.078740157; } },
                {Jednostki.Foot, (input)=>{ return input * (decimal)3280.8398950131; } },
            }),
            new Jednostka("Centymetr", "cm", Jednostki.Centymeter, new Dictionary<Jednostki, Func<decimal, decimal>>()
            {
                {Jednostki.Millimeter, (input)=>{ return input * 10; } },
                {Jednostki.Meter, (input)=>{ return input / 100; } },
                {Jednostki.Kilometer, (input)=>{ return input / 100000; } },
                {Jednostki.Centymeter, (input)=>{ return input; } },
                {Jednostki.Decimeter, (input)=>{ return input / (decimal)10; } },
                {Jednostki.Mile, (input)=>{ return input * ((decimal)6.2137119223733/(decimal)1000000); } },
                {Jednostki.NauticalMile, (input)=>{ return input * ((decimal)5.3995680345572/(decimal)100000); } },
                {Jednostki.Cable, (input)=>{ return input * ((decimal)4.55672208/10000); } },
                {Jednostki.Yard, (input)=>{ return input * (decimal)119.63081929167; } },
                {Jednostki.Inch, (input)=>{ return input * (decimal)3937.0078740157; } },
                {Jednostki.Foot, (input)=>{ return input * (decimal)328.08398950131; } },
            }),
            new Jednostka("Decymetr", "dm", Jednostki.Decimeter, new Dictionary<Jednostki, Func<decimal, decimal>>()
            {
                {Jednostki.Millimeter, (input)=>{ return input * 100; } },
                {Jednostki.Meter, (input)=>{ return input / 10; } },
                {Jednostki.Kilometer, (input)=>{ return input / 10000; } },
                {Jednostki.Centymeter, (input)=>{ return input * 10; } },
                {Jednostki.Decimeter, (input)=>{ return input; } },
                {Jednostki.Mile, (input)=>{ return input * ((decimal)6.2137119223733/(decimal)100000); } },
                {Jednostki.NauticalMile, (input)=>{ return input * ((decimal)5.3995680345572/(decimal)10000); } },
                {Jednostki.Cable, (input)=>{ return input * ((decimal)4.55672208/1000); } },
                {Jednostki.Yard, (input)=>{ return input * (decimal)11.963081929167; } },
                {Jednostki.Inch, (input)=>{ return input * (decimal)393.70078740157; } },
                {Jednostki.Foot, (input)=>{ return input * (decimal)32.808398950131; } },
            }),
            new Jednostka("Mila", "", Jednostki.Mile, new Dictionary<Jednostki, Func<decimal, decimal>>()
            {
                {Jednostki.Millimeter, (input)=>{ return input * 1609344; } },
                {Jednostki.Meter, (input)=>{ return input * (decimal)1609.344; } },
                {Jednostki.Kilometer, (input)=>{ return input * (decimal)1.609344; } },
                {Jednostki.Centymeter, (input)=>{ return input * (decimal)160934.4; } },
                {Jednostki.Decimeter, (input)=>{ return input * (decimal)16093.44; } },
                {Jednostki.Mile, (input)=>{ return input; } },
                {Jednostki.NauticalMile, (input)=>{ return input * (decimal)0.868976242; } },
                {Jednostki.Cable, (input)=>{ return input * (decimal)7.33333333; } },
                {Jednostki.Yard, (input)=>{ return input * 1760; } },
                {Jednostki.Inch, (input)=>{ return input * 63360; } },
                {Jednostki.Foot, (input)=>{ return input * 5280; } },
            }),
            new Jednostka("Mila Morska", "Nm", Jednostki.NauticalMile, new Dictionary<Jednostki, Func<decimal, decimal>>()
            {
                {Jednostki.Millimeter, (input)=>{ return input * 18520000; } },
                {Jednostki.Meter, (input)=>{ return input * 1852; } },
                {Jednostki.Kilometer, (input)=>{ return input * (1852/10000); } },
                {Jednostki.Centymeter, (input)=>{ return input * 185200; } },
                {Jednostki.Decimeter, (input)=>{ return input * 18520; } },
                {Jednostki.Mile, (input)=>{ return input * (decimal)1.15077945; } },
                {Jednostki.NauticalMile, (input)=>{ return input; } },
                {Jednostki.Cable, (input)=>{ return input * 10; } },
                {Jednostki.Yard, (input)=>{ return input * (decimal)2025.37183; } },
                {Jednostki.Inch, (input)=>{ return input * (decimal)72913.3858; } },
                {Jednostki.Foot, (input)=>{ return input * (decimal)6076.11549; } },
            }),
            new Jednostka("Kabel", "", Jednostki.Cable, new Dictionary<Jednostki, Func<decimal, decimal>>()
            {
                {Jednostki.Millimeter, (input)=>{ return input * (decimal)21945600; } },
                {Jednostki.Meter, (input)=>{ return input * (decimal)219.456; } },
                {Jednostki.Kilometer, (input)=>{ return input * (decimal)2.19456; } },
                {Jednostki.Centymeter, (input)=>{ return (decimal)21945.6; } },
                {Jednostki.Decimeter, (input)=>{ return input * (decimal)2194.56; } },
                {Jednostki.Mile, (input)=>{ return input * (decimal)0.13636363636364; } },
                {Jednostki.NauticalMile, (input)=>{ return input * (decimal)0.12; } },
                {Jednostki.Cable, (input)=>{ return input; } },
                {Jednostki.Yard, (input)=>{ return input * 240; } },
                {Jednostki.Inch, (input)=>{ return input * 8640; } },
                {Jednostki.Foot, (input)=>{ return input * 720; } },
            }),
            new Jednostka("Jard", "yd", Jednostki.Yard, new Dictionary<Jednostki, Func<decimal, decimal>>()
            {
                {Jednostki.Millimeter, (input)=>{ return input * (decimal)914.4; } },
                {Jednostki.Meter, (input)=>{ return input * (decimal)0.9144; } },
                {Jednostki.Kilometer, (input)=>{ return input * (decimal)0.0009144; } },
                {Jednostki.Centymeter, (input)=>{ return input * (decimal)91.44; } },
                {Jednostki.Decimeter, (input)=>{ return input * (decimal)9.14400; } },
                {Jednostki.Mile, (input)=>{ return input * (decimal)0.000568181818; } },
                {Jednostki.NauticalMile, (input)=>{ return input * (decimal)0.000493736501; } },
                {Jednostki.Cable, (input)=>{ return input * (decimal)0.00493421; } },
                {Jednostki.Yard, (input)=>{ return input; } },
                {Jednostki.Inch, (input)=>{ return input * 36; } },
                {Jednostki.Foot, (input)=>{ return input * 3; } },
            }),
            new Jednostka("Cal", "in", Jednostki.Inch, new Dictionary<Jednostki, Func<decimal, decimal>>()
            {
                {Jednostki.Millimeter, (input)=>{ return input * (decimal)25.4; } },
                {Jednostki.Meter, (input)=>{ return input * (decimal)0.0254; } },
                {Jednostki.Kilometer, (input)=>{ return input * (decimal)0.0000254; } },
                {Jednostki.Centymeter, (input)=>{ return input * (decimal)2.54; } },
                {Jednostki.Decimeter, (input)=>{ return input * (decimal)0.254; } },
                {Jednostki.Mile, (input)=>{ return input * (decimal)0.0000157828; } },
                {Jednostki.NauticalMile, (input)=>{ return input * (decimal)0.0000137149028078; } },
                {Jednostki.Cable, (input)=>{ return input * (decimal)0.0001157407407407; } },
                {Jednostki.Yard, (input)=>{ return input * (decimal)0.0277777778; } },
                {Jednostki.Inch, (input)=>{ return input; } },
                {Jednostki.Foot, (input)=>{ return input * (decimal)0.0833333333; } },
            }),
            new Jednostka("Stopa", "ft", Jednostki.Foot, new Dictionary<Jednostki, Func<decimal, decimal>>()
            {
                {Jednostki.Millimeter, (input)=>{ return input * (decimal)304.8; } },
                {Jednostki.Meter, (input)=>{ return input * (decimal)0.3048; } },
                {Jednostki.Kilometer, (input)=>{ return input * (decimal)0.0003048; } },
                {Jednostki.Centymeter, (input)=>{ return input * (decimal)30.48; } },
                {Jednostki.Decimeter, (input)=>{ return input * (decimal)3.04800; } },
                {Jednostki.Mile, (input)=>{ return input * (decimal)0.000189393939; } },
                {Jednostki.NauticalMile, (input)=>{ return input * (decimal)0.000164578834; } },
                {Jednostki.Cable, (input)=>{ return input * (decimal)0.00138888889; } },
                {Jednostki.Yard, (input)=>{ return input * (decimal)0.333333333; } },
                {Jednostki.Inch, (input)=>{ return input * 12; } },
                {Jednostki.Foot, (input)=>{ return input; } },
            })
        };

        public List<Jednostka> Wagi = new List<Jednostka>()
        {
        new Jednostka("Miligram", "mg", Jednostki.Miligram, new Dictionary<Jednostki, Func<decimal, decimal>>()
        {
            {Jednostki.Miligram, (input)=>{ return input; } },
            {Jednostki.Gram, (input)=>{ return input/1000; } },
            {Jednostki.Decagram, (input)=>{ return input/10000; } },
            {Jednostki.Kilogram, (input)=>{ return input/100000; } },
            {Jednostki.Ton, (input)=>{ return input/10000000; } },
            {Jednostki.Ounce, (input)=>{ return input * (decimal)0.000035; } },
            {Jednostki.Pound, (input)=>{ return input * (decimal)0.000002; } },
            {Jednostki.Carat, (input)=>{ return input * (decimal)0.005; } },
            {Jednostki.Cental, (input)=>{ return input/100000000; } },
        }),
            
        new Jednostka("Gram", "g", Jednostki.Gram, new Dictionary<Jednostki, Func<decimal, decimal>>()
        {
            {Jednostki.Miligram, (input)=>{ return input*1000; } },
            {Jednostki.Gram, (input)=>{ return input; } },
            {Jednostki.Decagram, (input)=>{ return input/10; } },
            {Jednostki.Kilogram, (input)=>{ return input/1000; } },
            {Jednostki.Ton, (input)=>{ return input/1000000; } },
            {Jednostki.Ounce, (input)=>{ return input * (decimal)0.035; } },
            {Jednostki.Pound, (input)=>{ return input * (decimal)0.002; } },
            {Jednostki.Carat, (input)=>{ return input * 5; } },
            {Jednostki.Cental, (input)=>{ return input/100000; } },
        }),

        new Jednostka("Dekagram", "dkg", Jednostki.Decagram, new Dictionary<Jednostki, Func<decimal, decimal>>()
        {
            {Jednostki.Miligram, (input)=>{ return input*10000; } },
            {Jednostki.Gram, (input)=>{ return input*10; } },
            {Jednostki.Decagram, (input)=>{ return input; } },
            {Jednostki.Kilogram, (input)=>{ return input/100; } },
            {Jednostki.Ton, (input)=>{ return input/100000; } },
            {Jednostki.Ounce, (input)=>{ return input * (decimal)0.35; } },
            {Jednostki.Pound, (input)=>{ return input * (decimal)0.02; } },
            {Jednostki.Carat, (input)=>{ return input * 50; } },
            {Jednostki.Cental, (input)=>{ return input/10000; } },
        }),

        new Jednostka("Kilogram", "kg", Jednostki.Kilogram, new Dictionary<Jednostki, Func<decimal, decimal>>()
        {
            {Jednostki.Miligram, (input)=>{ return input*1000000; } },
            {Jednostki.Gram, (input)=>{ return input*1000; } },
            {Jednostki.Decagram, (input)=>{ return input*10; } },
            {Jednostki.Kilogram, (input)=>{ return input; } },
            {Jednostki.Ton, (input)=>{ return input/1000; } },
            {Jednostki.Ounce, (input)=>{ return input * (decimal)350; } },
            {Jednostki.Pound, (input)=>{ return input * (decimal)2; } },
            {Jednostki.Carat, (input)=>{ return input * 5000; } },
            {Jednostki.Cental, (input)=>{ return input/100; } },
        }),

        new Jednostka("Tona", "T", Jednostki.Ton, new Dictionary<Jednostki, Func<decimal, decimal>>()
        {
            {Jednostki.Miligram, (input)=>{ return input*1000000000; } },
            {Jednostki.Gram, (input)=>{ return input*1000000; } },
            {Jednostki.Decagram, (input)=>{ return input*10000; } },
            {Jednostki.Kilogram, (input)=>{ return input*1000; } },
            {Jednostki.Ton, (input)=>{ return input; } },
            {Jednostki.Ounce, (input)=>{ return input * (decimal)350000; } },
            {Jednostki.Pound, (input)=>{ return input * (decimal)2000; } },
            {Jednostki.Carat, (input)=>{ return input * 5000000; } },
            {Jednostki.Cental, (input)=>{ return input*10; } },
        }),

        new Jednostka("Uncja", "oz", Jednostki.Ounce, new Dictionary<Jednostki, Func<decimal, decimal>>()
        {
            {Jednostki.Miligram, (input)=>{ return input*(decimal)28349.523; } },
            {Jednostki.Gram, (input)=>{ return input*(decimal)28.349523; } },
            {Jednostki.Decagram, (input)=>{ return input*(decimal)2.834952; } },
            {Jednostki.Kilogram, (input)=>{ return input*(decimal)0.02835; } },
            {Jednostki.Ton, (input)=>{ return input*(decimal)0.000028; } },
            {Jednostki.Ounce, (input)=>{ return input; } },
            {Jednostki.Pound, (input)=>{ return input * (decimal)0.0625; } },
            {Jednostki.Carat, (input)=>{ return input * (decimal)141.747615; } },
            {Jednostki.Cental, (input)=>{ return input * (decimal)0.000283; } },
        }),

        new Jednostka("Funt", "lbs", Jednostki.Pound, new Dictionary<Jednostki, Func<decimal, decimal>>()
        {
            {Jednostki.Miligram, (input)=>{ return input*(decimal)453592.4; } },
            {Jednostki.Gram, (input)=>{ return input*(decimal)453.59237; } },
            {Jednostki.Decagram, (input)=>{ return input*(decimal)45.359237; } },
            {Jednostki.Kilogram, (input)=>{ return input*(decimal)0.453592; } },
            {Jednostki.Ton, (input)=>{ return input*(decimal)0.000454; } },
            {Jednostki.Ounce, (input)=>{ return input * 16; } },
            {Jednostki.Pound, (input)=>{ return input; } },
            {Jednostki.Carat, (input)=>{ return input * (decimal)2267.96185; } },
            {Jednostki.Cental, (input)=>{ return input * (decimal)0.004536 ; } },
        }),

        new Jednostka("Karat", "ct", Jednostki.Carat, new Dictionary<Jednostki, Func<decimal, decimal>>()
        {
            {Jednostki.Miligram, (input)=>{ return input*(decimal)200 ; } },
            {Jednostki.Gram, (input)=>{ return input*(decimal)0.2; } },
            {Jednostki.Decagram, (input)=>{ return input*(decimal)0.02; } },
            {Jednostki.Kilogram, (input)=>{ return input*(decimal)0.0002; } },
            {Jednostki.Ton, (input)=>{ return input*(decimal)0.0000002; } },
            {Jednostki.Ounce, (input)=>{ return input * (decimal)0.007055; } },
            {Jednostki.Pound, (input)=>{ return input * (decimal)0.000441; } },
            {Jednostki.Carat, (input)=>{ return input * (decimal)500000; } },
            {Jednostki.Cental, (input)=>{ return input * (decimal)0.000002; } },
        }),

        new Jednostka("Kwintal", "q", Jednostki.Cental, new Dictionary<Jednostki, Func<decimal, decimal>>()
        {
            {Jednostki.Miligram, (input)=>{ return input*100000000; } },
            {Jednostki.Gram, (input)=>{ return input*100000; } },
            {Jednostki.Decagram, (input)=>{ return input*1000; } },
            {Jednostki.Kilogram, (input)=>{ return input*100; } },
            {Jednostki.Ton, (input)=>{ return input/10; } },
            {Jednostki.Ounce, (input)=>{ return input * (decimal)35000; } },
            {Jednostki.Pound, (input)=>{ return input * (decimal)200; } },
            {Jednostki.Carat, (input)=>{ return input * 500000; } },
            {Jednostki.Cental, (input)=>{ return input; } },
        }),
            };
    }
}
