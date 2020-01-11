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
            decimal unitFromD = value;

            if (unitFrom == "Milligrams")
            {
                if (unitTo == "Grams") value = (unitFromD * 0.001m);
                else if (unitTo == "Decagrams") value = (unitFromD * 0.0001m);
                else if (unitTo == "Kilograms") value = (unitFromD * 0.000001m);
                else if (unitTo == "Tonnes") value = (unitFromD * 0.000000001m);
                else if (unitTo == "Pounds") value = (unitFromD / 453592);
                else if (unitTo == "Ounces") value = (unitFromD / 28349.5m);

            }
            else if (unitFrom == "Grams")
            {
                if (unitTo == "Milligrams") value = (unitFromD * 1000);
                else if (unitTo == "Decagrams") value = (unitFromD * 0.1m);
                else if (unitTo == "Kilograms") value = (unitFromD * 0.001m);
                else if (unitTo == "Tonnes") value = (unitFromD * 0.000001m);
                else if (unitTo == "Pounds") value = (unitFromD / 453.592m);
                else if (unitTo == "Ounces") value = (unitFromD / 28.3495m);
            }
            else if (unitFrom == "Decagrams")
            {
                if (unitTo == "Milligrams") value = (unitFromD * 10000);
                else if (unitTo == "Grams") value = (unitFromD * 10);
                else if (unitTo == "Kilograms") value = (unitFromD * 0.01m);
                else if (unitTo == "Tonnes") value = (unitFromD * 0.00001m);
                else if (unitTo == "Pounds") value = (unitFromD / 45.3592m);
                else if (unitTo == "Ounces") value = (unitFromD / 2.83495m);
            }
            else if (unitFrom == "Kilograms")
            {
                if (unitTo == "Milligrams") value = (unitFromD * 1000);
                else if (unitTo == "Grams") value = (unitFromD * 1000);
                else if (unitTo == "Decagrams") value = (unitFromD * 100);
                else if (unitTo == "Tonnes") value = (unitFromD * 0.001m);
                else if (unitTo == "Pounds") value = (unitFromD * 2.20462m);
                else if (unitTo == "Ounces") value = (unitFromD * 35.274m);
            }
            else if (unitFrom == "Tonnes")
            {
                if (unitTo == "Milligrams") value = (unitFromD * 1000000000);
                else if (unitTo == "Grams") value = (unitFromD * 1000000);
                else if (unitTo == "Decagrams") value = (unitFromD * 100000);
                else if (unitTo == "Kilograms") value = (unitFromD * 1000);
                else if (unitTo == "Pounds") value = (unitFromD * 2204.62m);
                else if (unitTo == "Ounces") value = (unitFromD * 35274);
            }
            else if (unitFrom == "Pounds")
            {
                if (unitTo == "Milligrams") value = (unitFromD * 453592);
                else if (unitTo == "Grams") value = (unitFromD * 453.592m);
                else if (unitTo == "Decagrams") value = (unitFromD * 45.3592m);
                else if (unitTo == "Kilograms") value = (unitFromD * 0.453592m);
                else if (unitTo == "Tonnes") value = (unitFromD / 2204.62m);
                else if (unitTo == "Ounces") value = (unitFromD * 16);
            }
            else if (unitFrom == "Ounces")
            {
                if (unitTo == "Milligrams") value = (unitFromD * 28349.5m);
                else if (unitTo == "Grams") value = (unitFromD * 28.3495m);
                else if (unitTo == "Decagrams") value = (unitFromD * 2.83495m);
                else if (unitTo == "Kilograms") value = (unitFromD * 0.0283495m);
                else if (unitTo == "Tonnes") value = (unitFromD / 0.0000283495m);
                else if (unitTo == "Pounds") value = (unitFromD / 16);
            }
            return value;
        }
    }
}
