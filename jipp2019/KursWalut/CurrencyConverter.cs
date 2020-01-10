using ConverterSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursWalut
{
    public class CurrencyConverter : ConverterInterface
    {
        private double currencyRate;
        private double pln;
        public string name;
        public CurrencyConverter()
        {
            this.currencyRate = CurrencyRate.getCurrency("EUR");
            this.name = this.GetType().Name;
        }
        public double PLN
        {
            get { return this.pln; }
            set { this.pln = value; }
        }
        public double EUR
        {
            get { return this.pln / currencyRate; }
            set { this.pln = value * currencyRate; }
        }

        public static List<string> GetListOfProperties()
        {
            List<string> array = new List<string>();
            foreach (var prop in typeof(CurrencyConverter).GetProperties())
            {
                array.Add(prop.Name);
            }
            return array;
        }
    }
}
