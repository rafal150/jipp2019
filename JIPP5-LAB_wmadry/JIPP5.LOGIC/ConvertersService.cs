using Autofac;
using JIPP5.SDK;
using System.Collections.Generic;

namespace JIPP5_LAB
{
    public class ConvertersService
    {
        private ILifetimeScope scope;

        public ConvertersService(ILifetimeScope scope)
        {
            this.scope = scope;
        }

        public List<IConverter> GetConverters()
        {
            List<IConverter> converters = new List<IConverter>();

            converters.AddRange(this.scope.Resolve<IEnumerable<IConverter>>());

            return converters;
        }
    }
}