using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace applicationWpf
{
    class MassConverter : ConverterBase
    {
        double value=0, convertedValue = double.NaN;
        int fromIndex=0, toIndex=0;

        public string[] suffix => new string[]
            {
            "mg",
            "g",
            "dag",
            "kg",
            "T",
            "oz",
            "lb",
            "ct",
            "cwt"
            };

        public string[] indexes => new string[]
    {
                "Miligram",
                "Gram",
                "Decagram",
                "Kilogram",
                "Tonne",
                "Ounce",
                "Pound",
                "Carat",
                "Quintal"
    };

        public string converterName => "mass";

        public string GetConvertedString()
        {
            if (convertedValue != double.NaN)
                return $"{convertedValue} {suffix[toIndex]}";
            else return "NaN";
        }

        public double Convert(double value, int fromIndex, int toIndex)
        {
            this.value = value;
            this.fromIndex = fromIndex;
            this.toIndex = toIndex;
            switch (indexes[fromIndex])
            {
                case "Miligram":
                    {
                        MiligramConvert();
                        break;
                    }
                case "Gram":
                    {
                        GramConvert();
                        break;
                    }
                case "Decagram":
                    {
                        DecagramConvert();
                        break;
                    }
                case "Kilogram":
                    {
                        KilogramConvert();
                        break;
                    }
                case "Tonne":
                    {
                        TonneConvert();
                        break;
                    }
                case "Ounce":
                    {
                        OunceConvert();
                        break;
                    }
                case "Pound":
                    {
                        PoundConvert();
                        break;
                    }
                case "Carat":
                    {
                        CaratConvert();
                        break;
                    }
                case "Quintal":
                    {
                        QuintalConvert();
                        break;
                    }
                default:
                    return convertedValue;
            }
                    return convertedValue;
            //MainWindow.repo.AddStatistic(new StatisticsDTO()
            //{
            //    Date = DateTime.Now,
            //    SourceUnit = suffix[fromIndex],
            //    SourceValue = value,
            //    ConvertedUnit = suffix[toIndex],
            //    ConvertedValue = convertedValue,
            //    Type = converterName
            //});
        }

        private void MiligramConvert()
        {
            switch(indexes[toIndex])
            {
                case "Gram":
                    convertedValue = value *0.001;
                    break;
                case "Decagram":
                    convertedValue = value * 0.0001;
                    break;
                case "Kilogram":
                    convertedValue = value * 0.000001;
                    break;
                case "Tonne":
                    convertedValue = value * 0.0000000001;
                    break;
                case "Ounce":
                    convertedValue = value * 0.0000352739;
                    break;
                case "Pound":
                    convertedValue = value * 0.00000220462262;
                    break;
                case "Carat":
                    convertedValue = value * 0.005;
                    break;
                case "Quintal":
                    convertedValue = value * 0.00000001;
                    break;
                default:
                    convertedValue = value;
                    break;
            }
        }

        private void GramConvert()
        {
            switch (indexes[toIndex])
            {
                case "Miligram":
                    convertedValue = value * 1000.0;
                    break;
                case "Decagram":
                    convertedValue = value * 0.1;
                    break;
                case "Kilogram":
                    convertedValue = value * 0.001;
                    break;
                case "Tonne":
                    convertedValue = value * 0.000001;
                    break;
                case "Ounce":
                    convertedValue = value * 0.0352739;
                    break;
                case "Pound":
                    convertedValue = value * 0.00220462262;
                    break;
                case "Carat":
                    convertedValue = value * 5.0;
                    break;
                case "Quintal":
                    convertedValue = value * 0.00001;
                    break;
                default:
                    convertedValue = value;
                    break;
            }
        }

        private void DecagramConvert()
        {
            switch (indexes[toIndex])
            {
                case "Miligram":
                    convertedValue = value * 10000.0;
                    break;
                case "Gram":
                    convertedValue = value * 10.0;
                    break;
                case "Kilogram":
                    convertedValue = value * 0.01;
                    break;
                case "Tonne":
                    convertedValue = value * 0.00001;
                    break;
                case "Ounce":
                    convertedValue = value * 0.3527396194;
                    break;
                case "Pound":
                    convertedValue = value * 0.0220462262;
                    break;
                case "Carat":
                    convertedValue = value * 50.0;
                    break;
                case "Quintal":
                    convertedValue = value * 0.0001;
                    break;
                default:
                    convertedValue = value;
                    break;
            }
        }

        private void KilogramConvert()
        {
            switch (indexes[toIndex])
            {
                case "Miligram":
                    convertedValue = value * 1000000.0;
                    break;
                case "Gram":
                    convertedValue = value * 1000.0;
                    break;
                case "Decagram":
                    convertedValue = value * 100.0;
                    break;
                case "Tonne":
                    convertedValue = value * 0.001;
                    break;
                case "Ounce":
                    convertedValue = value * 35.27396194;
                    break;
                case "Pound":
                    convertedValue = value * 2.20462262;
                    break;
                case "Carat":
                    convertedValue = value * 5000.0;
                    break;
                case "Quintal":
                    convertedValue = value * 0.01;
                    break;
                default:
                    convertedValue = value;
                    break;
            }
        }

        private void TonneConvert()
        {
            switch (indexes[toIndex])
            {
                case "Miligram":
                    convertedValue = value * 1000000000.0;
                    break;
                case "Gram":
                    convertedValue = value * 1000000.0;
                    break;
                case "Decagram":
                    convertedValue = value * 100000.0;
                    break;
                case "Kilogram":
                    convertedValue = value * 1000.0;
                    break;
                case "Ounce":
                    convertedValue = value * 35273.96194;
                    break;
                case "Pound":
                    convertedValue = value * 2204.62262;
                    break;
                case "Carat":
                    convertedValue = value * 5000000.0;
                    break;
                case "Quintal":
                    convertedValue = value * 10.0;
                    break;
                default:
                    convertedValue = value;
                    break;
            }
        }

        private void OunceConvert()
        {
            switch (indexes[toIndex])
            {
                case "Miligram":
                    convertedValue = value * 28349.523125;
                    break;
                case "Gram":
                    convertedValue = value * 28.349523125;
                    break;
                case "Decagram":
                    convertedValue = value * 2.8349523125;
                    break;
                case "Kilogram":
                    convertedValue = value * 0.0283495231;
                    break;
                case "Tonne":
                    convertedValue = value * 0.0000283495;
                    break;
                case "Pound":
                    convertedValue = value * 0.0625;
                    break;
                case "Carat":
                    convertedValue = value * 141.74761563;
                    break;
                case "Quintal":
                    convertedValue = value * 0.0002834952;
                    break;
                default:
                    convertedValue = value;
                    break;
            }
        }


        private void PoundConvert()
        {
            switch (indexes[toIndex])
            {
                case "Miligram":
                    convertedValue = value * 453592.37;
                    break;
                case "Gram":
                    convertedValue = value * 453.59237;
                    break;
                case "Decagram":
                    convertedValue = value * 45.359237;
                    break;
                case "Kilogram":
                    convertedValue = value * 0.45359237;
                    break;
                case "Tonne":
                    convertedValue = value * 0.0004535924;
                    break;
                case "Ounce":
                    convertedValue = value * 16.0;
                    break;
                case "Carat":
                    convertedValue = value * 2267.96185;
                    break;
                case "Quintal":
                    convertedValue = value * 0.0045359237;
                    break;
                default:
                    convertedValue = value;
                    break;
            }
        }

        private void CaratConvert()
        {
            switch (indexes[toIndex])
            {
                case "Miligram":
                    convertedValue = value * 200.0;
                    break;
                case "Gram":
                    convertedValue = value * 0.2;
                    break;
                case "Decagram":
                    convertedValue = value * 0.02;
                    break;
                case "Kilogram":
                    convertedValue = value * 0.0002;
                    break;
                case "Tonne":
                    convertedValue = value * 0.0000002;
                    break;
                case "Ounce":
                    convertedValue = value * 0.0070547924;
                    break;
                case "Pound":
                    convertedValue = value * 0.0004409245;
                    break;
                case "Quintal":
                    convertedValue = value * 0.000002;
                    break;
                default:
                    convertedValue = value;
                    break;
            }
        }

        private void QuintalConvert()
        {
            switch (indexes[toIndex])
            {
                case "Miligram":
                    convertedValue = value * 100000000.0;
                    break;
                case "Gram":
                    convertedValue = value * 100000.0;
                    break;
                case "Decagram":
                    convertedValue = value * 10000.0;
                    break;
                case "Kilogram":
                    convertedValue = value * 100.0;
                    break;
                case "Tonne":
                    convertedValue = value * 0.1;
                    break;
                case "Ounce":
                    convertedValue = value * 3527.396195;
                    break;
                case "Pound":
                    convertedValue = value * 220.46226218;
                    break;
                case "Carat":
                    convertedValue = value * 500000;
                    break;
                default:
                    convertedValue = value;
                    break;
            }
        }

    }
}
