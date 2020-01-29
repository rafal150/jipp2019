using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonwerterPLUGIN.Services
{
    public class Konwerter
    {
        ILifetimeScope scope;

        public Konwerter(ILifetimeScope scope)
        {
            this.scope = scope;
        }

        public List<KonwerterInterfejs> GetConverters()
        {
            List<KonwerterInterfejs> converters = new List<KonwerterInterfejs>();

            converters.AddRange(this.scope.Resolve<IEnumerable<KonwerterInterfejs>>());

            converters.Add(new KonwerterMocy());

            return converters;
        }
    }
}
