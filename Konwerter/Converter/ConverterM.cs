using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter
{
    public class ConverterM: IConverting
    {
        public ConverterM() { }
        public List<string> listaJednostek
        {
            get
            {
                return new List<String>(new[] { "mg", "g", "dkg", "kg", "T", "uncja", "funt", "karat", "kwintal" });
            }
        }

        public float Convert(string from, string to, double amount)
        {
            // To g
            switch (from)
            {
                case "mg":
                    amount *= 0.001;
                    break;
                case "dkg":
                    amount *= 10;
                    break;
                case "kg":
                    amount *= 1000;
                    break;
                case "T":
                    amount *= 1000000;
                    break;
                case "uncja":
                    amount *= 28.3495231;
                    break;
                case "funt":
                    break;
                case "karat":
                    amount *= 0.2;
                    break;
                case "kwintal":
                    amount *= 100000;
                    break;
            }


            switch (to)
            {
                case "mg":
                    amount *= 1000;
                    break;
                case "g":
                    amount *= 1;
                    break;
                case "dkg":
                    amount *= 0.1;
                    break;
                case "kg":
                    amount *= 0.001;
                    break;
                case "T":
                    amount *= 1000000;
                    break;
                case "uncja":
                    amount *= 0.0352739619;
                    break;
                case "funt":
                    amount *= 0.00220462262;
                    break;
                case "karat":
                    amount *= 5;
                    break;
                case "kwintal":
                    amount *= 0.00001;
                    break;
            }

            return (float)amount;
        }
    }
}
