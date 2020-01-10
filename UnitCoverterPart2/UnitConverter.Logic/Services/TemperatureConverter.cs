using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitCoverterPart2.Services;

namespace TemperatureConverter
{
    public class TemperatureConverter : IConverter
    {
        public string Name => "Temperatury";

        public List<string> Units => new List<string>(new[] { "C", "K", "F", "R", });

        public double Convert(string unitFrom, string unitTo, double value)
        {
            if (unitFrom == "C" && unitTo == "F")        //CELCJUSZ NA FAHRENHEIT
            {

                value = (value * 1.8 + 32);

            }

            if (unitFrom == "K" && unitTo == "F")        //KELWIN NA FAHRENHEIT
            {

                value = (value * 1.8 - 459);

            }

            if (unitFrom == "R" && unitTo == "F")        //RANKINE NA FAHRENHEIT
            {

                value = (value - 459);

            }

            if (unitFrom == "F" && unitTo == "F")        //FARENHEIT NA FAHRENHEIT
            {

                value = (value * 1);

            }
            //FAHRENHEIT NA CELCJUSZE

            if (unitFrom == "F" && unitTo == "C")
            {

                value = (value - 32) / 1.8;

            }

            if (unitFrom == "F" && unitTo == "K")        //FAHRENHEIT NA KELWINY            
            {

                value = (value + 459) * 5 / 9;

            }

            if (unitFrom == "F" && unitTo == "R")         //FAHRENHEIT NA RANKINE    
            {

                value = (value + 459);

            }

            //CELCJUSZ NA KELWINY
            if (unitFrom == "C" && unitTo == "K")
            {

                value = (value + 273.15);

            }

            if (unitFrom == "C" && unitTo == "R")        //CELCJUSZ NA RANKINE
            {

                value = (value + 273.15) * 1.8;

            }

            if (unitFrom == "C" && unitTo == "C")        //CELCJUSZ NA CELCJUSZ
            {

                value = (value * 1);

            }

            //RANKINE NA CELCJUSZE
            if (unitFrom == "R" && unitTo == "C")
            {

                value = (value - 491) / 1.8;

            }

            if (unitFrom == "R" && unitTo == "K")         //RANKINE NA KELWINY
            {

                value = ((value - 491) / 1.8) + 273;

            }

            if (unitFrom == "R" && unitTo == "R")         //RANKINE NA RANKINE
            {

                value = (value * 1);

            }
            return value;
        }
    }
}
