using JIPP5.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JIPP5.Plugin
{
    public class PowerConverter : IConverter
    {
        public string Name { get { return "Dane"; } }

        public List<string> Units { get { return new List<string>() { "Bajt", "Kilobajt", "Gigabajt", "Terabajt" }; } }

        public decimal Converter(string FromUNIT, decimal RawVALUE, string ToUNIT)
        {
            switch (FromUNIT)
            {
                case "Kilobajt":
                    {
                        RawVALUE *= (decimal)1024;
                        break;
                    }

                case "Gigabajt":
                    {
                        RawVALUE *= 1073741824;
                        break;
                    }

                case "Terabajt":
                    {
                        RawVALUE *= (decimal)1099511627776;
                        break;
                    }
            }

            switch (ToUNIT)
            {
                case "Kilobajt":
                    {
                        RawVALUE *= (decimal)0.001024;
                        break;
                    }

                case "Gigabajt":
                    {
                        RawVALUE *= (decimal)0.000001024;
                        break;
                    }

                case "Terabajt":
                    {
                        RawVALUE *= (decimal)0.000000001024;
                        break;
                    }
            }

            return RawVALUE;
        }
    }
}
