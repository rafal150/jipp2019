using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitConverter.Logic;
using UnitsConverter.Services;

namespace UnitConverter.Services
{
    class CurrencyConverter : CurrencyConverterApi, IConverter
    {  
        public string Name => "Currency";
        public List<string> Units => new List<string> { "EUR", "PLN" };

         
        
       
        public decimal Convert(string FromCombobox, string ToCombobox, decimal valueFrom)
        {
            CurrencyConverterApi p = new CurrencyConverterApi();
            decimal currency;
        string code = "EUR";
            currency = Currency(code);

            decimal PLN2EUR(decimal pln)
            { 
                return pln * currency;
            }

             decimal EUR2PLN(decimal eur)
            {
                return eur / currency;
            }

            switch (FromCombobox)
            {
                case "EUR":
                    switch (ToCombobox)
                    {
                        case "PLN":
                            return PLN2EUR(valueFrom);

                    }
                    break;
                case "PLN":
                    switch (ToCombobox)
                    {
                        case "EUR":
                            return EUR2PLN(valueFrom);

                    }
                    break;
            }
            return 0;



        }
    }
}