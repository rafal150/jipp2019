using JIPP5_LAB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JIPP5_LAB.Constants
{
    public static class ItemRepository
    {
        //Temperatury
        public static Unit Celsius = new Unit("Celsjusz", "°C", UnitTypes.Celsius, new Dictionary<UnitTypes, Func<decimal,decimal>>() {
            {UnitTypes.Kelvin, (input)=>{ return input + (decimal)273.15; } },
            {UnitTypes.Celsius, (input)=>{ return input; } },
            {UnitTypes.Fahrenheit, (input)=>{ return ((input + 40) * (decimal)1.8)-40; } },
            {UnitTypes.Rankine, (input)=>{ return (input + (decimal)273.15) * (decimal)1.8; } },
        });

        public static Unit Kelvin = new Unit("Kelvin", "°K", UnitTypes.Kelvin, new Dictionary<UnitTypes, Func<decimal, decimal>>() {
            {UnitTypes.Kelvin, (input)=>{ return input; } },
            {UnitTypes.Celsius, (input)=>{ return input - (decimal)273.15; } },
            {UnitTypes.Fahrenheit, (input)=>{ return input * (decimal)1.8 - (decimal)459.67; } },
            {UnitTypes.Rankine, (input)=>{ return input * (decimal)1.8; } },
        });

        public static Unit Fahrenheit = new Unit("Fahrenheit", "°F", UnitTypes.Fahrenheit, new Dictionary<UnitTypes, Func<decimal, decimal>>() {
            {UnitTypes.Kelvin, (input)=>{ return (input + (decimal)459.67) * ((decimal)5/(decimal)9); } },
            {UnitTypes.Celsius, (input)=>{ return (input-32)/(decimal)1.8; } },
            {UnitTypes.Fahrenheit, (input)=>{ return input; } },
            {UnitTypes.Rankine, (input)=>{ return input + (decimal)459.67; } },
        });

        public static Unit Rankine = new Unit("Rankine", "°R", UnitTypes.Rankine, new Dictionary<UnitTypes, Func<decimal, decimal>>() {
            {UnitTypes.Kelvin, (input)=>{ return input * ((decimal)5/(decimal)9); } },
            {UnitTypes.Celsius, (input)=>{ return (input - (decimal)491.67) * ((decimal)5/(decimal)9); } },
            {UnitTypes.Fahrenheit, (input)=>{ return input - (decimal)459.67; } },
            {UnitTypes.Rankine, (input)=>{ return input; } },
        });

        //Długości
        public static Unit Milimeter = new Unit("Milimetr", "mm", UnitTypes.Millimeter, new Dictionary<UnitTypes, Func<decimal, decimal>>()
        {
            {UnitTypes.Millimeter, (input)=>{ return input; } },
            {UnitTypes.Meter, (input)=>{ return input/1000; } },
            {UnitTypes.Kilometer, (input)=>{ return input/1000000; } },
            {UnitTypes.Centymeter, (input)=>{ return input * (decimal)0.1; } },
            {UnitTypes.Decimeter, (input)=>{ return input * (decimal)0.01; } },
            {UnitTypes.Mile, (input)=>{ return input * ((decimal)6.2137119223733/(decimal)10000000); } },
            {UnitTypes.NauticalMile, (input)=>{ return input * ((decimal)5.3995680345572/(decimal)10000000); } },
            {UnitTypes.Cable, (input)=>{ return input * ((decimal)4.55672208/1000000); } },
            {UnitTypes.Yard, (input)=>{ return input * (decimal)0.0011963081929167; } },
            {UnitTypes.Inch, (input)=>{ return input * (decimal)0.039370078740157; } },
            {UnitTypes.Foot, (input)=>{ return input * (decimal)0.0032808398950131; } },
        });

        public static Unit Meter = new Unit("Metr", "m", UnitTypes.Meter, new Dictionary<UnitTypes, Func<decimal, decimal>>()
        {
            {UnitTypes.Millimeter, (input)=>{ return input * 1000; } },
            {UnitTypes.Meter, (input)=>{ return input; } },
            {UnitTypes.Kilometer, (input)=>{ return input/1000; } },
            {UnitTypes.Centymeter, (input)=>{ return input * (decimal)100; } },
            {UnitTypes.Decimeter, (input)=>{ return input * (decimal)10; } },
            {UnitTypes.Mile, (input)=>{ return input * ((decimal)6.2137119223733/(decimal)10000); } },
            {UnitTypes.NauticalMile, (input)=>{ return input * ((decimal)5.3995680345572/(decimal)10000); } },
            {UnitTypes.Cable, (input)=>{ return input * ((decimal)4.55672208/1000); } },
            {UnitTypes.Yard, (input)=>{ return input * (decimal)1.1963081929167; } },
            {UnitTypes.Inch, (input)=>{ return input * (decimal)39.370078740157; } },
            {UnitTypes.Foot, (input)=>{ return input * (decimal)3.2808398950131; } },
        });

        public static Unit Kilometer = new Unit("Kilometr", "km", UnitTypes.Kilometer, new Dictionary<UnitTypes, Func<decimal, decimal>>()
        {
            {UnitTypes.Millimeter, (input)=>{ return input * 1000000; } },
            {UnitTypes.Meter, (input)=>{ return input * 1000; } },
            {UnitTypes.Kilometer, (input)=>{ return input; } },
            {UnitTypes.Centymeter, (input)=>{ return input * (decimal)100000; } },
            {UnitTypes.Decimeter, (input)=>{ return input * (decimal)10000; } },
            {UnitTypes.Mile, (input)=>{ return input * ((decimal)6.2137119223733/(decimal)10); } },
            {UnitTypes.NauticalMile, (input)=>{ return input * ((decimal)5.3995680345572/(decimal)10); } },
            {UnitTypes.Cable, (input)=>{ return input * ((decimal)4.55672208); } },
            {UnitTypes.Yard, (input)=>{ return input * (decimal)1196.3081929167; } },
            {UnitTypes.Inch, (input)=>{ return input * (decimal)39370.078740157; } },
            {UnitTypes.Foot, (input)=>{ return input * (decimal)3280.8398950131; } },
        });

        public static Unit Centymeter = new Unit("Centymetr", "cm", UnitTypes.Centymeter, new Dictionary<UnitTypes, Func<decimal, decimal>>()
        {
            {UnitTypes.Millimeter, (input)=>{ return input * 10; } },
            {UnitTypes.Meter, (input)=>{ return input / 100; } },
            {UnitTypes.Kilometer, (input)=>{ return input / 100000; } },
            {UnitTypes.Centymeter, (input)=>{ return input; } },
            {UnitTypes.Decimeter, (input)=>{ return input / (decimal)10; } },
            {UnitTypes.Mile, (input)=>{ return input * ((decimal)6.2137119223733/(decimal)1000000); } },
            {UnitTypes.NauticalMile, (input)=>{ return input * ((decimal)5.3995680345572/(decimal)100000); } },
            {UnitTypes.Cable, (input)=>{ return input * ((decimal)4.55672208/10000); } },
            {UnitTypes.Yard, (input)=>{ return input * (decimal)119.63081929167; } },
            {UnitTypes.Inch, (input)=>{ return input * (decimal)3937.0078740157; } },
            {UnitTypes.Foot, (input)=>{ return input * (decimal)328.08398950131; } },
        });

        public static Unit Decimeter = new Unit("Decymetr", "dm", UnitTypes.Decimeter, new Dictionary<UnitTypes, Func<decimal, decimal>>()
        {
            {UnitTypes.Millimeter, (input)=>{ return input * 100; } },
            {UnitTypes.Meter, (input)=>{ return input / 10; } },
            {UnitTypes.Kilometer, (input)=>{ return input / 10000; } },
            {UnitTypes.Centymeter, (input)=>{ return input * 10; } },
            {UnitTypes.Decimeter, (input)=>{ return input; } },
            {UnitTypes.Mile, (input)=>{ return input * ((decimal)6.2137119223733/(decimal)100000); } },
            {UnitTypes.NauticalMile, (input)=>{ return input * ((decimal)5.3995680345572/(decimal)10000); } },
            {UnitTypes.Cable, (input)=>{ return input * ((decimal)4.55672208/1000); } },
            {UnitTypes.Yard, (input)=>{ return input * (decimal)11.963081929167; } },
            {UnitTypes.Inch, (input)=>{ return input * (decimal)393.70078740157; } },
            {UnitTypes.Foot, (input)=>{ return input * (decimal)32.808398950131; } },
        });

        public static Unit Mile = new Unit("Mila", "", UnitTypes.Mile, new Dictionary<UnitTypes, Func<decimal, decimal>>()
        {
            {UnitTypes.Millimeter, (input)=>{ return input * 1609344; } },
            {UnitTypes.Meter, (input)=>{ return input * (decimal)1609.344; } },
            {UnitTypes.Kilometer, (input)=>{ return input * (decimal)1.609344; } },
            {UnitTypes.Centymeter, (input)=>{ return input * (decimal)160934.4; } },
            {UnitTypes.Decimeter, (input)=>{ return input * (decimal)16093.44; } },
            {UnitTypes.Mile, (input)=>{ return input; } },
            {UnitTypes.NauticalMile, (input)=>{ return input * (decimal)0.868976242; } },
            {UnitTypes.Cable, (input)=>{ return input * (decimal)7.33333333; } },
            {UnitTypes.Yard, (input)=>{ return input * 1760; } },
            {UnitTypes.Inch, (input)=>{ return input * 63360; } },
            {UnitTypes.Foot, (input)=>{ return input * 5280; } },
        });

        public static Unit NauticalMile = new Unit("Mila Morska", "Nm", UnitTypes.NauticalMile, new Dictionary<UnitTypes, Func<decimal, decimal>>()
        {
            {UnitTypes.Millimeter, (input)=>{ return input * 18520000; } },
            {UnitTypes.Meter, (input)=>{ return input * 1852; } },
            {UnitTypes.Kilometer, (input)=>{ return input * (1852/10000); } },
            {UnitTypes.Centymeter, (input)=>{ return input * 185200; } },
            {UnitTypes.Decimeter, (input)=>{ return input * 18520; } },
            {UnitTypes.Mile, (input)=>{ return input * (decimal)1.15077945; } },
            {UnitTypes.NauticalMile, (input)=>{ return input; } },
            {UnitTypes.Cable, (input)=>{ return input * 10; } },
            {UnitTypes.Yard, (input)=>{ return input * (decimal)2025.37183; } },
            {UnitTypes.Inch, (input)=>{ return input * (decimal)72913.3858; } },
            {UnitTypes.Foot, (input)=>{ return input * (decimal)6076.11549; } },
        });

        public static Unit Cable = new Unit("Kabel", "", UnitTypes.Cable, new Dictionary<UnitTypes, Func<decimal, decimal>>()
        {
            {UnitTypes.Millimeter, (input)=>{ return input * (decimal)21945600; } },
            {UnitTypes.Meter, (input)=>{ return input * (decimal)219.456; } },
            {UnitTypes.Kilometer, (input)=>{ return input * (decimal)2.19456; } },
            {UnitTypes.Centymeter, (input)=>{ return (decimal)21945.6; } },
            {UnitTypes.Decimeter, (input)=>{ return input * (decimal)2194.56; } },
            {UnitTypes.Mile, (input)=>{ return input * (decimal)0.13636363636364; } },
            {UnitTypes.NauticalMile, (input)=>{ return input * (decimal)0.12; } },
            {UnitTypes.Cable, (input)=>{ return input; } },
            {UnitTypes.Yard, (input)=>{ return input * 240; } },
            {UnitTypes.Inch, (input)=>{ return input * 8640; } },
            {UnitTypes.Foot, (input)=>{ return input * 720; } },
        });

        public static Unit Yard = new Unit("Jard", "yd", UnitTypes.Yard, new Dictionary<UnitTypes, Func<decimal, decimal>>()
        {
            {UnitTypes.Millimeter, (input)=>{ return input * (decimal)914.4; } },
            {UnitTypes.Meter, (input)=>{ return input * (decimal)0.9144; } },
            {UnitTypes.Kilometer, (input)=>{ return input * (decimal)0.0009144; } },
            {UnitTypes.Centymeter, (input)=>{ return input * (decimal)91.44; } },
            {UnitTypes.Decimeter, (input)=>{ return input * (decimal)9.14400; } },
            {UnitTypes.Mile, (input)=>{ return input * (decimal)0.000568181818; } },
            {UnitTypes.NauticalMile, (input)=>{ return input * (decimal)0.000493736501; } },
            {UnitTypes.Cable, (input)=>{ return input * (decimal)0.00493421; } },
            {UnitTypes.Yard, (input)=>{ return input; } },
            {UnitTypes.Inch, (input)=>{ return input * 36; } },
            {UnitTypes.Foot, (input)=>{ return input * 3; } },
        });

        public static Unit Inch = new Unit("Cal", "in", UnitTypes.Inch, new Dictionary<UnitTypes, Func<decimal, decimal>>()
        {
            {UnitTypes.Millimeter, (input)=>{ return input * (decimal)25.4; } },
            {UnitTypes.Meter, (input)=>{ return input * (decimal)0.0254; } },
            {UnitTypes.Kilometer, (input)=>{ return input * (decimal)0.0000254; } },
            {UnitTypes.Centymeter, (input)=>{ return input * (decimal)2.54; } },
            {UnitTypes.Decimeter, (input)=>{ return input * (decimal)0.254; } },
            {UnitTypes.Mile, (input)=>{ return input * (decimal)0.0000157828; } },
            {UnitTypes.NauticalMile, (input)=>{ return input * (decimal)0.0000137149028078; } },
            {UnitTypes.Cable, (input)=>{ return input * (decimal)0.0001157407407407; } },
            {UnitTypes.Yard, (input)=>{ return input * (decimal)0.0277777778; } },
            {UnitTypes.Inch, (input)=>{ return input; } },
            {UnitTypes.Foot, (input)=>{ return input * (decimal)0.0833333333; } },
        });

        public static Unit Foot = new Unit("Stopa", "ft", UnitTypes.Foot, new Dictionary<UnitTypes, Func<decimal, decimal>>()
        {
            {UnitTypes.Millimeter, (input)=>{ return input * (decimal)304.8; } },
            {UnitTypes.Meter, (input)=>{ return input * (decimal)0.3048; } },
            {UnitTypes.Kilometer, (input)=>{ return input * (decimal)0.0003048; } },
            {UnitTypes.Centymeter, (input)=>{ return input * (decimal)30.48; } },
            {UnitTypes.Decimeter, (input)=>{ return input * (decimal)3.04800; } },
            {UnitTypes.Mile, (input)=>{ return input * (decimal)0.000189393939; } },
            {UnitTypes.NauticalMile, (input)=>{ return input * (decimal)0.000164578834; } },
            {UnitTypes.Cable, (input)=>{ return input * (decimal)0.00138888889; } },
            {UnitTypes.Yard, (input)=>{ return input * (decimal)0.333333333; } },
            {UnitTypes.Inch, (input)=>{ return input * 12; } },
            {UnitTypes.Foot, (input)=>{ return input; } },
        });

        //Wagi
        public static Unit Miligram = new Unit("Miligram", "mg", UnitTypes.Miligram, new Dictionary<UnitTypes, Func<decimal, decimal>>()
        {
            {UnitTypes.Miligram, (input)=>{ return input; } },
            {UnitTypes.Gram, (input)=>{ return input/1000; } },
            {UnitTypes.Decagram, (input)=>{ return input/10000; } },
            {UnitTypes.Kilogram, (input)=>{ return input/100000; } },
            {UnitTypes.Ton, (input)=>{ return input/10000000; } },
            {UnitTypes.Ounce, (input)=>{ return input * (decimal)0.000035; } },
            {UnitTypes.Pound, (input)=>{ return input * (decimal)0.000002; } },
            {UnitTypes.Carat, (input)=>{ return input * (decimal)0.005; } },
            {UnitTypes.Cental, (input)=>{ return input/100000000; } },
        });

        public static Unit Gram = new Unit("Gram", "g", UnitTypes.Gram, new Dictionary<UnitTypes, Func<decimal, decimal>>()
        {
            {UnitTypes.Miligram, (input)=>{ return input*1000; } },
            {UnitTypes.Gram, (input)=>{ return input; } },
            {UnitTypes.Decagram, (input)=>{ return input/10; } },
            {UnitTypes.Kilogram, (input)=>{ return input/1000; } },
            {UnitTypes.Ton, (input)=>{ return input/1000000; } },
            {UnitTypes.Ounce, (input)=>{ return input * (decimal)0.035; } },
            {UnitTypes.Pound, (input)=>{ return input * (decimal)0.002; } },
            {UnitTypes.Carat, (input)=>{ return input * 5; } },
            {UnitTypes.Cental, (input)=>{ return input/100000; } },
        });

        public static Unit Decagram = new Unit("Dekagram", "dkg", UnitTypes.Decagram, new Dictionary<UnitTypes, Func<decimal, decimal>>()
        {
            {UnitTypes.Miligram, (input)=>{ return input*10000; } },
            {UnitTypes.Gram, (input)=>{ return input*10; } },
            {UnitTypes.Decagram, (input)=>{ return input; } },
            {UnitTypes.Kilogram, (input)=>{ return input/100; } },
            {UnitTypes.Ton, (input)=>{ return input/100000; } },
            {UnitTypes.Ounce, (input)=>{ return input * (decimal)0.35; } },
            {UnitTypes.Pound, (input)=>{ return input * (decimal)0.02; } },
            {UnitTypes.Carat, (input)=>{ return input * 50; } },
            {UnitTypes.Cental, (input)=>{ return input/10000; } },
        });

        public static Unit Kilogram = new Unit("Kilogram", "kg", UnitTypes.Kilogram, new Dictionary<UnitTypes, Func<decimal, decimal>>()
        {
            {UnitTypes.Miligram, (input)=>{ return input*1000000; } },
            {UnitTypes.Gram, (input)=>{ return input*1000; } },
            {UnitTypes.Decagram, (input)=>{ return input*10; } },
            {UnitTypes.Kilogram, (input)=>{ return input; } },
            {UnitTypes.Ton, (input)=>{ return input/1000; } },
            {UnitTypes.Ounce, (input)=>{ return input * (decimal)350; } },
            {UnitTypes.Pound, (input)=>{ return input * (decimal)2; } },
            {UnitTypes.Carat, (input)=>{ return input * 5000; } },
            {UnitTypes.Cental, (input)=>{ return input/100; } },
        });

        public static Unit Ton = new Unit("Tona", "T", UnitTypes.Ton, new Dictionary<UnitTypes, Func<decimal, decimal>>()
        {
            {UnitTypes.Miligram, (input)=>{ return input*1000000000; } },
            {UnitTypes.Gram, (input)=>{ return input*1000000; } },
            {UnitTypes.Decagram, (input)=>{ return input*10000; } },
            {UnitTypes.Kilogram, (input)=>{ return input*1000; } },
            {UnitTypes.Ton, (input)=>{ return input; } },
            {UnitTypes.Ounce, (input)=>{ return input * (decimal)350000; } },
            {UnitTypes.Pound, (input)=>{ return input * (decimal)2000; } },
            {UnitTypes.Carat, (input)=>{ return input * 5000000; } },
            {UnitTypes.Cental, (input)=>{ return input*10; } },
        });

        public static Unit Ounce = new Unit("Uncja", "oz", UnitTypes.Ounce, new Dictionary<UnitTypes, Func<decimal, decimal>>()
        {
            {UnitTypes.Miligram, (input)=>{ return input*(decimal)28349.523; } },
            {UnitTypes.Gram, (input)=>{ return input*(decimal)28.349523; } },
            {UnitTypes.Decagram, (input)=>{ return input*(decimal)2.834952; } },
            {UnitTypes.Kilogram, (input)=>{ return input*(decimal)0.02835; } },
            {UnitTypes.Ton, (input)=>{ return input*(decimal)0.000028; } },
            {UnitTypes.Ounce, (input)=>{ return input; } },
            {UnitTypes.Pound, (input)=>{ return input * (decimal)0.0625; } },
            {UnitTypes.Carat, (input)=>{ return input * (decimal)141.747615; } },
            {UnitTypes.Cental, (input)=>{ return input * (decimal)0.000283; } },
        });

        public static Unit Pound = new Unit("Funt", "lbs", UnitTypes.Pound, new Dictionary<UnitTypes, Func<decimal, decimal>>()
        {
            {UnitTypes.Miligram, (input)=>{ return input*(decimal)453592.4; } },
            {UnitTypes.Gram, (input)=>{ return input*(decimal)453.59237; } },
            {UnitTypes.Decagram, (input)=>{ return input*(decimal)45.359237; } },
            {UnitTypes.Kilogram, (input)=>{ return input*(decimal)0.453592; } },
            {UnitTypes.Ton, (input)=>{ return input*(decimal)0.000454; } },
            {UnitTypes.Ounce, (input)=>{ return input * 16; } },
            {UnitTypes.Pound, (input)=>{ return input; } },
            {UnitTypes.Carat, (input)=>{ return input * (decimal)2267.96185; } },
            {UnitTypes.Cental, (input)=>{ return input * (decimal)0.004536 ; } },
        });

        public static Unit Carat = new Unit("Karat", "ct", UnitTypes.Carat, new Dictionary<UnitTypes, Func<decimal, decimal>>()
        {
            {UnitTypes.Miligram, (input)=>{ return input*(decimal)200 ; } },
            {UnitTypes.Gram, (input)=>{ return input*(decimal)0.2; } },
            {UnitTypes.Decagram, (input)=>{ return input*(decimal)0.02; } },
            {UnitTypes.Kilogram, (input)=>{ return input*(decimal)0.0002; } },
            {UnitTypes.Ton, (input)=>{ return input*(decimal)0.0000002; } },
            {UnitTypes.Ounce, (input)=>{ return input * (decimal)0.007055; } },
            {UnitTypes.Pound, (input)=>{ return input * (decimal)0.000441; } },
            {UnitTypes.Carat, (input)=>{ return input * (decimal)500000; } },
            {UnitTypes.Cental, (input)=>{ return input * (decimal)0.000002; } },
        });

        public static Unit Cental = new Unit("Kwintal", "q", UnitTypes.Cental, new Dictionary<UnitTypes, Func<decimal, decimal>>()
        {
            {UnitTypes.Miligram, (input)=>{ return input*100000000; } },
            {UnitTypes.Gram, (input)=>{ return input*100000; } },
            {UnitTypes.Decagram, (input)=>{ return input*1000; } },
            {UnitTypes.Kilogram, (input)=>{ return input*100; } },
            {UnitTypes.Ton, (input)=>{ return input/10; } },
            {UnitTypes.Ounce, (input)=>{ return input * (decimal)35000; } },
            {UnitTypes.Pound, (input)=>{ return input * (decimal)200; } },
            {UnitTypes.Carat, (input)=>{ return input * 500000; } },
            {UnitTypes.Cental, (input)=>{ return input; } },
        });
    }
}
