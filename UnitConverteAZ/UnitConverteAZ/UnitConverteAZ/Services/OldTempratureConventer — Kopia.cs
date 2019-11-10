using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConverteAZ
{
    class TempratureConventer
    {
        private string fromValue;
        private string tounitValue;
        private double value;

        public TempratureConventer()
        { }


            public TempratureConventer(string fromValue, string tounitValue, double value)
        {
            this.fromValue = fromValue;
            this.tounitValue = tounitValue;
            this.value = value;
        }

        public double convertTemprature(string from, string to)
        {
            double calcuatedValue=0;
            switch(from)
            {
                case "Celcius":
                    calcuatedValue = convertFromCelcius(to);
                    break;
                case "Fahrenheit":
                    calcuatedValue = convertFromFahrenheit(to);
                    break;


                case "Kalvin":
                    calcuatedValue = convertFromKalvin(to);
                    break;
                case "Rankine":
                    calcuatedValue = convertFromRankine(to);
                    break;
                default:
                    return this.value;

            }

            return calcuatedValue;
        }


        public double convertFromCelcius(string tounit)
        {
            switch (tounit)
            {
                case "Kalvin":
                    return this.value+ 273.15;
                case "Fahrenheit":
                    return ((this.value * 1.8)+32);
                case "Rankine":
                    return ((this.value + 237.15)*1.8);

                default:
                    return this.value;

            }
        }
        public double convertFromKalvin(string tounit)
        {
            switch (tounit)
            {
                case "Celcius":
                    return this.value-273.15;
                case "Fahrenheit":
                    return ((this.value * 1.8) -459.67); ;
                case "Rankine":
                    return (this.value * 1.8);
                default:
                    return this.value;

            }
        }


        public double convertFromFahrenheit(string tounit)
        {
            switch (tounit)
            {

                case "Celcius":
                    return (this.value - 32)/ 1.8;
                case "Kalvin":
                    return (this.value + 459.67)*5/9;
              
                case "Rankine":
                    return ((this.value -32) + 491.67);

                default:
                    return this.value;

            }
        }
        public double convertFromRankine(string tounit)
        {
            switch (tounit)
            {

                case "Celcius":
                    return (this.value /1.8)-273.15;
                case "Kalvin":
                    return (this.value *5/9);

                case "Fahrenheit":
                    return (this.value - 459.67);

                default:
                    return this.value;

            }
        }

    }
}
