using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konwerter_jednostek
{
    public class ConvertersService
    {
        ILifetimeScope scope;

        public ConvertersService(ILifetimeScope scope)
        {
            this.scope = scope;
        }

        public List<IKonwertuj> GetConverters()
        {
            var converters = new List<IKonwertuj>();

            converters.AddRange(this.scope.Resolve<IEnumerable<IKonwertuj>>());

            return converters;
        }
    }
}
