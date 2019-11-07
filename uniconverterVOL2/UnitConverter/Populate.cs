using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter
{
    class Populate
    {
        public List<string> populateTemperature()
        {
            List<string> temperature = new List<string>();
            string[] tmp = { "Celsjusz", "Fahrenheit", "Kelvin", "Rankine" };
            temperature.AddRange(tmp);
            return temperature;
        }
        public List<string> populateDistance()
        {
            List<string> distance = new List<string>();
            string[] dist = { "Milimetr","Centymetr", "Metr", "Kilometr", "Decymetr", "Metr", "Kilometr", "Cal", "Stopa", "Jard", "Mila", "Mila morska" };
            distance.AddRange(dist);
            return distance;
        }
        public List<string> populateMass()
        {
            List<string> mass = new List<string>();
            string[] mas = { "Miligram", "Gram", "Dekagram", "Kilogram", "Uncja", "Funt" };
            mass.AddRange(mas);
            return mass;
        }
    }
}
