using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter.Services
{
    public class ConverterT: IConverting
    {
        public ConverterT() { }

        public string Nazwa => "Temperatura";
        public List<string> ListaJednostek => new List<String>(new[] { "C", "K", "F", "R" });
        public float Convert(string from, string to, double amount)
        {
            // To K
            switch (from)
            {
                case "C":
                    amount += 273.15;
                    break;
                case "F":
                    amount = (amount + 459.67) * (5.0 / 9.0);
                    break;
                case "R":
                    amount /= 1.8;
                    break;
            }

            switch (to)
            {
                case "C":
                    amount -= 273.15;
                    break;
                case "F":
                    amount = amount * (9.0 / 5.0) - 459.67;
                    break;
                case "R":
                    amount *= 1.8;
                    break;

            }

            return (float)amount;
        }
    }
}
