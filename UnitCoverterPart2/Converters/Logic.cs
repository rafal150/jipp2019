using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using RestSharp;

namespace Converters
{
    public class Converter
    {
        public string code;
        public string name;
        public char type; // 'C' - coeficient, 'V' - , 'I' - from internet
        public List<string> units;
        public List<double> coefficients;
        public string[,] countMethod;
        public string[,] apiMethod;

        public List<string> getUnits()
        {
            return units;
        }

        double FindCoefficient(string unit)
        {
            for (int i = 0; i < units.Count; i++)
                if (unit == units[i])
                    return coefficients[i];

            return 0;
        }

        int FintUnitIdx(string unit)
        {
            for (int i = 0; i < units.Count; i++)
                if (unit == units[i])
                    return i;

            return -1;
        }

        public double CheckUnits(string convertFromUnit, string convertToUnit, double valueFrom)
        {
            if(type == 'C')
                return (valueFrom / FindCoefficient(convertFromUnit)) * FindCoefficient(convertToUnit);
            if (type == 'V')
                return CountValue(convertFromUnit, convertToUnit, valueFrom);
            if (type == 'I')
                return FromInternetValue(convertFromUnit, convertToUnit, valueFrom);

            return 0;
        }

        //przelicza na podstawie wzoru
        double CountValue(string convertFromUnit, string convertToUnit, double valueFrom)
        {
            string method = countMethod[FintUnitIdx(convertFromUnit),FintUnitIdx(convertToUnit)];
            if (string.IsNullOrEmpty(method))
                return 0;

            string[] operations = method.Split(';');
            if (operations.Length <= 0)
                return 0;

            double result = valueFrom;

            foreach(string operation in operations)
            {
                if(!string.IsNullOrEmpty(operation) && operation.Length>=2)
                {
                    double value = double.Parse(operation.Substring(1, operation.Length-1).Replace(".",","));
                    if(operation[0] == '+')
                    {
                        result = result + value;
                    }
                    else if (operation[0] == '-')
                    {
                        result = result - value;
                    }
                    else if (operation[0] == '*')
                    {
                        result = result * value;
                    }
                    else if (operation[0] == '/')
                    {
                        result = result / value;
                    }
                }
            }

            return result;
        }

        //odczytuje z internetowego API
        double FromInternetValue(string convertFromUnit, string convertToUnit, double valueFrom)
        {
            return 0;
        }
    }

    public class Logic
    {
        static Logic instance;
        public class ConverterType
        {
            public string code { get; set; }
            public string name { get; set; }

            public override string ToString()
            {
                return name;
            }
        }
        Dictionary<string, Converter> converters;

        public class ConverterTypes
        {
            public List<ConverterType> types { get; set; }
        }
        public class Units
        {
            public List<string> units { get; set; }
        }


        public static Logic GetInstance()
        {
            if (instance == null)
                instance = new Logic();

            return instance;
        }

