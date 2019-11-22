using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitConverter.SDK;

namespace UnitConverter4.UnitConverters
{
    public class ConvertersService
    {
        ILifetimeScope scope;
        private Dictionary<string, List<IUnitConverter>> unitConvertersPerType;

        public ConvertersService(ILifetimeScope scope)
        {
            this.scope = scope;
        }

        public void LoadConverters()
        {
            unitConvertersPerType = scope.Resolve<IEnumerable<IUnitConverter>>()
                .GroupBy(c => c.Type)
                .ToDictionary(g => g.Key, g => g.ToList());
        }

        public List<string> GetConverterTypes()
        {
            if(unitConvertersPerType == null)
            {
                LoadConverters();
            }

            return unitConvertersPerType.Keys.ToList();
        }

        public List<IUnitConverter> GetConvertersOfType(string converterType)
        {
            if(unitConvertersPerType.TryGetValue(converterType, out var unitConverters))
            {
                return unitConverters;
            }

            return new List<IUnitConverter>();
        }
    }
}
