using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter
{
    public interface IConverting
    {
        List<String> listaJednostek { get; }
        float Convert(string from, string to, double amount);
    }

    public class ConverterManager
    {
        public Kategoria kategoria;
        public Dictionary<Kategoria, IConverting> dict = new Dictionary<Kategoria, IConverting>() {
            { Kategoria.Temparatura, new ConverterT() },
            { Kategoria.Długość, new ConverterD() },
            { Kategoria.Masa, new ConverterM() }
        };

        public List<string> listaJednostek
        {
            get
            {
                return dict[kategoria].listaJednostek;
            }
        }

        public float Convert(string from, string to, float amount)
        {
            if (from == to)
            {
                return amount;
            }

            return dict[kategoria].Convert(from, to, amount);
        }
    }
}
