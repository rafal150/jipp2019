using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace applicationWpf
{
    class TemperatureConverter : BasicConverter
    {
        public TemperatureConverter(double value, int fromIndex, int toIndex)
        {
            this.value = value;
            this.fromIndex = fromIndex;
            this.toIndex = toIndex;

            this.suffix = new string[]
            {
            "°C",
            "F",
            "K",
            "°R"
            };

            this.converterName = "temperature";
            this.indexes = new string[]
            {
                "Celsius",
                "Farenheit",
                "Kelvin",
                "Rankine"
            };
        }

        public override void Convert()
        {
            switch(indexes[fromIndex])
            {
                case "Celsius":
                    {
                        CelsiusConvert();
                        break;
                    }
                case "Farenheit":
                    {
                        FarenheitConvert();
                        break;
                    }
                case "Kelvin":
                    {
                        KelvinConvert();
                        break;
                    }
                case "Rankine":
                    {
                        RankineConvert();
                        break;
                    }
                default:
                    return;
            }
            base.AddDbEntry();
        }

        private void CelsiusConvert()
        {
            switch(indexes[toIndex])
            {
                case "Farenheit":
                    convertedValue = value * 9.0 / 5.0 + 32.0;
                    break;
                case "Kelvin":
                    convertedValue = value + 273.15;
                    break;
                case "Rankine":
                    convertedValue = (value + 273.15) * 9.0 / 5.0;
                    break;
                default:
                    convertedValue = value;
                    break;
            }
        }

        private void FarenheitConvert()
        {
            switch (indexes[toIndex])
            {
                case "Celsius":
                    convertedValue = (value -32) * 5.0 / 9.0;
                    break;
                case "Kelvin":
                    convertedValue = (value+459.67) * 5.0/9.0;
                    break;
                case "Rankine":
                    convertedValue = (value + 459.67);
                    break;
                default:
                    convertedValue = value;
                    break;
            }
        }

        private void KelvinConvert()
        {
            switch (indexes[toIndex])
            {
                case "Farenheit":
                    convertedValue = value * 9.0/5.0 - 459.67;
                    break;
                case "Celsius":
                    convertedValue = value - 273.15;
                    break;
                case "Rankine":
                    convertedValue = value * 9.0 / 5.0;
                    break;
                default:
                    convertedValue = value;
                    break;
            }
        }

        private void RankineConvert()
        {
            switch (indexes[toIndex])
            {
                case "Farenheit":
                    convertedValue = value - 459.67;
                    break;
                case "Celsius":
                    convertedValue = (value-491.67) * 5.0/9.0;
                    break;
                case "Kelvin":
                    convertedValue = value * 5.0/9.0;
                    break;
                default:
                    convertedValue = value;
                    break;
            }
        }
    }
}
