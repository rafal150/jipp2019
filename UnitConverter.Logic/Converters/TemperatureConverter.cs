using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter.Converters
{
    class TemperatureConverter : IConverter
    {
        public string Name => "Temperatury";
        public List<string> Units => new List<string>(new[] { "CELSJUSZ", "FARENHEIT", "KELVIN", "RANKINE" });

        public double Convert(string unitFrom, string unitTo, double value)
        {
            Temperature from = (Temperature)System.Enum.Parse(typeof(Temperature), unitFrom);
            Temperature to = (Temperature)System.Enum.Parse(typeof(Temperature), unitTo);
            if (from == Temperature.CELSJUSZ && to == Temperature.CELSJUSZ) { return value; }
            if (from == Temperature.CELSJUSZ && to == Temperature.KELVIN) { return value + 273.15; }
            if (from == Temperature.CELSJUSZ && to == Temperature.FARENHEIT) { return (value * 1.8 + 32); }
            if (from == Temperature.CELSJUSZ && to == Temperature.RANKINE) { return (value + 273.15) * 1.8; }
            if (from == Temperature.KELVIN && to == Temperature.KELVIN) { return value; }
            if (from == Temperature.KELVIN && to == Temperature.CELSJUSZ) { return value - 273.15; }
            if (from == Temperature.KELVIN && to == Temperature.FARENHEIT) { return value * 1.8 - 459.67; }
            if (from == Temperature.KELVIN && to == Temperature.RANKINE) { return value * 1.8; }
            if (from == Temperature.FARENHEIT && to == Temperature.FARENHEIT) { return value; }
            if (from == Temperature.FARENHEIT && to == Temperature.CELSJUSZ) { return (value - 32) / 1.8; }
            if (from == Temperature.FARENHEIT && to == Temperature.KELVIN) { return (value + 459.67) / 2; }
            if (from == Temperature.FARENHEIT && to == Temperature.RANKINE) { return value + 459.67; }
            if (from == Temperature.RANKINE && to == Temperature.RANKINE) { return value; }
            if (from == Temperature.RANKINE && to == Temperature.CELSJUSZ) { return (value - 491.67) / 2; }
            if (from == Temperature.RANKINE && to == Temperature.KELVIN) { return value / 2; }
            if (from == Temperature.RANKINE && to == Temperature.FARENHEIT) { return value - 459.67; }
            else
                return 0;
        }
    }
}
