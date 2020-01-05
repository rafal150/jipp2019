using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using UnitConversion;

namespace UnitConversion
{
    public class ConverterService
    {
        private readonly IServiceRepository serviceRepository;
        private readonly ILifetimeScope scope;
        Dictionary<string, UnitConverter> unitConverters;

        public Dictionary<string, UnitConverter> UnitConverters => unitConverters;

        public ConverterService(IServiceRepository serviceRepository, ILifetimeScope scope)
        {
            this.scope = scope;
            this.serviceRepository = serviceRepository;
            GetConverters();
        }

        public List<UnitConverter> GetConverters()
        {
            if(unitConverters == null)
                unitConverters = scope.Resolve<IEnumerable<UnitConverter>>().ToDictionary(x => x.Name, x => x);
            return unitConverters.Values.ToList();
        }

        public bool Convert(string selectedConverter, string unitFrom, string unitTo, decimal value, out decimal convertedValue)
        {
            convertedValue = -1;
            if (unitConverters.ContainsKey(selectedConverter) == false) return false;
            UnitConverter converter = unitConverters[selectedConverter];
            try
            {
                convertedValue = converter.Convert(unitFrom, unitTo, value);

                ConversionHistoryDTO ch = new ConversionHistoryDTO()
                {
                    Created = DateTime.Now,
                    BaseUnit = unitFrom,
                    BaseValue = value,
                    ConversionType = selectedConverter,
                    TargetUnit = unitTo,
                    TargetValue = convertedValue
                };
                serviceRepository.AddConversionHistory(ch);
                return true;
            }
            catch(Exception ex)
            {
                convertedValue = -1;
                return false;
            }
        }

        //public bool Convert(UnitConverter selectedConverter, decimal value, out decimal convertedValue)
        //{
        //    convertedValue = -1;
        //    if (selectedConverter == null) return false;
        //    convertedValue = selectedConverter.Convert(value);

        //    ConversionHistoryDTO ch = new ConversionHistoryDTO()
        //    {
        //        Created = DateTime.Now,
        //        BaseUnit = selectedConverter.BaseUnit.Name,
        //        BaseValue = value,
        //        ConversionType = selectedConverter.Name,
        //        TargetUnit = selectedConverter.TargetUnit.Name,
        //        TargetValue = convertedValue
        //    };
        //    serviceRepository.AddConversionHistory(ch);
        //    return true;
        //}
    }
}
