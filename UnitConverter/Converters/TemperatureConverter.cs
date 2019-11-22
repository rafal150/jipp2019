using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverter.Converters
{
    class TemperatureConverter : IConverter
    {
        public string Name => "Temperature";
        public List<string> Units => new List<string>(new[] { "CELCJUSZ", "FARENHEIT", "KELVIN", "RANKINE" });

        public double Convert(string unitFrom, string unitTo, double a)
        {
            TemperatureUnit from = (TemperatureUnit)System.Enum.Parse(typeof(TemperatureUnit), unitFrom);
            TemperatureUnit to = (TemperatureUnit)System.Enum.Parse(typeof(TemperatureUnit), unitTo);
            if (from == TemperatureUnit.CELCJUSZ && to == TemperatureUnit.CELCJUSZ) { return a; }

            if (from == TemperatureUnit.CELCJUSZ && to == TemperatureUnit.KELVIN)
            {
                new UnitOf.Temperature().FromCelsius(a).ToKelvin();

            }
            if (from == TemperatureUnit.CELCJUSZ && to == TemperatureUnit.FARENHEIT)
            {
                return new UnitOf.Temperature().FromCelsius(a).ToFahrenheit();

            }
            if (from == TemperatureUnit.CELCJUSZ && to == TemperatureUnit.RANKINE)
            {
                return new UnitOf.Temperature().FromCelsius(a).ToRankine();

            }


            if (from == TemperatureUnit.KELVIN && to == TemperatureUnit.KELVIN) { return a; }

            if (from == TemperatureUnit.KELVIN && to == TemperatureUnit.CELCJUSZ)
            {
                new UnitOf.Temperature().FromKelvin(a).ToCelsius();

            }
            if (from == TemperatureUnit.KELVIN && to == TemperatureUnit.FARENHEIT)
            {
                return new UnitOf.Temperature().FromKelvin(a).ToFahrenheit();

            }
            if (from == TemperatureUnit.KELVIN && to == TemperatureUnit.RANKINE)
            {
                return new UnitOf.Temperature().FromKelvin(a).ToRankine();

            }


            if (from == TemperatureUnit.FARENHEIT && to == TemperatureUnit.FARENHEIT) { return a; }

            if (from == TemperatureUnit.FARENHEIT && to == TemperatureUnit.CELCJUSZ)
            {
                new UnitOf.Temperature().FromFahrenheit(a).ToCelsius();

            }
            if (from == TemperatureUnit.FARENHEIT && to == TemperatureUnit.KELVIN)
            {
                return new UnitOf.Temperature().FromFahrenheit(a).ToKelvin();

            }
            if (from == TemperatureUnit.FARENHEIT && to == TemperatureUnit.RANKINE)
            {
                return new UnitOf.Temperature().FromFahrenheit(a).ToRankine();

            }

            if (from == TemperatureUnit.RANKINE && to == TemperatureUnit.RANKINE) { return a; }

            if (from == TemperatureUnit.RANKINE && to == TemperatureUnit.CELCJUSZ)
            {
                new UnitOf.Temperature().FromRankine(a).ToCelsius();

            }
            if (from == TemperatureUnit.RANKINE && to == TemperatureUnit.KELVIN)
            {
                return new UnitOf.Temperature().FromRankine(a).ToKelvin();

            }
            if (from == TemperatureUnit.RANKINE && to == TemperatureUnit.FARENHEIT)
            {
                return new UnitOf.Temperature().FromRankine(a).ToFahrenheit();
            }
            return a;
        }
    }
}
