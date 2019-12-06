using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace UnitsConverter.Services
{
   public  class TempConverter : IConverter
    {
        public string Name => "Temperature";
        public  List<string> Units => new List<string>(new[] { "C", "K", "F", "R" });
        public decimal Convert(string FromCombobox, string ToCombobox, decimal valueFrom)
        {
             decimal F2C(decimal fahrenheit) =>
           (fahrenheit - 32.0M) / 1.8M;
            static decimal C2F(decimal celsius) =>
               (celsius * 1.8M) + 32.0M;

             decimal C2K(decimal celsius) =>
              celsius + 273.15M;

             decimal K2C(decimal kelvin) =>
              kelvin - 273.15M;

             decimal C2R(decimal celsius) =>
               (celsius + 273.15M) * 1.8M;

             decimal R2C(decimal rankine) =>
               (rankine / 1.8M) - 273.15M;
           
                switch (FromCombobox)
                {
                    case "C":
                        switch (ToCombobox)
                        {
                            case "K":
                                return C2K(valueFrom);
                            case "F":
                                return C2F(valueFrom);
                            case "R":
                                return C2R(valueFrom);
                        }
                        break;
                    case "K":
                        switch (ToCombobox)
                        {
                            case "C":
                                return K2C(valueFrom);
                            case "F":
                                return C2F(K2C(valueFrom));
                            case "R":
                                return C2R(K2C(valueFrom));
                        }
                        break;
                    case "F":
                        switch (ToCombobox)
                        {
                            case "C":
                                return F2C(valueFrom);
                            case "K":
                                return C2K(F2C(valueFrom));
                            case "R":
                                return C2R(F2C(valueFrom));
                        }
                        break;
                    case "R":
                        switch (ToCombobox)
                        {
                            case "C":
                                return R2C(valueFrom);
                            case "K":
                                return C2K(R2C(valueFrom));
                            case "F":
                                return C2F(R2C(valueFrom));
                        }
                        break;

                }
                return 0;
            

        }
    }
}
