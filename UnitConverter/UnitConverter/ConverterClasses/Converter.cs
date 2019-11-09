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
        List<UnitConverter> unitConverters;

        public List<UnitConverter> UnitConverters => unitConverters;

        public ConverterService(IServiceRepository serviceRepository, ILifetimeScope scope)
        {
            this.scope = scope;
            this.serviceRepository = serviceRepository;
            GetConverters();
        }

        private void GetConverters()
        {
            unitConverters = scope.Resolve<IEnumerable<UnitConverter>>().ToList();
        }

        public bool Convert(UnitConverter selectedConverter, decimal value, out decimal convertedValue)
        {
            convertedValue = -1;
            if (selectedConverter == null) return false;
            convertedValue = selectedConverter.Convert(value);

            ConversionHistoryDTO ch = new ConversionHistoryDTO()
            {
                Created = DateTime.Now,
                BaseUnit = selectedConverter.BaseUnit.Name,
                BaseValue = value,
                ConversionType = selectedConverter.Name,
                TargetUnit = selectedConverter.TargetUnit.Name,
                TargetValue = convertedValue
            };
            serviceRepository.AddConversionHistory(ch);
            return true;
        }
    }
}
