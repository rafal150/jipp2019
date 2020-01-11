using JIPP5.SDK;
using System.Collections.Generic;

namespace JIPP5_LAB.Converters
{
    public class LengthConverter : IConverter
    {
        public string Name { get { return "Długość"; } }

        public List<string> Units
        {
            get
            {
                return new List<string>() {"Milimetry","Centymetry","Metry","Decymetry","Kilometry","Cale","Stopy","JardyMile","Kable","Mile morskie"};
            }
        }

        public decimal Converter(string FromUNIT, decimal RawVALUE, string ToUNIT)
        {
            switch (FromUNIT)
            {
                case "Milimetry":
                    {
                        RawVALUE *= (decimal)0.001;
                        break;
                    }

                case "Centymetry":
                    {
                        RawVALUE *= (decimal)0.01;
                        break;
                    }

                case "Decymetry":
                    {
                        RawVALUE *= (decimal)0.1;
                        break;
                    }

                case "Kilometry":
                    {
                        RawVALUE *= (decimal)1000;
                        break;
                    }

                case "Cale":
                    {
                        RawVALUE *= (decimal)0.0254;
                        break;
                    }

                case "Stopy":
                    {
                        RawVALUE *= (decimal)0.3048;
                        break;
                    }

                case "Jardy":
                    {
                        RawVALUE *= (decimal)0.9144;
                        break;
                    }

                case "Mile":
                    {
                        RawVALUE *= (decimal)1609.344;
                        break;
                    }

                case "Kable":
                    {
                        RawVALUE *= (decimal)185.2;
                        break;
                    }

                case "Mile morskie":
                    {
                        RawVALUE *= (decimal)1852;
                        break;
                    }
            }

            switch (ToUNIT)
            {
                case "Milimetry":
                    {
                        RawVALUE *= 1000;
                        break;
                    }

                case "Centymetry":
                    {
                        RawVALUE *= 100;
                        break;
                    }

                case "Decymetry":
                    {
                        RawVALUE *= 10;
                        break;
                    }

                case "Kilometry":
                    {
                        RawVALUE *= (decimal)0.001;
                        break;
                    }

                case "Cale":
                    {
                        RawVALUE *= (decimal)39.37;
                        break;
                    }

                case "Stopy":
                    {
                        RawVALUE *= (decimal)3.2808399;
                        break;
                    }

                case "Jardy":
                    {
                        RawVALUE *= (decimal)1.0936133;
                        break;
                    }

                case "Mile":
                    {
                        RawVALUE *= (decimal)0.000621371192;
                        break;
                    }

                case "Kable":
                    {
                        RawVALUE *= (decimal)0.005399568034;
                        break;
                    }

                case "Mile morskie":
                    {
                        RawVALUE *= (decimal)0.0005399568034;
                        break;
                    }
            }
            return RawVALUE;
        }
    }
}