using JIPP5_LAB.Constants;
using JIPP5_LAB.Database;
using JIPP5_LAB.Interfaces;
using JIPP5_LAB.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace JIPP5_LAB.Helpers
{
    public class ConverterHelper : IConverterHelper
    {
        IDataHelper DataHelper { get; }
        IUnityContainer Container { get; }
        public ConverterHelper(IDataHelper dataHelper, IUnityContainer unityContainer)
        {
            DataHelper = dataHelper;
            Container = unityContainer;
        }
        public string Convert(Unit fromUnit, decimal input, Unit toUnit)
        {
            var convertedValue = fromUnit.Calculate(input, toUnit.UnitType);
            var stats = new StatisticModel() {
                Date = DateTime.Now,
                FromUnit = fromUnit.UnitType.ToString(),
                RawData = input,
                ToUnit = toUnit.UnitType.ToString(),
                Converted = convertedValue
            };
            Task.Factory.StartNew(() => {
                DataHelper.AddRecord(stats);
            });
            return string.Format("{0} {1}", convertedValue.ToString("N", new NumberFormatInfo() { NumberDecimalDigits = 2 }), toUnit.UnitSuffix);
        }
    }
}
