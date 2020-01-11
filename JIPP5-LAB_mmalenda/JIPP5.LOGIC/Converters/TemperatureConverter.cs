using JIPP5.SDK;
using System.Collections.Generic;

namespace JIPP5_LAB.Converters
{
    public class TemperatureConverter : IConverter
    {
        public string Name { get { return "Temperatury"; } }

        public List<string> Units
        {
            get
            {
                return new List<string>(){"Celcjusz","Farenheit","Rankine","Kelvin",};
            }
        }

        public decimal Converter(string FromUNIT, decimal RawVALUE, string ToUNIT)
        {
            switch (FromUNIT)
            {
                case "Celcjusz":
                    {
                        RawVALUE += (decimal)273.15;
                        break;
                    }

                case "Farenheit":
                    {
                        RawVALUE = (RawVALUE + (decimal)459.67) * ((decimal)5 / (decimal)9);
                        break;
                    }

                case "Rankine":
                    {
                        RawVALUE *= ((decimal)5 / (decimal)9);
                        break;
                    }
            }

            switch (ToUNIT)
            {
                case "Celcjusz":
                    {
                        RawVALUE -= (decimal)273.15;
                        break;
                    }

                case "Farenheit":
                    {
                        RawVALUE = (RawVALUE * ((decimal)9 / (decimal)5)) - (decimal)459.67;
                        break;
                    }

                case "Rankine":
                    {
                        RawVALUE *= ((decimal)9 / (decimal)5);
                        break;
                    }
            }

            return RawVALUE;
        }
    }
}