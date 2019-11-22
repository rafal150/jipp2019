using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter
{
    class Mass: IToBaseConverter
    {
        public float toBaseUnit(string temp, float input) //gram
        {
            float value = 0;
            switch (temp)
            {
                case "Miligram":
                    value = input * 0.001f;
                    break;
                case "Gram":
                    value = input;
                    break;
                case "Dekagram":
                    value = input * 10;
                    break;
                case "Kilogram":
                    value = input * 1000;
                    break;
                case "Uncja":
                    value = input * 28.35f;
                    break;
                case "Funt":
                    value = input * 453.59f;
                    break;
            }
            value = Convert.ToSingle(value.ToString());
            return value;

        }

        public float toUnit(string temp, float input)
        {
            float value = 0;
            switch (temp)
            {
                case "Miligram":
                    value = value * 1000;
                    break;
                case "Gram":
                    value = input;
                    break;
                case "Dekagram":
                    value = input * 0.1f;
                    break;
                case "Kilogram":
                    value = input * 0.001f;
                    break;
                case "Uncja":
                    value = input * 0.0353f;
                    break;
                case "Funt":
                    value = input * 0.0022f;
                    break;
            }
            value = Convert.ToSingle(value.ToString());
            return value;
        }

        public List<string> populate()
        {
            List<string> mass = new List<string>();
            string[] mas = { "Miligram", "Gram", "Dekagram", "Kilogram", "Uncja", "Funt" };
            mass.AddRange(mas);
            return mass;
        }
    }
}
