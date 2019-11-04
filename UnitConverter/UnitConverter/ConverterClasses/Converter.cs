using System;
using System.Collections.Generic;
using UnitConversion;

namespace UnitConversion
{
    public class Converter
    {
        private readonly IServiceRepository serviceRepository;
        List<UnitConverter> unitConverters;

        public List<UnitConverter> UnitConverters => unitConverters;

        public Converter(IServiceRepository serviceRepository)
        {
            this.serviceRepository = serviceRepository;
            unitConverters = new List<UnitConverter>();
            unitConverters.Add(new TemperatureConverter());
            unitConverters.Add(new LengthConverter());
            unitConverters.Add(new WeightConverter());
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
