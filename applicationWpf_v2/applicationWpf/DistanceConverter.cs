using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace applicationWpf
{
    class DistanceConverter : BasicConverter
    {
        public DistanceConverter(double value, int fromIndex, int toIndex)
        {
            this.value = value;
            this.fromIndex = fromIndex;
            this.toIndex = toIndex;

            this.suffix = new string[]
            {
            "mm",
            "cm",
            "dm",
            "m",
            "km",
            "\"",
            "ft",
            "yd",
            "mi",
            "cbl",
            "nmi"
            };

            this.converterName = "distance";
            this.indexes = new string[]
            {
                "Milimeter",
                "Centimeter",
                "Decimeter",
                "Meter",
                "Kilometer",
                "Inch",
                "Feet",
                "Yard",
                "Mile",
                "Cable length",
                "Nautical mile"
            };
        }

        public override void Convert()
        {
            switch(indexes[fromIndex])
            {
                case "Milimeter":
                    {
                        MilimeterConvert();
                        break;
                    }
                case "Centimeter":
                    {
                        CentimeterConvert();
                        break;
                    }
                case "Decimeter":
                    {
                        DecimeterConvert();
                        break;
                    }
                case "Meter":
                    {
                        MeterConvert();
                        break;
                    }
                case "Kilometer":
                    {
                        KilometerConvert();
                        break;
                    }
                case "Inch":
                    {
                        InchConvert();
                        break;
                    }
                case "Feet":
                    {
                        FeetConvert();
                        break;
                    }
                case "Yard":
                    {
                        YardConvert();
                        break;
                    }
                case "Mile":
                    {
                        MileConvert();
                        break;
                    }
                case "Cable length":
                    {
                        CblConvert();
                        break;
                    }
                case "Nautical mile":
                    {
                        NmiConvert();
                        break;
                    }
                default:
                    return;
            }
            base.AddDbEntry();
        }

        private void MilimeterConvert()
        {
            switch(indexes[toIndex])
            {
                case "Centimeter":
                    convertedValue = value / 10.0;
                    break;
                case "Decimeter":
                    convertedValue = value / 100.0;
                    break;
                case "Meter":
                    convertedValue = value / 1000.0;
                    break;
                case "Kilometer":
                    convertedValue = value / 1000000.0;
                    break;
                case "Inch":
                    convertedValue = value * 0.0393700787;
                    break;
                case "Feet":
                    convertedValue = value * 0.0032808399;
                    break;
                case "Yard":
                    convertedValue = value * 0.0010936133;
                    break;
                case "Mile":
                    convertedValue = value * 0.00000062;
                    break;
                case "Cable length":
                    convertedValue = (value / 1000.0) * 185.2;
                    break;
                case "Nautical mile":
                    convertedValue = (value / 1000.0) * 1852;
                    break;
                default:
                    convertedValue = value;
                    break;
            }
        }

        private void CentimeterConvert()
        {
            switch (indexes[toIndex])
            {
                case "Milimeter":
                    convertedValue = value * 10.0;
                    break;
                case "Decimeter":
                    convertedValue = value * 0.1;
                    break;
                case "Meter":
                    convertedValue = value * 0.01;
                    break;
                case "Kilometer":
                    convertedValue = value / 100000.0;
                    break;
                case "Inch":
                    convertedValue = value * 0.393700787;
                    break;
                case "Feet":
                    convertedValue = value * 0.032808399;
                    break;
                case "Yard":
                    convertedValue = value * 0.010936133;
                    break;
                case "Mile":
                    convertedValue = value * 0.00000621;
                    break;
                case "Cable length":
                    convertedValue = (value / 100.0) * 185.2;
                    break;
                case "Nautical mile":
                    convertedValue = (value / 100.0) * 1852;
                    break;
                default:
                    convertedValue = value;
                    break;
            }
        }

        private void DecimeterConvert()
        {
            switch (indexes[toIndex])
            {
                case "Milimeter":
                    convertedValue = value * 100.0;
                    break;
                case "Centimeter":
                    convertedValue = value * 10.0;
                    break;
                case "Meter":
                    convertedValue = value * 0.1;
                    break;
                case "Kilometer":
                    convertedValue = value * 0.0001;
                    break;
                case "Inch":
                    convertedValue = value * 3.93700787;
                    break;
                case "Feet":
                    convertedValue = value * 0.32808399;
                    break;
                case "Yard":
                    convertedValue = value * 0.10936133;
                    break;
                case "Mile":
                    convertedValue = value * 0.00006213;
                    break;
                case "Cable length":
                    convertedValue = (value / 10.0) * 185.2;
                    break;
                case "Nautical mile":
                    convertedValue = (value / 10.0) * 1852;
                    break;
                default:
                    convertedValue = value;
                    break;
            }
        }

        private void MeterConvert()
        {
            switch (indexes[toIndex])
            {
                case "Milimeter":
                    convertedValue = value * 1000.0;
                    break;
                case "Centimeter":
                    convertedValue = value * 100.0;
                    break;
                case "Decimeter":
                    convertedValue = value * 10.0;
                    break;
                case "Kilometer":
                    convertedValue = value * 0.001;
                    break;
                case "Inch":
                    convertedValue = value * 39.3700787;
                    break;
                case "Feet":
                    convertedValue = value * 3.2808399;
                    break;
                case "Yard":
                    convertedValue = value * 1.0936133;
                    break;
                case "Mile":
                    convertedValue = value * 0.00062137;
                    break;
                case "Cable length":
                    convertedValue = value * 185.2;
                    break;
                case "Nautical mile":
                    convertedValue = value * 1852;
                    break;
                default:
                    convertedValue = value;
                    break;
            }
        }

        private void KilometerConvert()
        {
            switch (indexes[toIndex])
            {
                case "Milimeter":
                    convertedValue = value * 1000000.0;
                    break;
                case "Centimeter":
                    convertedValue = value * 100000.0;
                    break;
                case "Decimeter":
                    convertedValue = value * 10000.0;
                    break;
                case "Meter":
                    convertedValue = value * 1000.0;
                    break;
                case "Inch":
                    convertedValue = value * 39370.0787;
                    break;
                case "Feet":
                    convertedValue = value * 3280.8399;
                    break;
                case "Yard":
                    convertedValue = value * 1093.6133;
                    break;
                case "Mile":
                    convertedValue = value * 0.621371192;
                    break;
                case "Cable length":
                    convertedValue = (value * 1000.0) * 185.2;
                    break;
                case "Nautical mile":
                    convertedValue = (value * 1000.0) * 1852;
                    break;
                default:
                    convertedValue = value;
                    break;
            }
        }

        private void InchConvert()
        {
            switch (indexes[toIndex])
            {
                case "Milimeter":
                    convertedValue = value * 25.4;
                    break;
                case "Centimeter":
                    convertedValue = value * 2.54;
                    break;
                case "Decimeter":
                    convertedValue = value * 0.254;
                    break;
                case "Meter":
                    convertedValue = value * 0.0254;
                    break;
                case "Kilometer":
                    convertedValue = value * 0.0000254;
                    break;
                case "Feet":
                    convertedValue = value * 0.0833333;
                    break;
                case "Yard":
                    convertedValue = value * 0.0277777;
                    break;
                case "Mile":
                    convertedValue = value / 63360.0;
                    break;
                case "Cable length":
                    convertedValue = (value * 0.0254) * 185.2;
                    break;
                case "Nautical mile":
                    convertedValue = (value * 0.0254) * 1852;
                    break;
                default:
                    convertedValue = value;
                    break;
            }
        }
        private void FeetConvert()
        {
            switch (indexes[toIndex])
            {
                case "Milimeter":
                    convertedValue = value * 304.8;
                    break;
                case "Centimeter":
                    convertedValue = value * 30.48;
                    break;
                case "Decimeter":
                    convertedValue = value * 3.048;
                    break;
                case "Meter":
                    convertedValue = value * 0.3048;
                    break;
                case "Kilometer":
                    convertedValue = value * 0.0003048;
                    break;
                case "Inch":
                    convertedValue = value * 12;
                    break;
                case "Yard":
                    convertedValue = value * 0.3333333;
                    break;
                case "Mile":
                    convertedValue = value * 0.0001893939;
                    break;
                case "Cable length":
                    convertedValue = (value * 0.3048) * 185.2;
                    break;
                case "Nautical mile":
                    convertedValue = (value * 0.3048) * 1852;
                    break;
                default:
                    convertedValue = value;
                    break;
            }
        }

        private void YardConvert()
        {
            switch (indexes[toIndex])
            {
                case "Milimeter":
                    convertedValue = value * 914.4;
                    break;
                case "Centimeter":
                    convertedValue = value * 91.44;
                    break;
                case "Decimeter":
                    convertedValue = value * 9.144;
                    break;
                case "Meter":
                    convertedValue = value * 0.9144;
                    break;
                case "Kilometer":
                    convertedValue = value * 0.0009144;
                    break;
                case "Inch":
                    convertedValue = value * 36;
                    break;
                case "Feet":
                    convertedValue = value * 3;
                    break;
                case "Mile":
                    convertedValue = value * 0.00056818181;
                    break;
                case "Cable length":
                    convertedValue = (value * 0.9144) * 185.2;
                    break;
                case "Nautical mile":
                    convertedValue = (value * 0.9144) * 1852;
                    break;
                default:
                    convertedValue = value;
                    break;
            }
        }

        private void MileConvert()
        {
            switch (indexes[toIndex])
            {
                case "Milimeter":
                    convertedValue = value * 1609344;
                    break;
                case "Centimeter":
                    convertedValue = value * 160934.4;
                    break;
                case "Decimeter":
                    convertedValue = value * 16093.44;
                    break;
                case "Meter":
                    convertedValue = value * 1609.344;
                    break;
                case "Kilometer":
                    convertedValue = value * 1.609344;
                    break;
                case "Inch":
                    convertedValue = value * 63360;
                    break;
                case "Feet":
                    convertedValue = value * 5280;
                    break;
                case "Yard":
                    convertedValue = value * 1760;
                    break;
                case "Cable length":
                    convertedValue = (value * 1609.344) * 185.2;
                    break;
                case "Nautical mile":
                    convertedValue = (value * 1609.344) * 1852;
                    break;
                default:
                    convertedValue = value;
                    break;
            }
        }

        private void CblConvert()
        {
            //najlatwiej przerzucic do metrow i zrobic to samo co z metrami
            convertedValue = value * 185.2; //to sa teraz metry
            switch (indexes[toIndex])
            {
                case "Milimeter":
                    convertedValue *= 1000.0;
                    break;
                case "Centimeter":
                    convertedValue *= 100.0;
                    break;
                case "Decimeter":
                    convertedValue *= 10.0;
                    break;
                case "Meter":
                    break;
                case "Kilometer":
                    convertedValue *= 0.001;
                    break;
                case "Inch":
                    convertedValue *= 39.3700787;
                    break;
                case "Feet":
                    convertedValue *= 3.2808399;
                    break;
                case "Yard":
                    convertedValue *= 1.0936133;
                    break;
                case "Mile":
                    convertedValue *= 0.00062137;
                    break;
                case "Nautical mile":
                    convertedValue = value * 10;
                    break;
                default:
                    convertedValue = value;
                    break;
            }
        }

        private void NmiConvert()
        {
            //najlatwiej przerzucic do metrow i zrobic to samo co z metrami
            convertedValue = value * 1852; //to sa teraz metry
            switch (indexes[toIndex])
            {
                case "Milimeter":
                    convertedValue *= 1000.0;
                    break;
                case "Centimeter":
                    convertedValue *= 100.0;
                    break;
                case "Decimeter":
                    convertedValue *= 10.0;
                    break;
                case "Meter":
                    break;
                case "Kilometer":
                    convertedValue *= 0.001;
                    break;
                case "Inch":
                    convertedValue *= 39.3700787;
                    break;
                case "Feet":
                    convertedValue *= 3.2808399;
                    break;
                case "Yard":
                    convertedValue *= 1.0936133;
                    break;
                case "Mile":
                    convertedValue *= 0.00062137;
                    break;
                case "Cable length":
                    convertedValue = value * 0.1;
                    break;
                default:
                    convertedValue = value;
                    break;
            }
        }
    }
}
