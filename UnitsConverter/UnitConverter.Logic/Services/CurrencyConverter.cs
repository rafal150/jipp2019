using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;

namespace Units_Converter.Services
{
public class CurrencyConverter : IConverter
    {
public string Name => "Currency";

        public List<string> Units => new List<string>(new[] { "Euro", "PLN" });

        public decimal Convert(string unitFrom, string unitTo, decimal value)
        {
            decimal unitFromD = value;
            if (unitFrom == "Euro")
            {
                if (unitTo == "PLN") value = (unitFromD);
            }
            return value;
        }
    }
}
