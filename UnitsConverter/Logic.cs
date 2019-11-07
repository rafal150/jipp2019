using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace UnitsConverter
{
    class Logic : Listy
    {
        private static string d, c;


        #region temperatury
        public static decimal F2C(decimal fahrenheit) =>
            (fahrenheit - 32.0M) / 1.8M;

        public static decimal C2F(decimal celsius) =>
            (celsius * 1.8M) + 32.0M;

        public static decimal C2K(decimal celsius) =>
           celsius + 273.15M;

        public static decimal K2C(decimal kelvin) =>
           kelvin - 273.15M;

        public static decimal C2R(decimal celsius) =>
            (celsius + 273.15M) * 1.8M;

        public static decimal R2C(decimal rankine) =>
            (rankine / 1.8M) - 273.15M;


        #endregion


        private static decimal SelectUnit(string unit)
        {


            for (int i = 0; i < lengthUnits.Length; i++)
                if (unit == lengthUnits[i])
                    return length[i];
            return 0;
        }
        private static decimal SelectWeight(string unit)
        {


            for (int i = 0; i < weightUnits.Length; i++)
                if (unit == weightUnits[i])
                    return weight[i];
            return 0;
        }

        public static decimal CheckLengthUnits(string convertFrom, string convertTo, decimal valueFrom)
        {
            return (valueFrom / SelectUnit(convertFrom)) * SelectUnit(convertTo);

        }

        public static decimal CheckWeightUnits(string convertFrom, string convertTo, decimal valueFrom)
        {
            return (valueFrom / SelectWeight(convertFrom)) * SelectUnit(convertTo);

        }
        public static decimal CheckTempUnits(string FromCombobox, string ToCombobox, decimal valueFrom) {
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



