using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Converter
{
    class WeConverter : IConverter
    {
        public string Name => "Waga";
        public List<string> Units => new List<string>(new[] { "MG", "G", "DKG", "KG", "T", "UNCJA", "FUNT", "KARAT", "KWINTAL" });

        static readonly string[] jednostki = new string[] { "MG", "G", "DKG", "KG", "T", "UNCJA", "FUNT", "KARAT", "KWINTAL" };
        static readonly decimal[] wartosc = new decimal[] { 1000000, 1000, 100, 1, 0.001M, 35.27M, 2.20M, 4999.99M, 0.01M };

        private static decimal Waga(string unit)
        {


            for (int i = 0; i < jednostki.Length; i++)
                if (unit == jednostki[i])
                    return wartosc[i];
            return 0;
        }
        public decimal Convert(string unitFrom, string unitTo, decimal valueFrom)
        {
            return (valueFrom / Waga(unitFrom)) * Waga(unitTo);
        }
    }
}

