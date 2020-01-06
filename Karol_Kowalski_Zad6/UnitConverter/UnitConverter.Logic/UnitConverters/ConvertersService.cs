using Autofac;
using System.Collections.Generic;
using System.Linq;
using UnitConverter.SDK;

namespace UnitConverter.Logic.UnitConverters
{
    public class ConvertersService
    {
        ILifetimeScope scope;
        private List<Converter> converters;

        public ConvertersService(ILifetimeScope scope)
        {
            this.scope = scope;
        }

        public void LoadConverters()
        {
            converters = scope.Resolve<IEnumerable<IUnitConverter>>()
                .GroupBy(c => c.Type)
                .Select(g => new Converter(g, g.Key))
                .ToList();
        }

        public List<Converter> GetConverters()
        {
            if(converters == null)
            {
                LoadConverters();
            }

            return converters;
        }
    }
}
