using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Konwerter.Services;

namespace ConverterE
{
    public class ConverterE : IConverting
    {
        public string Nazwa => "Energia";

        public List<string> ListaJednostek => new List<string>(new[] {"J", "kJ", "Wh", "kWh"});

        public float Convert(string from, string to, double amount)
        {
            // To J
            switch (from)
            {
                case "kJ":
                    amount *= 1000;
                    break;
                case "Wh":
                    amount *= 3600;
                    break;
                case "kwH":
                    amount *= 3600000;
                    break;
            }

            switch (to)
            {
                case "kJ":
                    amount /= 1000;
                    break;
                case "Wh":
                    amount /= 3600;
                    break;
                case "kwH":
                    amount /= 3600000;
                    break;
            }

            return (float)amount;
        }
    }
}
