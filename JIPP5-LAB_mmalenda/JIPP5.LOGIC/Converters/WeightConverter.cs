using JIPP5.SDK;
using System.Collections.Generic;

namespace JIPP5_LAB.Converters
{
    public class WeightConverter : IConverter
    {
        public string Name { get { return "Wagi"; } }

        public List<string> Units {get {return  new List<string>() {"Miligramy","Dekagramy","Kilogramy","Tony","Uncje","Funty","Karaty","Kwintale","Gramy"}; } }

        public decimal Converter(string FromUNIT, decimal RawVALUE, string ToUNIT)
        {
            switch (FromUNIT)
            {
                case "Miligramy":
                    {
                        RawVALUE *= (decimal)0.001;
                        break;
                    }

                case "Dekagramy":
                    {
                        RawVALUE *= 10;
                        break;
                    }

                case "Kilogramy":
                    {
                        RawVALUE *= 1000;
                        break;
                    }

                case "Tony":
                    {
                        RawVALUE *= 1000000;
                        break;
                    }

                case "Uncje":
                    {
                        RawVALUE *= (decimal)28.3495231;
                        break;
                    }

                case "Funty":
                    {
                        RawVALUE *= (decimal)453.59237;
                        break;
                    }

                case "Karaty":
                    {
                        RawVALUE *= (decimal)0.2;
                        break;
                    }

                case "Kwintale":
                    {
                        RawVALUE *= 100000;
                        break;
                    }
            }

            switch (ToUNIT)
            {
                case "Miligramy":
                    {
                        RawVALUE *= 1000;
                        break;
                    }

                case "Dekagramy":
                    {
                        RawVALUE *= (decimal)0.1;
                        break;
                    }

                case "Kilogramy":
                    {
                        RawVALUE *= (decimal)0.001;
                        break;
                    }

                case "Tony":
                    {
                        RawVALUE *= 1000000;
                        break;
                    }

                case "Uncje":
                    {
                        RawVALUE *= (decimal)0.0352739619;
                        break;
                    }

                case "Funty":
                    {
                        RawVALUE *= (decimal)0.00220462262;
                        break;
                    }

                case "Karaty":
                    {
                        RawVALUE *= 5;
                        break;
                    }

                case "Kwintale":
                    {
                        RawVALUE *= (decimal)0.00001;
                        break;
                    }
            }
            return RawVALUE;
        }
    }
}