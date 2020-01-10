using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Convert
{
    public class ConverterClass
    {
        public static decimal ConvertValue(string converterType, string valueToConvert, string fromUnit, string toUnit)
        {
            Object converter = Type.GetType(converterType, false, true)
                .GetConstructor(new Type[] { })
                    .Invoke(new object[] { });

            Object classInstance = converter;
            double convertFromValue = Double.Parse(valueToConvert.Replace(".", ","));
            decimal convertedValue;
            Type classType = classInstance.GetType();
            PropertyInfo set = classType.GetProperty(fromUnit);
            PropertyInfo get = classType.GetProperty(toUnit);
            if (set == null || get == null)
            {
                throw new MethodAccessException();
            }
            set.SetValue(classInstance, convertFromValue);
            convertedValue = Decimal.Parse(get.GetValue(classInstance).ToString());
            //DbLog(convertFromValue, fromUnit, toUnit, convertedValue);
            return convertedValue;
        }
    }
}
