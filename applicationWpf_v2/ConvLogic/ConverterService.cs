using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace applicationWpf
{
    public class ConverterService
    {
        ILifetimeScope scope;

        public ConverterService(ILifetimeScope scope)
        {
            this.scope = scope;
        }

        public List<ConverterBase> GetConverters()
        {
            List<ConverterBase> converters = new List<ConverterBase>();

            converters.AddRange(this.scope.Resolve<IEnumerable<ConverterBase>>());
            return converters;
        }
    }
}
