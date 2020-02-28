using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Converter
{
    public class LenConverter : IConverter
    {
        public string Name => "Długosc";

        public List<string> Units
        {
            get
            {
                return new List<string>() { "Milimetry", "Centymetry", "Metry", "Decymetry", "Kilometry", "Cale", "Stopy", "JardyMile", "Kable", "Mile morskie" };
            }
        }
        public decimal Convert(string unitFrom, string unitTo, decimal value)
        {
            switch (unitFrom)
            {
                case "Milimetry":
                    {
                        value *= (decimal)0.001;
                        break;
                    }

                case "Centymetry":
                    {
                        value *= (decimal)0.01;
                        break;
                    }

                case "Decymetry":
                    {
                        value *= (decimal)0.1;
                        break;
                    }

                case "Kilometry":
                    {
                        value *= 1000;
                        break;
                    }

                case "Cale":
                    {
                        value *= (decimal)0.0254;
                        break;
                    }

                case "Stopy":
                    {
                        value *= (decimal)0.3048;
                        break;
                    }

                case "Jardy":
                    {
                        value *= (decimal)0.9144;
                        break;
                    }

                case "Mile":
                    {
                        value *= (decimal)1609.344;
                        break;
                    }

                case "Kable":
                    {
                        value *= (decimal)185.2;
                        break;
                    }

                case "Mile morskie":
                    {
                        value *= 1852;
                        break;
                    }
            }

            switch (unitTo)
            {
                case "Milimetry":
                    {
                        value *= 1000;
                        break;
                    }

                case "Centymetry":
                    {
                        value *= 100;
                        break;
                    }

                case "Decymetry":
                    {
                        value *= 10;
                        break;
                    }

                case "Kilometry":
                    {
                        value *= (decimal)0.001;
                        break;
                    }

                case "Cale":
                    {
                        value *= (decimal)39.37;
                        break;
                    }

                case "Stopy":
                    {
                        value *= (decimal)3.2808399;
                        break;
                    }

                case "Jardy":
                    {
                        value *= (decimal)1.0936133;
                        break;
                    }

                case "Mile":
                    {
                        value *= (decimal)0.000621371192;
                        break;
                    }

                case "Kable":
                    {
                        value *= (decimal)0.005399568034;
                        break;
                    }

                case "Mile morskie":
                    {
                        value *= (decimal)0.0005399568034;
                        break;
                    }
            }
            return value;
        }
    }
}