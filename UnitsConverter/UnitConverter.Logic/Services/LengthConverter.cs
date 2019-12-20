using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Units_Converter.Services
{
    public class LengthConverter : IConverter
    {
        public string Name => "Lengths";

        public List<string> Units => new List<string>(new[] { "m", "km", "cal" });

        public decimal Convert(string unitFrom, string unitTo, decimal value)
        {
            return value * 2;
        }
    }
}