        private Logic()
        {
            converters = new Dictionary<string, Converter>();

            //przy pierwszym uruchomieniu aplikacji tworzę trzy przykładowe pliki z konwerterami
            if(!File.Exists(@".\plugins\lenght.json"))
            {
                string json = JsonConvert.SerializeObject(new Converter()
                {
                    code = "LENGHT",
                    name = "Długość",
                    type = 'C',
                    units = new List<string> { "mm", "cm", "dm", "m", "km", "cal", "stopa", "jard", "mila", "kabel", "mila morska" },
                    coefficients = new List<double> { 1000, 100, 10, 1, 0.001, 39.3700787, 3.2808399, 1.093613, 0.000621371192, 0.0054, 0.0005399999568000035 }
                });
                File.WriteAllText(@".\plugins\lenght.json", json);
            }
            if (!File.Exists(@".\plugins\weight.json"))
            {
                string json = JsonConvert.SerializeObject(new Converter()
                {
                    code = "WEIGHT",
                    name = "Waga",
                    type = 'C',
                    units = new List<string> { "mg", "g", "dkg", "kg", "T", "uncja", "funt", "karat", "kwintal" },
                    coefficients = new List<double> { 1000000, 1000, 100, 1, 0.001, 35.273962, 2.204623, 4999.999985, 0.01 }
                });
                File.WriteAllText(@".\plugins\weight.json", json);
            }
            if (!File.Exists(@".\plugins\temperature.json"))
            {
                string json = JsonConvert.SerializeObject(new Converter()
                {
                    code = "TEMP",
                    name = "Temperatura",
                    type = 'V',
                    units = new List<string> { "°C", "°F", "K", "°Rank" },
                    countMethod = new string[,] { { "", "*1.8;+32.0", "+273,15", "+273.15;*1.8" }, { "-32.0;/1.8", "", "", "" }, { "-273.15", "", "", "" }, { "/1.8;-273.15", "", "", "" } }
                });
                File.WriteAllText(@".\plugins\temperature.json", json);
            }

            //wczytywanie plików z konwerterami
            string[] files = Directory.GetFiles(@".\plugins");
            foreach(string file in files)
            {
                string json = File.ReadAllText(file);
                Converter converter = (Converter)JsonConvert.DeserializeObject<Converter>(json);
                converters.Add(converter.code, converter);
            }
        }

        public ConverterTypes getConverterTypes()
        {
            ConverterTypes result = new ConverterTypes();
            result.types = new List<ConverterType>();
            foreach(Converter conv in converters.Values)
            {
                result.types.Add(new ConverterType { code = conv.code, name = conv.name });
            }

            return result;
        }

        public Units getUnits(string type)
        {
            Units result = new Units();
            result.units = converters[type].getUnits();

            return result;
        }
       
        public double CheckUnits(string converterType, string convertFrom, string convertTo, double valueFrom)
        {
            return converters[converterType].CheckUnits(convertFrom, convertTo, valueFrom);
        }




        #region temperatury

        public static double CheckTempUnits(string convertFrom, string convertTo, double valueFrom)
        {
            if (convertFrom == "K")
            {
                if (convertTo == "°C")
                    return KelvinToCelsius(valueFrom);
                else if (convertTo == "°F")
                    return CelsiusToFahrenheit(KelvinToCelsius(valueFrom));
                else if (convertTo == "°Rank")
                    return CelsiusToRankine(KelvinToCelsius(valueFrom));
            }
            else if (convertFrom == "°C")
            {
                if (convertTo == "K")
                    return CelsiusToKelvin(valueFrom);
                else if (convertTo == "°F")
                    return CelsiusToFahrenheit(valueFrom);
                else if (convertTo == "°Rank")
                    return CelsiusToRankine(valueFrom);
            }
            else if (convertFrom == "°F")
            {
                if (convertTo == "°C")
                    return FahrenheitToCelsius(valueFrom);
                else if (convertTo == "K")
                    return CelsiusToKelvin(FahrenheitToCelsius(valueFrom));
                else if (convertTo == "°Rank")
                    return CelsiusToRankine(FahrenheitToCelsius(valueFrom));
            }
            else if (convertFrom == "°Rank")
            {
                if (convertTo == "°C")
                    return RankineToCelsius(valueFrom);
                else if (convertTo == "K")
                    return CelsiusToKelvin(RankineToCelsius(valueFrom));
                else if (convertTo == "°F")
                    return CelsiusToFahrenheit(RankineToCelsius(valueFrom));
            }

            return 0;
        }


        public static double FahrenheitToCelsius(double fahrenheit) =>
            (fahrenheit - 32.0) / 1.8;

        public static double CelsiusToFahrenheit(double celsius) =>
            (celsius * 1.8) + 32.0;

        public static double CelsiusToKelvin(double celsius) =>
           celsius + 273.15;

        public static double KelvinToCelsius(double kelvin) =>
           kelvin - 273.15;

        public static double CelsiusToRankine(double celsius) =>
            (celsius + 273.15) * 1.8;

        public static double RankineToCelsius(double rankine) =>
            (rankine / 1.8) - 273.15;

        #endregion

    }
}
