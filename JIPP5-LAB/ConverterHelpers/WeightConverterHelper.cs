using JIPP5_LAB.Interfaces;
using System;
using System.Collections.Generic;
using Unity;

namespace JIPP5_LAB.ConverterHelpers
{
    public class WeightConverterHelper : IConverterHelper
    {
        private IDataHelper DataHelper { get; }
        private IUnityContainer Container { get; }

        public string Name => "Masa";

        public List<string> UnitTypes => throw new NotImplementedException();

        public WeightConverterHelper(IDataHelper dataHelper, IUnityContainer unityContainer)
        {
            DataHelper = dataHelper;
            Container = unityContainer;
        }

        public string Convert(string fromUnit, decimal input, string toUnit)
        {
            //var convertedValue = fromUnit.Calculate(input, toUnit.UnitType);
            //var stats = new StatisticModel() {
            //    Date = DateTime.Now,
            //    FromUnit = fromUnit.UnitType.ToString(),
            //    RawData = input,
            //    ToUnit = toUnit.UnitType.ToString(),
            //    Converted = convertedValue
            //};
            //Task.Factory.StartNew(() => {
            //    DataHelper.AddRecord(stats);
            //});
            //return string.Format("{0} {1}", convertedValue.ToString("N", new NumberFormatInfo() { NumberDecimalDigits = 2 }), toUnit.UnitSuffix);
            return "";
        }
    }
}