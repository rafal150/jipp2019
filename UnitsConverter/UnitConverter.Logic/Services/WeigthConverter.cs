using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Units_Converter.Services
{
    class WeigthConverter : IConverter
    {
        public string Name => "Weigths";

        public List<string> Units => new List<string>(new[] { "kg", "f", "g" });

        public decimal Convert(string unitFrom, string unitTo, decimal value)
        {
            return value * 100;
        }
    }
}
