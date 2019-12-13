using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;


namespace Labs.Converters
{
    public class SConverters
    {
        ILifetimeScope scope;
        
        public SConverters(ILifetimeScope scope)
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