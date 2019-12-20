using Autofac;
using System.Collections.Generic;

namespace converter
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
