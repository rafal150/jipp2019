using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterLogic
{
    public class Converter : IConverter
    {

        private readonly IRepository<StatisticsEntryDto> _repository;

        /// <summary>
        /// zestawy konwerterów.
        /// 
        /// kluczem jest para (jednostka od - jednostka do), a wartością jest funkcja konwertująca
        /// 
        /// </summary>
        /// <returns></returns>     
        private readonly Dictionary<Tuple<String, String>, UnitConversion> _conversions = new Dictionary<Tuple<string, string>, UnitConversion>();

        //konstruktor. przekazujemy konkretna implementacje repozytorium (azure / sqlserver)
        public Converter(IRepository<StatisticsEntryDto> repository)
        {
            _repository = repository;
            AddConvertion("Metr", "Kilometr", d => d / 1000);
            AddConvertion("Metr", "Decymetr", d => d * 10);
            AddConvertion("Metr", "Centymetr", d => d * 100);
            AddConvertion("Metr", "Milimetr", d => d * 1000);

            AddConvertion("Kilometr", "Metr", d => d * 1000);
            AddConvertion("Kilometr", "Decymetr", d => d * 10000);
            AddConvertion("Kilometr", "Centymetr", d => d * 100000);
            AddConvertion("Kilometr", "Milimetr", d => d * 1000000);

            AddConvertion("Decymetr", "Metr", d => d / 10);
            AddConvertion("Decymetr", "Kilometr", d => d / 1000);
            AddConvertion("Decymetr", "Centymetr", d => d * 10);
            AddConvertion("Decymetr", "Milimetr", d => d * 100);

            AddConvertion("Centymetr", "Metr", d => d / 100);
            AddConvertion("Centymetr", "Kilometr", d => d / 10000);
            AddConvertion("Centymetr", "Decymetr", d => d / 10);
            AddConvertion("Centymetr", "Milimetr", d => d * 100);

            AddConvertion("Milimetr", "Metr", d => d / 1000);
            AddConvertion("Milimetr", "Kilometr", d => d / 100000);
            AddConvertion("Milimetr", "Decymetr", d => d / 100);
            AddConvertion("Milimetr", "Centymetr", d => d / 10);

            AddConvertion("Cal", "Stopa", d => d * 0.0833);
            AddConvertion("Cal", "Jard", d => d * 0.02778);
            AddConvertion("Cal", "Mila", d => d * 0.00002);

            AddConvertion("Stopa", "Cal", d => d * 12);
            AddConvertion("Stopa", "Jard", d => d * 0.0333);
            AddConvertion("Stopa", "Mila", d => d * 0.00019);

            AddConvertion("Jard", "Cal", d => d * 36);
            AddConvertion("Jard", "Stopa", d => d * 3);
            AddConvertion("Jard", "Mila", d => d * 0.00057);

            AddConvertion("Mila", "Cal", d => d * 63360);
            AddConvertion("Mila", "Stopa", d => d * 5280);
            AddConvertion("Mila", "Jard", d => d * 1760);

            AddConvertion("Kabel", "Mila morska", d => d * 0.1);
            AddConvertion("Mila morska", "Kabel", d => d * 10);

            AddConvertion("Celsjusz", "Kelvin", d => d + 273.15);
            AddConvertion("Celsjusz", "Fahrenheit", d => d * 1.8 + 32);
            AddConvertion("Celsjusz", "Rankine", d => d + 273.15 * 1.8);

            AddConvertion("Fahrenheit", "Kelvin", d => d + 459.67 * 5 / 9);
            AddConvertion("Fahrenheit", "Celsjusz", d => 5 / 9 * (d - 32));
            AddConvertion("Fahrenheit", "Rankine", d => d + 460.67);

            AddConvertion("Kelvin", "Fahrenheit", d => d - 457.87);
            AddConvertion("Kelvin", "Celsjusz", d => d - 273.15);
            AddConvertion("Kelvin", "Rankine", d => d * 1.8);

            AddConvertion("Rankine", "Fahrenheit", d => d - 458.67);
            AddConvertion("Rankine", "Celsjusz", d => d - 272.59);
            AddConvertion("Rankine", "Kelvin", d => d / 0.55);

            AddConvertion("tona", "kilogram", d => d * 1000);
            AddConvertion("tona", "dekagram", d => d * 100000);
            AddConvertion("tona", "gram", d => d * 1000000);
            AddConvertion("tona", "miligram", d => d * 1000000000);

            AddConvertion("kilogram", "tona", d => d * 0.001);
            AddConvertion("kilogram", "dekagram", d => d * 100);
            AddConvertion("kilogram", "gram", d => d * 1000);
            AddConvertion("kilogram", "miligram", d => d * 1000000);

            AddConvertion("dekagram", "tona", d => d * 0.00001);
            AddConvertion("dekagram", "kilogram", d => d * 0.01);
            AddConvertion("dekagram", "gram", d => d * 10);
            AddConvertion("dekagram", "miligram", d => d * 10000);

            AddConvertion("gram", "tona", d => d * 0.000001);
            AddConvertion("gram", "kilogram", d => d * 0.001);
            AddConvertion("gram", "dekagram", d => d * 0.1);
            AddConvertion("gram", "miligram", d => d * 1000);

            AddConvertion("miligram", "tona", d => d * 0.00000000001);
            AddConvertion("miligram", "kilogram", d => d * 0.000001);
            AddConvertion("miligram", "dekagram", d => d * 0.0001);
            AddConvertion("miligram", "gram", d => d * 0.001);

            AddConvertion("uncja", "funt", d => d * 0.0625);
            AddConvertion("funt", "uncja", d => d * 13.1657);

            AddConvertion("karat", "kwintal", d => d * 0.000002);
            AddConvertion("kwintal", "karat", d => d * 500000);
        }

        public double Convert(String from, String to, double value)
        {
            if (from.Equals(to))
            {
                return value;
            }

            //wyszukujemy w mapie konwerterow konwerter dla danej pary od - do
            var conversionKey = new Tuple<String, String>(from, to);
            if (!_conversions.ContainsKey(conversionKey))
            {
                throw new ArgumentException("Nieznana konwersja from " + from + " to " + to);
            }

            var converter = _conversions[conversionKey];
            var result = converter.Convert(value);

            //po konwersji zapisujemy do repozytorium wywolanie konwertera z wynikiem
            _repository.Save(new StatisticsEntryDto(DateTime.Now, from, to, value.ToString(), result));
            return result;
        }

        public void AddConvertion(String from, String to, Func<double, double> conversionFunc)
        {
            var conversionKey = new Tuple<String, String>(from, to);
            _conversions[conversionKey] = new UnitConversion(from, to, conversionFunc);
        }

        //zwracamy liste dostepnych jednostek do konwersji
        public List<string> GetKeysFrom() => _conversions.Keys.Select(x => x.Item1).Distinct().ToList();

        //zwracamy liste dostepnych jednostek do konwersji z wskazanej jednostki
        public List<string> GetKeysTo(string from) => _conversions.Keys.Where(x => x.Item1 == from).Select(x => x.Item2).Distinct().ToList();
    }


}

