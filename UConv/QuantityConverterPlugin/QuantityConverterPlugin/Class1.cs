using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitConverter.Services;

namespace QuantityConverterPlugin
{
    public class QuantityConverter : IConverter
    {
        public string Name => "Ilość";

        public List<string> Units => new List<string>(new[]
        {
            "Sztuka",
            "Tuzin",
            "Mendel",
            "Mendel chłopski",
            "Kopa",
            "Gros"
        });

        public decimal Convert(string temp, float input)
        {
            float value = 0;
            switch (temp)
            {
                case "Sztuka":
                    value = input;
                    break;
                case "Tuzin":
                    value = input * 0.083333f;
                    break;
                case "Mendel":
                    value = input * 0.0666668f;
                    break;
                case "Mendel chłopski":
                    value = input * 0.0625f;
                    break;
                case "Kopa":
                    value = input * 0.016667f;
                    break;
                case "Gros":
                    value = input * 0.006944f;
                    break;
            }
            value = System.Convert.ToSingle(value.ToString());
            return (decimal)value;
        }

        public float toBaseUnit(string temp, float input)
        {
            float value = 0;
            switch (temp)
            {
                case "Sztuka":
                    value = input;
                    break;
                case "Tuzin":
                    value = input * 12;
                    break;
                case "Mendel":
                    value = input * 15;
                    break;
                case "Mendel chłopski":
                    value = input * 16;
                    break;
                case "Kopa":
                    value = input *60 ;
                    break;
                case "Gros":
                    value = input * 144;
                    break;
            }
            value = System.Convert.ToSingle(value.ToString());
            return value;
        }
    }
}
