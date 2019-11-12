using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using applicationWpf;

namespace StorageConverterPlugin
{
    public class StorageConverterPlugin : ConverterBase
    {
        double value, convertedValue = double.NaN;
        int fromIndex, toIndex;

        public string[] suffix => new string[]
    {
            "B",
            "kB",
            "MB",
            "GB"
    };

        public string[] indexes => new string[]
    {
                "Bytes",
                "Kilobytes",
                "Megabytes",
                "Gigabytes"
    };

        public string converterName => "storage";


        public double Convert(double value, int fromIndex, int toIndex)
        {
            this.value = value;
            this.fromIndex = fromIndex;
            this.toIndex = toIndex;
            switch (indexes[fromIndex])
            {
                case "Bytes":
                    {
                        BytesConvert();
                        break;
                    }
                case "Kilobytes":
                    {
                        KilobytesConvert();
                        break;
                    }
                case "Megabytes":
                    {
                        MegabytesConvert();
                        break;
                    }
                case "Gigabytes":
                    {
                        GigabytesConvert();
                        break;
                    }
                default:
                    return convertedValue;
                    
            }
            return convertedValue;
        }

        public string GetConvertedString()
        {
            if (convertedValue != double.NaN)
                return $"{convertedValue} {suffix[toIndex]}";
            else return "NaN";
        }

        private void GigabytesConvert()
        {
            switch (indexes[toIndex])
            {
                case "Bytes":
                    convertedValue = value * Math.Pow(1024.0, 3);
                    break;
                case "Kilobytes":
                    convertedValue = value * Math.Pow(1024.0, 2);
                    break;
                case "Megabytes":
                    convertedValue = value * 1024.0;
                    break;
                default:
                    convertedValue = value;
                    break;
            }
        }

        private void MegabytesConvert()
        {
            switch (indexes[toIndex])
            {
                case "Bytes":
                    convertedValue = value * Math.Pow(1024.0, 2); ;
                    break;
                case "Kilobytes":
                    convertedValue = value * 1024.0;
                    break;
                case "Gigabytes":
                    convertedValue = value / 1024.0;
                    break;
                default:
                    convertedValue = value;
                    break;
            }
        }

        private void KilobytesConvert()
        {
            switch (indexes[toIndex])
            {
                case "Bytes":
                    convertedValue = value * 1024.0;
                    break;
                case "Megabytes":
                    convertedValue = value / 1024.0;
                    break;
                case "Gigabytes":
                    convertedValue = value / Math.Pow(1024.0, 2);
                    break;
                default:
                    convertedValue = value;
                    break;
            }
        }

        private void BytesConvert()
        {
            switch(indexes[toIndex])
            {
                case "Kilobytes":
                    convertedValue = value / 1024.0;
                    break;
                case "Megabytes":
                    convertedValue = value / Math.Pow(1024.0, 2);
                    break;
                case "Gigabytes":
                    convertedValue = value / Math.Pow(1024.0, 3);
                    break;
                default:
                    convertedValue = value;
                    break;
            }
        }
    }
}
