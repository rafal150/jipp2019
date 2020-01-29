using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterZSQLiAZUREiPLUGIN.Services
{
    public class ConvertersService
    {
        ILifetimeScope scope;

        public ConvertersService(ILifetimeScope scope)
        {
            this.scope = scope;
        }

        public List<KonwerterInterfejs> GetConverters()
        {
            List<KonwerterInterfejs> converters = new List<KonwerterInterfejs>();

            converters.AddRange(this.scope.Resolve<IEnumerable<KonwerterInterfejs>>());


            return converters;
        }
    }
}
